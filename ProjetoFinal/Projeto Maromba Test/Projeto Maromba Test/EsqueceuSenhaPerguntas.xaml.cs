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
    public partial class EsqueceuSenhaPerguntas: Window
    {
        public static string email = EsqueceuSenha.emails;
        public EsqueceuSenhaPerguntas()
        {
            InitializeComponent();
            Banco.conn.Open();
            //Seleciona a Data de Nascimento pelo usuário
            Banco.ExecSelect("SELECT Pergunta1,Pergunta2,Pergunta3 FROM usuariorecuperacao WHERE Email = '" + email + "'");
            if (Banco.leitor.Read())
            {
                Pergunta1Text.Text = Banco.leitor.GetString(0);
                Pergunta2Text.Text = Banco.leitor.GetString(1);
                Pergunta3Text.Text = Banco.leitor.GetString(2);
            }
            Banco.leitor.Close();
            Banco.conn.Close();
        }
        //Cria um objeto relacionado ao MainWindow que esconderá o Window e poderá proporcionar o evento Show do Window
        public EsqueceuSenha esquecido { get; set; }
        //Cria o Command para poder executar, presente nos botãos de Minimizar e Retornar ao Menu de Login
        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        //Comando do Botão que retornará ao Menu de Login
        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            esquecido.frm2.Show();
            esquecido.Close();
            SystemCommands.CloseWindow(this);
        }
        //Comando que minimiza a tela
        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void Pergunta1Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Pergunta1Text.SelectionStart = 0;
        }

        private void Pergunta2Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Pergunta2Text.SelectionStart = 0;
        }

        private void Pergunta3Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Pergunta3Text.SelectionStart = 0;
        }

        private void Resp3Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Resp3Text.SelectionStart = 0;
        }

        private void Resp2Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Resp2Text.SelectionStart = 0;
        }

        private void Resp1Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Resp1Text.SelectionStart = 0;
        }

        private void ContinuaButton_Click(object sender, RoutedEventArgs e)
        {
            if (Resp1Text.Text.Trim() != "" && Resp2Text.Text.Trim() != "" && Resp3Text.Text.Trim() != "")
            {
                Banco.conn.Open();
                //Seleciona a Data de Nascimento pelo usuário
                Banco.ExecSelect("SELECT * FROM usuariorecuperacao WHERE Email='"+email+"' and Resposta1 = '" + Resp1Text.Text + "' and Resposta2='" + Resp2Text.Text + "' and Resposta3='" + Resp3Text.Text + "'");
                if (Banco.leitor.Read())
                {
                    //Abre a pagina do Cadastro escondendo a outra
                    Banco.leitor.Close();
                    Banco.conn.Close();
                    this.Visibility = Visibility.Collapsed;
                    EsqueceuSenhaFinal esquecifinal = new EsqueceuSenhaFinal();
                    esquecifinal.Show();
                    esquecifinal.esquecidofinal = this;
                }
                else
                {
                    MessageBox.Show("Dados não compatíveis com o que foi salvo");
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }

            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios,preencha-os!");
            }
        }


    }
}
