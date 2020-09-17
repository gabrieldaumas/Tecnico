using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projeto_Maromba_Test
{
    /// <summary>
    /// Interaction logic for Alimentacao.xaml
    /// </summary>
    public partial class Alimentacao : Window
    {
        public class ItemAlimento
        {
            public string nome { get; set; }
            public string quantidade { get; set; }
            public string calorias { get; set; }
            public string carboidratos { get; set; }
            public string proteinas { get; set; }
            public string gorduras { get; set; }
        }
        public static string codigorefeicao = InicioMaromba.codigorefeicao;
        public static string diarefeicao = InicioMaromba.diarefeicao;
        public static string Email = InicioMaromba.Email;
        public Alimentacao()
        {
            InitializeComponent();
            PesquisaAlimentoDataGrid.IsReadOnly = true;
        }

        private void ProcurarButton_Click(object sender, RoutedEventArgs e)
        {
            PesquisaAlimentoDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Alimento",Binding = new Binding("nome")});
            PesquisaAlimentoDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Quantidade(gramas)", Binding = new Binding("quantidade") });
            PesquisaAlimentoDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Calorias", Binding = new Binding("calorias") });
            PesquisaAlimentoDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Carboidratos", Binding = new Binding("carboidratos") });
            PesquisaAlimentoDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Proteínas", Binding = new Binding("proteinas") });
            PesquisaAlimentoDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Gorduras", Binding = new Binding("gorduras") });
            Banco.conn.Open();
            Banco.ExecSelect("SELECT Nome,alimento.quantidade,caloria,carboidratos,proteinas,gorduras FROM alimento where Nome LIKE '%"+AlimentoText.Text+"%'");
            while (Banco.leitor.Read())
            {
                PesquisaAlimentoDataGrid.Items.Add(new ItemAlimento
                {
                    nome = Banco.leitor.GetString(0),
                    quantidade = Banco.leitor.GetString(1),
                    calorias = Banco.leitor.GetString(2),
                    carboidratos = Banco.leitor.GetString(3),
                    proteinas = Banco.leitor.GetString(4),
                    gorduras = Banco.leitor.GetString(5),
                });
            }
            Banco.leitor.Close();
            Banco.conn.Close();
        }

        private void CadastrarAlimentoButton_Click(object sender, RoutedEventArgs e)
        {
            //abrir e criar nova pagina
            CadastrarAlimento inicio = new CadastrarAlimento();
            this.Close();
            inicio.Show();

        }

        private void AdicionarAlimentoCheckButton_Click(object sender, RoutedEventArgs e)
        {
            ItemAlimento drv = (ItemAlimento)PesquisaAlimentoDataGrid.SelectedItem;
            String result =(drv.quantidade).ToString();
            int quantidade;  
            double calorias=0.00,Carboidratos=0.00,Proteinas=0.00,Gorduras=0.00;
            if (int.Parse(result) == 1)
            {
                quantidade = int.Parse(QuantidadeUpDown.Text);
                calorias = Math.Round((double.Parse((drv.calorias).ToString())*quantidade),1);
                Carboidratos = Math.Round((double.Parse((drv.carboidratos).ToString()) * quantidade), 1);
                Proteinas = Math.Round((double.Parse((drv.proteinas).ToString())*quantidade),1);
                Gorduras = Math.Round((double.Parse((drv.gorduras).ToString())*quantidade),1);
            }
            else
            {
                quantidade = int.Parse(result);
                calorias = Math.Round((double.Parse((drv.calorias).ToString()) / quantidade), 1);
                Carboidratos = Math.Round((double.Parse((drv.carboidratos).ToString()) / quantidade), 1);
                Proteinas = Math.Round((double.Parse((drv.proteinas).ToString()) / quantidade), 1);
                Gorduras = Math.Round((double.Parse((drv.gorduras).ToString()) / quantidade), 1);
                quantidade = int.Parse(QuantidadeUpDown.Text);
                calorias = Math.Round(calorias * quantidade, 1);
                Carboidratos = Math.Round(Carboidratos * quantidade, 1);
                Proteinas = Math.Round(Proteinas * quantidade, 1);
                Gorduras = Math.Round(Proteinas * quantidade, 1);
            }
            Banco.conn.Open();
            Banco.ExecSelect("SELECT * FROM alimento WHERE nome='"+drv.nome+"'");
            if(Banco.leitor.Read())
            {
                string codigoalimento = Banco.leitor.GetString(0);
                Banco.leitor.Close();
                Banco.ExecNonSelect("INSERT INTO usuarioalimento VALUES('" + Email + "','" + diarefeicao + "','" + codigoalimento + "','"+codigorefeicao+"','" + quantidade.ToString() + "','" + calorias.ToString() + "','" + Carboidratos.ToString() + "','" + Proteinas.ToString() + "','"+Gorduras.ToString()+"')");
            }
            Banco.conn.Close();
            InicioMaromba.AlimentoTimer.Start();
            this.Close();
        }
    }
}
