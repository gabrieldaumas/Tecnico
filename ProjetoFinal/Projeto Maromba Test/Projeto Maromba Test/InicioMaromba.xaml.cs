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
using System.Windows.Threading;
namespace Projeto_Maromba_Test
{
    /// <summary>
    /// Interaction logic for InicioMaromba.xaml
    /// </summary>
    public struct UsuarioDiario 
    {
        public string Caloria;
        public string nome;
    }
    public partial class InicioMaromba : Window
    {
        public static string codigorefeicao = "";
        public static string diarefeicao = "";
        public static Label[] labels;
        public static DataGrid[] grids;
        public static Button[] buttons;
        public static TextBox[] texts;
        public static string Email = "";
        public int ngrid;
        public static List<string> Feed = new List<string>();
        public class ItemAlimento
        {
            public string nome { get; set; }
            public string quantidade { get; set; }
            public string calorias { get; set; }
            public string carboidratos { get; set; }
            public string proteinas { get; set; }
            public string gorduras { get; set; }
        }
        public struct ItemAtividade
        {
            public string nome { get; set; }
            public string tipo { get; set; }
            public string quantidadetempo{ get; set; }
            public string calorias{ get; set; }
        }
        public static List<ItemAlimento> Alimento = new List<ItemAlimento>();
        public static List<ItemAtividade> Atividade = new List<ItemAtividade>();
        public MainWindow frm2 { get; set; }
        public DispatcherTimer FeedTimer;
        public static DispatcherTimer AlimentoTimer = new DispatcherTimer();
        public InicioMaromba()
        {
            FeedTimer = new DispatcherTimer();
            FeedTimer.Tick += new EventHandler(FeedTimer_Tick);
            FeedTimer.Interval = new TimeSpan(0,0,05);
            AlimentoTimer.Tick += new EventHandler(AlimentoTimer_Tick);
            AlimentoTimer.Interval = new TimeSpan(0,0,0);
            FeedTimer.Start();

            Email = MainWindow.Email;
            ngrid = 4;
            InitializeComponent();
            DiarioDatePicker.SelectedDate = DateTime.Today.Date;
            Banco.conn.Open();
            Banco.ExecSelect("SELECT TMB,Peso,BF FROM usuariocalculos,usuariomedidas where usuariocalculos.Email = usuariomedidas.Email and usuariomedidas.Email = '" + Email + "'");
            if (Banco.leitor.Read())
            {
                MetaCaloricaLabel.Content = Banco.leitor.GetString(0);
                GorduraLabel.Content = "90";
                //por enquanto
                RestanteCaloria.Content = Banco.leitor.GetString(0);
                double Peso = double.Parse(Banco.leitor.GetString(1));
                Peso *= (1 - (double.Parse(Banco.leitor.GetString(2))/100));
                ProteinaLabel.Content = (Peso * 2).ToString();
                double carbs = (double.Parse(Banco.leitor.GetString(0)) - (((Peso * 2) * 4) + (90 * 9)))/4;
                CarbsLabel.Content = carbs.ToString();
            }
            Banco.leitor.Close();
            Banco.ExecSelect("SELECT COUNT(*) FROM usuariorotina WHERE Email='"+Email+"' and dia ='"+DateTime.Today.Date.ToShortDateString()+"'");
            if (Banco.leitor.Read())
            {
                ngrid = int.Parse(Banco.leitor.GetString(0));
                if (ngrid == 0)
                {
                    ngrid = 1;
                    buttons = new Button[ngrid];
                }
                else
                {
                    ngrid += 1;
                }
            }
            Banco.leitor.Close();
            Banco.conn.Close();
            grids = new DataGrid[ngrid];
            texts = new TextBox[ngrid];
            labels = new Label[ngrid];
            buttons = new Button[(ngrid * 3)+2];
            int TOPgrid = 133;
            int TOPbutton = 150;
            int counter = 0;
            for (int i = 0; i < ngrid; i++)
            {
                grids[i] = new DataGrid();
                if (i == (ngrid - 1))
                {
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAdRot_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarRefeicao";
                    buttons[counter].Content = "Adicionar Refeição";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid , 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAdRot_Click;
                    buttons[counter].Name = "_" + i.ToString() + "DeletarRefeicao";
                    buttons[counter].Content = "Deletar Refeição";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(120, TOPgrid, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    labels[i] = new Label();
                    labels[i].Name = "_" + i.ToString() + "Exercicios";
                    labels[i].Width = 75;
                    labels[i].Height = 30;
                    labels[i].Content = "Exercícios";
                    labels[i].Tag = i.ToString();
                    labels[i].Margin = new Thickness(10, TOPgrid + 30, 0, 0);
                    labels[i].HorizontalAlignment = HorizontalAlignment.Left;
                    labels[i].VerticalAlignment = VerticalAlignment.Top;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAlEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarExercicio";
                    buttons[counter].Content = "Adicionar Exercício";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid + 220, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Editar";
                    buttons[counter].Content = "Editar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 90, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    //code
                    counter++;
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Deletar";
                    buttons[counter].Content = "Deletar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 120, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Atividade",Binding = new Binding("nome") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Tipo", Binding = new Binding("tipo") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Gasto Calórico", Binding = new Binding("calorias") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Tempo", Binding = new Binding("quantidadetempo") });
                    grids[i].Name = "UsuarioExercicio" + i;
                    grids[i].Width = 442;
                    grids[i].Height = 150;
                    grids[i].HorizontalAlignment = HorizontalAlignment.Left;
                    grids[i].VerticalAlignment = VerticalAlignment.Top;
                    grids[i].Margin = new Thickness(5, TOPgrid + 60, 0, 0);
                    TOPgrid += 190;
                    TOPbutton += 190;
                    ItemAtividade item;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT Nome,tipoatividade,tempoatividade,usuarioatividade.gastocalorico FROM usuarioatividade,atividade where Email='" + Email + "' and dia ='" + DateTime.Today.ToShortDateString() + "' and usuarioatividade.codigoatividade = atividade.Codigoatividade");
                    while (Banco.leitor.Read())
                    {
                        item = new ItemAtividade();
                        item.nome = Banco.leitor.GetString(0);
                        item.tipo = Banco.leitor.GetString(1);
                        item.quantidadetempo = Banco.leitor.GetString(2);
                        item.calorias = Banco.leitor.GetString(3);
                        grids[i].Items.Add(item);
                    }
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
                else
                {
                    labels[i] = new Label();
                    labels[i].Name = "_" + i.ToString() + "LabelNomeRefeicao";
                    labels[i].Width = 120;
                    labels[i].Height = 30;
                    labels[i].Content = "Nome da Refeição:";
                    labels[i].Tag = i.ToString();
                    labels[i].Margin = new Thickness(10, TOPgrid, 0, 0);
                    labels[i].HorizontalAlignment = HorizontalAlignment.Left;
                    labels[i].VerticalAlignment = VerticalAlignment.Top;

                    texts[i] = new TextBox();
                    texts[i].Name = "_" + i.ToString() + "NomeRefeicao";
                    texts[i].Width = 120;
                    texts[i].Height = 20;
                    texts[i].Tag = i.ToString();
                    texts[i].Margin = new Thickness(130, TOPgrid, 0, 0);
                    texts[i].LostFocus += NomeRotinaText_LostFocus;
                    texts[i].HorizontalAlignment = HorizontalAlignment.Left;
                    texts[i].VerticalAlignment = VerticalAlignment.Top;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT nome FROM usuariorotina where codigorefeicao='" + i.ToString() + "' and Email='" + Email + "' and dia ='" + DateTime.Today.ToShortDateString()+ "'");
                    if (Banco.leitor.Read())
                    {
                        texts[i].Text = Banco.leitor.GetString(0);
                    }
                    Banco.conn.Close();
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAlEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarAlimento";
                    buttons[counter].Content = "Adicionar Alimento";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid + 190, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMaromba_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Editar";
                    buttons[counter].Content = "Editar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 60, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    //code
                    counter++;
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMaromba_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Deletar";
                    buttons[counter].Content = "Deletar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 90, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Alimento",Binding = new Binding("nome")});
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Quantidade(gramas)", Binding = new Binding("quantidade") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Calorias", Binding = new Binding("calorias") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Carboidratos", Binding = new Binding("carboidratos") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Proteínas", Binding = new Binding("proteinas") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Gorduras", Binding = new Binding("gorduras") });
                    grids[i].Name = "UsuarioRefeicao" + i;
                    grids[i].Width = 442;
                    grids[i].Height = 150;
                    grids[i].HorizontalAlignment = HorizontalAlignment.Left;
                    grids[i].VerticalAlignment = VerticalAlignment.Top;
                    grids[i].Margin = new Thickness(5, TOPgrid + 30, 0, 0);
                    grids[i].IsReadOnly = true;
                    grids[i].AutoGenerateColumns = false;
                    TOPgrid += 220;
                    TOPbutton += 220;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT Nome,usuarioalimento.quantidade,caloriasingeridas,carbsingeridos,proteinasingeridas,gordurasingeridas FROM usuarioalimento,alimento where codigorefeicao='" + i.ToString() + "' and Email='" + Email + "' and dia ='" + DateTime.Today.ToShortDateString() + "' and usuarioalimento.codigoalimento = alimento.CodigoAlimento");
                    while (Banco.leitor.Read())
                    {
                        var data = new ItemAlimento
                        {
                            nome = Banco.leitor.GetString(0),
                            quantidade = Banco.leitor.GetString(1),
                            calorias = Banco.leitor.GetString(2),
                            carboidratos = Banco.leitor.GetString(3),
                            proteinas = Banco.leitor.GetString(4),
                            gorduras = Banco.leitor.GetString(5),
                        };
                        grids[i].Items.Add(data);
                    }
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
            }
            counter = 0;
            for (int i = 0; i < ngrid; i++)
            {
                if (i == (ngrid - 1))
                {
                    DiarioGrid.Children.Add(labels[i]);
                    DiarioGrid.Children.Add(buttons[counter]);
                    counter++;
                    DiarioGrid.Children.Add(buttons[counter]);
                    counter++;
                }
                else
                {
                    DiarioGrid.Children.Add(labels[i]);
                    DiarioGrid.Children.Add(texts[i]);
                }
                DiarioGrid.Children.Add(grids[i]);
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
            }
        }

        private void AlimentoTimer_Tick(object sender, EventArgs e)
        {
            Atividade.Clear();
            Alimento.Clear();
            Grid gridei = DiarioGrid2;
            DiarioGrid.Children.Clear();
            DiarioGrid.Children.Add(gridei);
            grids = new DataGrid[ngrid];
            texts = new TextBox[ngrid];
            labels = new Label[ngrid];
            buttons = new Button[(ngrid * 3) + 2];
            int TOPgrid = 133;
            int TOPbutton = 150;
            int counter = 0;
            for (int i = 0; i < ngrid; i++)
            {
                grids[i] = new DataGrid();
                if (i == (ngrid - 1))
                {
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAdRot_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarRefeicao";
                    buttons[counter].Content = "Adicionar Refeição";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAdRot_Click;
                    buttons[counter].Name = "_" + i.ToString() + "DeletarRefeicao";
                    buttons[counter].Content = "Deletar Refeição";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(120, TOPgrid, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    labels[i] = new Label();
                    labels[i].Name = "_" + i.ToString() + "Exercicios";
                    labels[i].Width = 75;
                    labels[i].Height = 30;
                    labels[i].Content = "Exercícios";
                    labels[i].Tag = i.ToString();
                    labels[i].Margin = new Thickness(10, TOPgrid + 30, 0, 0);
                    labels[i].HorizontalAlignment = HorizontalAlignment.Left;
                    labels[i].VerticalAlignment = VerticalAlignment.Top;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAlEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarExercicio";
                    buttons[counter].Content = "Adicionar Exercício";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid + 220, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Editar";
                    buttons[counter].Content = "Editar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 90, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    //code
                    counter++;
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Deletar";
                    buttons[counter].Content = "Deletar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 120, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Atividade", Binding = new Binding("nome") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Tipo", Binding = new Binding("tipo") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Gasto Calórico", Binding = new Binding("calorias") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Tempo", Binding = new Binding("quantidadetempo") });
                    grids[i].Name = "UsuarioExercicio" + i;
                    grids[i].Width = 442;
                    grids[i].Height = 150;
                    grids[i].HorizontalAlignment = HorizontalAlignment.Left;
                    grids[i].VerticalAlignment = VerticalAlignment.Top;
                    grids[i].Margin = new Thickness(5, TOPgrid + 60, 0, 0);
                    TOPgrid += 190;
                    TOPbutton += 190;
                    ItemAtividade item;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT Nome,tipoatividade,tempoatividade,usuarioatividade.gastocalorico FROM usuarioatividade,atividade where Email='" + Email + "' and dia ='" + DateTime.Today.ToShortDateString() + "' and usuarioatividade.codigoatividade = atividade.Codigoatividade");
                    while (Banco.leitor.Read())
                    {
                        item = new ItemAtividade();
                        item.nome = Banco.leitor.GetString(0);
                        item.tipo = Banco.leitor.GetString(1);
                        item.quantidadetempo = Banco.leitor.GetString(2);
                        item.calorias = Banco.leitor.GetString(3);
                        Atividade.Add(item);
                    }
                    grids[i].ItemsSource = Atividade;
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
                else
                {
                    labels[i] = new Label();
                    labels[i].Name = "_" + i.ToString() + "LabelNomeRefeicao";
                    labels[i].Width = 120;
                    labels[i].Height = 30;
                    labels[i].Content = "Nome da Refeição:";
                    labels[i].Tag = i.ToString();
                    labels[i].Margin = new Thickness(10, TOPgrid, 0, 0);
                    labels[i].HorizontalAlignment = HorizontalAlignment.Left;
                    labels[i].VerticalAlignment = VerticalAlignment.Top;

                    texts[i] = new TextBox();
                    texts[i].Name = "_" + i.ToString() + "NomeRefeicao";
                    texts[i].Width = 120;
                    texts[i].Height = 20;
                    texts[i].Tag = i.ToString();
                    texts[i].Margin = new Thickness(130, TOPgrid, 0, 0);
                    texts[i].LostFocus += NomeRotinaText_LostFocus;
                    texts[i].HorizontalAlignment = HorizontalAlignment.Left;
                    texts[i].VerticalAlignment = VerticalAlignment.Top;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT nome FROM usuariorotina where codigorefeicao='" + i.ToString() + "' and Email='" + Email + "' and dia ='" + DateTime.Today.ToShortDateString() + "'");
                    if (Banco.leitor.Read())
                    {
                        texts[i].Text = Banco.leitor.GetString(0);
                    }
                    Banco.conn.Close();
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAlEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarAlimento";
                    buttons[counter].Content = "Adicionar Alimento";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid + 190, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMaromba_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Editar";
                    buttons[counter].Content = "Editar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 60, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    //code
                    counter++;
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMaromba_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Deletar";
                    buttons[counter].Content = "Deletar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 90, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Alimento", Binding = new Binding("nome") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Quantidade(gramas)", Binding = new Binding("quantidade") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Calorias", Binding = new Binding("calorias") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Carboidratos", Binding = new Binding("carboidratos") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Proteínas", Binding = new Binding("proteinas") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Gorduras", Binding = new Binding("gorduras") });
                    grids[i].Name = "UsuarioRefeicao" + i;
                    grids[i].Width = 442;
                    grids[i].Height = 150;
                    grids[i].HorizontalAlignment = HorizontalAlignment.Left;
                    grids[i].VerticalAlignment = VerticalAlignment.Top;
                    grids[i].Margin = new Thickness(5, TOPgrid + 30, 0, 0);
                    grids[i].IsReadOnly = true;
                    grids[i].AutoGenerateColumns = false;
                    TOPgrid += 220;
                    TOPbutton += 220;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT Nome,usuarioalimento.quantidade,caloriasingeridas,carbsingeridos,proteinasingeridas,gordurasingeridas FROM usuarioalimento,alimento where codigorefeicao='" + i.ToString() + "' and Email='" + Email + "' and dia ='" + DateTime.Today.ToShortDateString() + "' and usuarioalimento.codigoalimento = alimento.CodigoAlimento");
                    while (Banco.leitor.Read())
                    {
                        var data = new ItemAlimento
                        {
                            nome = Banco.leitor.GetString(0),
                            quantidade = Banco.leitor.GetString(1),
                            calorias = Banco.leitor.GetString(2),
                            carboidratos = Banco.leitor.GetString(3),
                            proteinas = Banco.leitor.GetString(4),
                            gorduras = Banco.leitor.GetString(5),
                        };
                        Alimento.Add(data);
                    }
                    grids[i].ItemsSource = Alimento;
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
            }
            counter = 0;
            for (int i = 0; i < ngrid; i++)
            {
                if (i == (ngrid - 1))
                {
                    DiarioGrid.Children.Add(labels[i]);
                    DiarioGrid.Children.Add(buttons[counter]);
                    counter++;
                    DiarioGrid.Children.Add(buttons[counter]);
                    counter++;
                }
                else
                {
                    DiarioGrid.Children.Add(labels[i]);
                    DiarioGrid.Children.Add(texts[i]);
                }
                DiarioGrid.Children.Add(grids[i]);
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
            }
            AlimentoTimer.Stop();
        }

        private void InicioMaromba_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ngrid;i++)
            {
                if ((sender as Button).Name == "_" + i.ToString() + "Editar")
                {
                    MessageBox.Show("Em manutenção");
                }
                else if ((sender as Button).Name == "_" + i.ToString() + "Deletar")
                {
                    if (grids[i].SelectedIndex != -1)
                    {
                        Banco.conn.Open();
                        ItemAlimento drv = (ItemAlimento)grids[i].SelectedItem;
                        String result = "";
                        Banco.ExecSelect("SELECT codigoalimento FROM alimento WHERE nome='"+drv.nome+"'");
                        if (Banco.leitor.Read())
                        {
                            result = Banco.leitor.GetString(0);
                           
                        }
                        Banco.leitor.Close();
                        Banco.ExecNonSelect("DELETE FROM usuarioalimento where codigoalimento='" + result + "' and Email='" + Email + "' and dia='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "' and quantidade ='" + (drv.quantidade).ToString() + "' ");
                        Alimento.Clear();
                        Banco.ExecSelect("SELECT Nome,usuarioalimento.quantidade,caloriasingeridas,carbsingeridos,proteinasingeridas,gordurasingeridas FROM usuarioalimento,alimento where codigorefeicao='" + i.ToString() + "' and Email='" + Email + "' and dia ='" + DateTime.Today.ToShortDateString() + "' and usuarioalimento.codigoalimento = alimento.CodigoAlimento");
                        while (Banco.leitor.Read())
                        {
                            var data = new ItemAlimento
                            {
                                nome = Banco.leitor.GetString(0),
                                quantidade = Banco.leitor.GetString(1),
                                calorias = Banco.leitor.GetString(2),
                                carboidratos = Banco.leitor.GetString(3),
                                proteinas = Banco.leitor.GetString(4),
                                gorduras = Banco.leitor.GetString(5),
                            };
                            Alimento.Add(data);
                        }

                        Banco.leitor.Close();
                        Banco.conn.Close();
                    }  
                }
            }
        }
        private void InicioMarombaEx_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ngrid; i++)
            {
                if ((sender as Button).Name == "_" + i.ToString() + "Editar")
                {
                    MessageBox.Show("Em manutenção");
                }
                else if ((sender as Button).Name == "_" + i.ToString() + "Deletar")
                {
                    Banco.conn.Open();
                    DataRowView drv = (DataRowView)grids[i].SelectedItem;
                    String result = (drv["Atividade"]).ToString();
                    Banco.ExecNonSelect("DELETE FROM usuarioatividade,atividade where nome='" + result + "' and Email='" + Email + "' and dia='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "' and tempoatividade ='" + (drv["quantidadetempo"]).ToString() + "' and usuarioatividade.codigoatividade = atividade.Codigoatividade");
                    ItemAtividade item;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT Nome,tipoatividade,tempoatividade,usuarioatividade.gastocalorico FROM usuarioatividade,atividade where Email='" + Email + "' and dia ='" + DateTime.Today.ToShortDateString() + "' and usuarioatividade.codigoatividade = atividade.Codigoatividade");
                    while (Banco.leitor.Read())
                    {
                        item = new ItemAtividade();
                        item.nome = Banco.leitor.GetString(0);
                        item.tipo = Banco.leitor.GetString(1);
                        item.quantidadetempo = Banco.leitor.GetString(2);
                        item.calorias = Banco.leitor.GetString(3);
                        Atividade.Add(item);
                    }
                    grids[i].ItemsSource = Atividade;
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
            }
        }
        private void InicioMarombaAlEx_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ngrid; i++)
            {
                if ((sender as Button).Name == "_" + i.ToString() + "AdicionarAlimento")
                {
                    codigorefeicao = i.ToString();
                    diarefeicao = DiarioDatePicker.SelectedDate.Value.ToShortDateString();
                    Alimentacao ali = new Alimentacao();
                    ali.Show();
                }
                else if ((sender as Button).Name == "_" + i.ToString() + "AdicionarExercicio")
                {
                    MessageBox.Show("Em MAnutenção");
                }
            }
        }
        private void InicioMarombaAdRot_Click(object sender, RoutedEventArgs e)
        {
            Atividade.Clear();
            Alimento.Clear();
            Banco.conn.Open();
            Banco.ExecNonSelect("DELETE FROM usuariorotina WHERE Email='" + Email + "' and dia='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "'");
            for (int i = 0; i < ((ngrid * 3) + 2); i++)
            {
                if ((sender as Button).Name == "_" + i.ToString() + "AdicionarRefeicao")
                {
                    ngrid++;
                    break;
                }
                else if ((sender as Button).Name == "_" + i.ToString() + "DeletarRefeicao")
                {
                    if (ngrid != 1)
                    {
                        ngrid--;
                        break;
                    }
                }
            }
            Banco.leitor.Close();
            Grid gridei = DiarioGrid2;
            DiarioGrid.Children.Clear();
            DiarioGrid.Children.Add(gridei);
            grids = new DataGrid[ngrid];
            texts = new TextBox[ngrid];
            labels = new Label[ngrid];
            buttons = new Button[(ngrid * 3) + 2];
            int TOPgrid = 133;
            int TOPbutton = 150;
            int counter = 0;
            for (int i = 0; i < ngrid; i++)
            {
                grids[i] = new DataGrid();
                if (i == (ngrid - 1))
                {
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAdRot_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarRefeicao";
                    buttons[counter].Content = "Adicionar Refeição";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAdRot_Click;
                    buttons[counter].Name = "_" + i.ToString() + "DeletarRefeicao";
                    buttons[counter].Content = "Deletar Refeição";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(120, TOPgrid, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    labels[i] = new Label();
                    labels[i].Name = "_" + i.ToString() + "Exercicios";
                    labels[i].Width = 75;
                    labels[i].Height = 30;
                    labels[i].Content = "Exercícios";
                    labels[i].Tag = i.ToString();
                    labels[i].Margin = new Thickness(10, TOPgrid + 30, 0, 0);
                    labels[i].HorizontalAlignment = HorizontalAlignment.Left;
                    labels[i].VerticalAlignment = VerticalAlignment.Top;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAlEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarExercicio";
                    buttons[counter].Content = "Adicionar Exercício";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid + 220, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Editar";
                    buttons[counter].Content = "Editar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 90, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    //code
                    counter++;
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Deletar";
                    buttons[counter].Content = "Deletar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 120, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Atividade", Binding = new Binding("nome") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Tipo", Binding = new Binding("tipo") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Gasto Calórico", Binding = new Binding("calorias") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Tempo", Binding = new Binding("quantidadetempo") });
                    grids[i].Name = "UsuarioExercicio" + i;
                    grids[i].Width = 442;
                    grids[i].Height = 150;
                    grids[i].HorizontalAlignment = HorizontalAlignment.Left;
                    grids[i].VerticalAlignment = VerticalAlignment.Top;
                    grids[i].Margin = new Thickness(5, TOPgrid + 60, 0, 0);
                    TOPgrid += 190;
                    TOPbutton += 190;
                    ItemAtividade item;
                    Banco.ExecSelect("SELECT Nome,tipoatividade,tempoatividade,usuarioatividade.gastocalorico FROM usuarioatividade,atividade where Email='" + Email + "' and dia ='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "' and usuarioatividade.codigoatividade = atividade.Codigoatividade");
                    while (Banco.leitor.Read())
                    {
                        item = new ItemAtividade();
                        item.nome = Banco.leitor.GetString(0);
                        item.tipo = Banco.leitor.GetString(1);
                        item.quantidadetempo = Banco.leitor.GetString(2);
                        item.calorias = Banco.leitor.GetString(3);
                        Atividade.Add(item);
                    }
                    grids[i].ItemsSource = Atividade;
                    Banco.leitor.Close();
                }
                else
                {
                    labels[i] = new Label();
                    labels[i].Name = "_" + i.ToString() + "LabelNomeRefeicao";
                    labels[i].Width = 120;
                    labels[i].Height = 30;
                    labels[i].Content = "Nome da Refeição:";
                    labels[i].Tag = i.ToString();
                    labels[i].Margin = new Thickness(10, TOPgrid, 0, 0);
                    labels[i].HorizontalAlignment = HorizontalAlignment.Left;
                    labels[i].VerticalAlignment = VerticalAlignment.Top;

                    texts[i] = new TextBox();
                    texts[i].Name = "_" + i.ToString() + "NomeRefeicao";
                    texts[i].Width = 120;
                    texts[i].Height = 20;
                    texts[i].Tag = i.ToString();
                    texts[i].Margin = new Thickness(130, TOPgrid, 0, 0);
                    texts[i].LostFocus += NomeRotinaText_LostFocus;
                    texts[i].HorizontalAlignment = HorizontalAlignment.Left;
                    texts[i].VerticalAlignment = VerticalAlignment.Top;
                    Banco.ExecSelect("SELECT nome FROM usuariorotina where codigorefeicao='" + i.ToString() + "' and Email='" + Email + "' and dia ='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "'");
                    if (Banco.leitor.Read())
                    {
                        texts[i].Text = Banco.leitor.GetString(0);
                    }
                    Banco.leitor.Close();
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAlEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarAlimento";
                    buttons[counter].Content = "Adicionar Alimento";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid + 190, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMaromba_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Editar";
                    buttons[counter].Content = "Editar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 60, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    //code
                    counter++;
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMaromba_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Deletar";
                    buttons[counter].Content = "Deletar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 90, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Alimento", Binding = new Binding("nome") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Quantidade(gramas)", Binding = new Binding("quantidade") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Calorias", Binding = new Binding("calorias") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Carboidratos", Binding = new Binding("carboidratos") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Proteínas", Binding = new Binding("proteinas") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Gorduras", Binding = new Binding("gorduras") });
                    grids[i].Name = "UsuarioRefeicao" + i;
                    grids[i].Width = 442;
                    grids[i].Height = 150;
                    grids[i].HorizontalAlignment = HorizontalAlignment.Left;
                    grids[i].VerticalAlignment = VerticalAlignment.Top;
                    grids[i].Margin = new Thickness(5, TOPgrid + 30, 0, 0);
                    grids[i].IsReadOnly = true;
                    grids[i].AutoGenerateColumns = false;
                    TOPgrid += 220;
                    TOPbutton += 220;
                    Banco.ExecNonSelect("INSERT INTO `usuariorotina` VALUES ('" + Email + "','" + i.ToString() + "','" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "','" + texts[i].Text + "')");
                    Banco.ExecSelect("SELECT Nome,usuarioalimento.quantidade,caloriasingeridas,carbsingeridos,proteinasingeridas,gordurasingeridas FROM usuarioalimento,alimento where codigorefeicao='" + i.ToString() + "' and Email='" + Email + "' and dia ='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "' and usuarioalimento.codigoalimento = alimento.CodigoAlimento");
                    while (Banco.leitor.Read())
                    {
                        var data = new ItemAlimento
                        {
                            nome = Banco.leitor.GetString(0),
                            quantidade = Banco.leitor.GetString(1),
                            calorias = Banco.leitor.GetString(2),
                            carboidratos = Banco.leitor.GetString(3),
                            proteinas = Banco.leitor.GetString(4),
                            gorduras = Banco.leitor.GetString(5),
                        };
                        Alimento.Add(data);
                    }
                    grids[i].ItemsSource = Alimento;
                    Banco.leitor.Close();
                }
            }
            counter = 0;
            for (int i = 0; i < ngrid; i++)
            {
                if (i == (ngrid - 1))
                {
                    DiarioGrid.Children.Add(labels[i]);
                    DiarioGrid.Children.Add(buttons[counter]);
                    counter++;
                    DiarioGrid.Children.Add(buttons[counter]);
                    counter++;
                }
                else
                {
                    DiarioGrid.Children.Add(labels[i]);
                    DiarioGrid.Children.Add(texts[i]);
                }
                DiarioGrid.Children.Add(grids[i]);
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
            }
            Banco.conn.Close();
        }

        private void NomeRotinaText_LostFocus(object sender, RoutedEventArgs e)
        {
            Banco.conn.Open();
            for (int i = 0; i < ngrid; i++)
            {
                if ((sender as TextBox).Name == "_" + i.ToString() + "NomeRefeicao")
                {
                    Banco.ExecNonSelect("UPDATE `usuariorotina` SET `nome`='" + (sender as TextBox).Text.Trim() + "' WHERE codigorefeicao='" + i + "' and dia ='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "'");
                    break;
                }
            }
            Banco.conn.Close();
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Atividade.Clear();
            Alimento.Clear();
            Grid gridei = DiarioGrid2;
            DiarioGrid.Children.Clear();
            DiarioGrid.Children.Add(gridei);
            //Select from BD rotina alimento e academia
            Banco.conn.Open();
            Banco.ExecSelect("SELECT COUNT(*) FROM usuariorotina WHERE Email='" + Email + "' and dia ='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "'");
            if (Banco.leitor.Read())
            {
                ngrid = int.Parse(Banco.leitor.GetString(0));
                if (ngrid == 0)
                {
                    ngrid = 1;
                }
                else
                {
                    ngrid += 1;
                }
            }
            Banco.leitor.Close();
            Banco.conn.Close();
            grids = new DataGrid[ngrid];
            texts = new TextBox[ngrid];
            labels = new Label[ngrid];
            buttons = new Button[(ngrid * 3) + 2];
            int TOPgrid = 133;
            int TOPbutton = 150;
            int counter = 0;
            for (int i = 0; i < ngrid; i++)
            {
                grids[i] = new DataGrid();
                if (i == (ngrid - 1))
                {
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAdRot_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarRefeicao";
                    buttons[counter].Content = "Adicionar Refeição";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAdRot_Click;
                    buttons[counter].Name = "_" + i.ToString() + "DeletarRefeicao";
                    buttons[counter].Content = "Deletar Refeição";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(120, TOPgrid, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    labels[i] = new Label();
                    labels[i].Name = "_" + i.ToString() + "Exercicios";
                    labels[i].Width = 75;
                    labels[i].Height = 30;
                    labels[i].Content = "Exercícios";
                    labels[i].Tag = i.ToString();
                    labels[i].Margin = new Thickness(10, TOPgrid + 30, 0, 0);
                    labels[i].HorizontalAlignment = HorizontalAlignment.Left;
                    labels[i].VerticalAlignment = VerticalAlignment.Top;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAlEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarExercicio";
                    buttons[counter].Content = "Adicionar Exercício";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid + 220, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Editar";
                    buttons[counter].Content = "Editar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 90, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    //code
                    counter++;
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Deletar";
                    buttons[counter].Content = "Deletar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 120, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Atividade", Binding = new Binding("nome") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Tipo", Binding = new Binding("tipo") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Gasto Calórico", Binding = new Binding("calorias") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Tempo", Binding = new Binding("quantidadetempo") });
                    grids[i].Name = "UsuarioExercicio" + i;
                    grids[i].Width = 442;
                    grids[i].Height = 150;
                    grids[i].HorizontalAlignment = HorizontalAlignment.Left;
                    grids[i].VerticalAlignment = VerticalAlignment.Top;
                    grids[i].Margin = new Thickness(5, TOPgrid + 60, 0, 0);
                    TOPgrid += 190;
                    TOPbutton += 190;
                    ItemAtividade item;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT Nome,tipoatividade,tempoatividade,usuarioatividade.gastocalorico FROM usuarioatividade,atividade where Email='" + Email + "' and dia ='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "' and usuarioatividade.codigoatividade = atividade.Codigoatividade");
                    while (Banco.leitor.Read())
                    {
                        item = new ItemAtividade();
                        item.nome = Banco.leitor.GetString(0);
                        item.tipo = Banco.leitor.GetString(1);
                        item.quantidadetempo = Banco.leitor.GetString(2);
                        item.calorias = Banco.leitor.GetString(3);
                        Atividade.Add(item);
                    }
                    grids[i].ItemsSource = Atividade;
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
                else
                {
                    labels[i] = new Label();
                    labels[i].Name = "_" + i.ToString() + "LabelNomeRefeicao";
                    labels[i].Width = 120;
                    labels[i].Height = 30;
                    labels[i].Content = "Nome da Refeição:";
                    labels[i].Tag = i.ToString();
                    labels[i].Margin = new Thickness(10, TOPgrid, 0, 0);
                    labels[i].HorizontalAlignment = HorizontalAlignment.Left;
                    labels[i].VerticalAlignment = VerticalAlignment.Top;

                    texts[i] = new TextBox();
                    texts[i].Name = "_" + i.ToString() + "NomeRefeicao";
                    texts[i].Width = 120;
                    texts[i].Height = 20;
                    texts[i].Tag = i.ToString();
                    texts[i].Margin = new Thickness(130, TOPgrid, 0, 0);
                    texts[i].LostFocus += NomeRotinaText_LostFocus;
                    texts[i].HorizontalAlignment = HorizontalAlignment.Left;
                    texts[i].VerticalAlignment = VerticalAlignment.Top;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT nome FROM usuariorotina where codigorefeicao='" + i.ToString() + "' and Email='" + Email + "' and dia ='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "'");
                    if (Banco.leitor.Read())
                    {
                        texts[i].Text = Banco.leitor.GetString(0);
                    }
                    Banco.conn.Close();
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMarombaAlEx_Click;
                    buttons[counter].Name = "_" + i.ToString() + "AdicionarAlimento";
                    buttons[counter].Content = "Adicionar Alimento";
                    buttons[counter].Width = 110;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(10, TOPgrid + 190, 0, 0);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;

                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMaromba_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Editar";
                    buttons[counter].Content = "Editar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 60, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    //code
                    counter++;
                    buttons[counter] = new Button();
                    buttons[counter].Click += InicioMaromba_Click;
                    buttons[counter].Name = "_" + i.ToString() + "Deletar";
                    buttons[counter].Content = "Deletar";
                    buttons[counter].Width = 75;
                    buttons[counter].Height = 20;
                    buttons[counter].Margin = new Thickness(474, TOPbutton + 90, 0, 40);
                    buttons[counter].HorizontalAlignment = HorizontalAlignment.Left;
                    buttons[counter].VerticalAlignment = VerticalAlignment.Top;
                    counter++;
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Alimento", Binding = new Binding("nome") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Quantidade(gramas)", Binding = new Binding("quantidade") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Calorias", Binding = new Binding("calorias") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Carboidratos", Binding = new Binding("carboidratos") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Proteínas", Binding = new Binding("proteinas") });
                    grids[i].Columns.Add(new DataGridTextColumn() { Header = "Gorduras", Binding = new Binding("gorduras") });
                    grids[i].Name = "UsuarioRefeicao" + i;
                    grids[i].Width = 442;
                    grids[i].Height = 150;
                    grids[i].HorizontalAlignment = HorizontalAlignment.Left;
                    grids[i].VerticalAlignment = VerticalAlignment.Top;
                    grids[i].Margin = new Thickness(5, TOPgrid + 30, 0, 0);
                    grids[i].IsReadOnly = true;
                    grids[i].AutoGenerateColumns = false;
                    TOPgrid += 220;
                    TOPbutton += 220;
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT Nome,usuarioalimento.quantidade,caloriasingeridas,carbsingeridos,proteinasingeridas,gordurasingeridas FROM usuarioalimento,alimento where codigorefeicao='" + i.ToString() + "' and Email='" + Email + "' and dia ='" + DiarioDatePicker.SelectedDate.Value.ToShortDateString() + "' and usuarioalimento.codigoalimento = alimento.CodigoAlimento");
                    while (Banco.leitor.Read())
                    {
                        var data = new ItemAlimento
                        {
                            nome = Banco.leitor.GetString(0),
                            quantidade = Banco.leitor.GetString(1),
                            calorias = Banco.leitor.GetString(2),
                            carboidratos = Banco.leitor.GetString(3),
                            proteinas = Banco.leitor.GetString(4),
                            gorduras = Banco.leitor.GetString(5),
                        };
                        Alimento.Add(data);
                    }
                    grids[i].ItemsSource = Alimento;
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
            }
            counter = 0;
            for (int i = 0; i < ngrid; i++)
            {
                if (i == (ngrid - 1))
                {
                    DiarioGrid.Children.Add(labels[i]);
                    DiarioGrid.Children.Add(buttons[counter]);
                    counter++;
                    DiarioGrid.Children.Add(buttons[counter]);
                    counter++;
                }
                else
                {
                    DiarioGrid.Children.Add(labels[i]);
                    DiarioGrid.Children.Add(texts[i]);
                }
                DiarioGrid.Children.Add(grids[i]);
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
                DiarioGrid.Children.Add(buttons[counter]);
                counter++;
            }
        }
        private void FeedTimer_Tick(object sender, EventArgs e)
        {
            Feed.Clear();
            FeedGrid.Children.Clear();
            Banco.conn.Open();
            int n = 0;
            Banco.ExecSelect("Select COUNT(*) from usuariofeed");
            if (Banco.leitor.Read())
            {
                n = int.Parse(Banco.leitor.GetString(0));
            }
            Banco.leitor.Close();
            Banco.ExecSelect("Select frase from usuariofeed");
            while (Banco.leitor.Read())
            {
                Feed.Add(Banco.leitor.GetString(0));
            }
            labels = new Label[n];
            int TOP = 0;
            for (int i = 0; i < n; i++)
            {
                    labels[i] = new Label();
                    labels[i].Name = "label" + i;
                    labels[i].Content = Feed[i];
                    labels[i].Margin = new Thickness(0, TOP, 0, 0);
                    TOP += 20;
            }
            for (int i = 0; i < n; i++)
            {
                FeedGrid.Children.Add(labels[i]);
            }
            Banco.leitor.Close();
            Banco.conn.Close();
        }

    }
}
