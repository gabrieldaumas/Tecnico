using System;
using System.Collections.Generic;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FimCadastro : Window
    {
        //Cria a string informa que receberá o texto do RCQ;
        public static string informa = "";
        public FimCadastro()
        {
            InitializeComponent();
            Banco.conn.Open();
            //Pega a partir do email os calculos realizados no Cadastro
            Banco.ExecSelect("SELECT IMC,RCQ,TMB,Meta,Peso FROM usuariocalculos,usuarioinfo,usuariomedidas WHERE usuariocalculos.Email = usuariomedidas.Email AND usuariomedidas.Email = usuarioinfo.Email AND usuariocalculos.Email = usuarioinfo.Email AND usuarioinfo.Email='" + Cadastro.emails + "'");
            double IMC = 0.00;
            if (Banco.leitor.Read())
            {
                //Deposita esses valores nas labels ou na IMC na qual transfere o valor para double
                IMC = double.Parse(Banco.leitor.GetString(0));
                IMCLabel.Content = Banco.leitor.GetString(0);
                RCQLabel.Content = Banco.leitor.GetString(1);
                TMBLabel.Content = Banco.leitor.GetString(2);
                MetaLabel.Content = Banco.leitor.GetString(3);
                PesoAtualLabel.Content = Banco.leitor.GetString(4);
            }
            Banco.leitor.Close();
            Banco.conn.Close();
            //Checa qual é a classficacao do IMC do usuario apartir do IMCComp e deposita na label
            IMCLabel2.Content = Classificacao.IMCComp(Cadastro.emails);
            //Checa qual é a classficacao do RCQ do usuario apartir do RCQComp e deposita na label
            RCQLabel2.Content = Classificacao.RCQComp(Cadastro.emails);
            //Checa qual é o texto do usuario para o informa, do nivel do RCQ
            informa = Classificacao.RCQInforma(Cadastro.emails);
            //Checa qual é o peso minimo ideal e o peso maximo ideal e deposita na label
            PesoIdealLabel2.Content = Classificacao.IMCIdeais(Cadastro.emails); 

        }
        public Cadastro fim { get; set; }
        //Pega o email para checar no bd
        public string email;


        private void VoltarMenu_Click(object sender, RoutedEventArgs e)
        {
            //Fecha tudo e abre o menu
            //Fechar
            fim.Close();
            fim.CadastroIntro.Close();
            SystemCommands.CloseWindow(this);
            //Abrir
            fim.CadastroIntro.frm2.Show();
        }

        private void IMCLabel3_MouseEnter(object sender, MouseEventArgs e)
        {
            //Informa o usuário sobre o IMC
            System.Windows.MessageBox.Show("Índice de Massa Corporal \n\n Obesidade Grau III ou Morbida: Acima de 40.00 \n Obesidade Grau II ou Moderada: Entre 35.00 e e 39.99 \n Obesidade Grau I ou Leve: Entre 30.00 e 34,99 \n Sobrepeso: Entre 25.00 e 29.99 \n Peso Normal: Entre 18.50 e 24.99 \n Abaixo do Peso: Abaixo de 18.49", "Informativo");
        }

        private void TabelaRCQ_MouseEnter(object sender, MouseEventArgs e)
        {
            //Informa o usuário sobre o RCQ apartir do intervalo de idade e do sexo
            System.Windows.MessageBox.Show(informa.ToString(), "Informativo");
        }

    }
}
