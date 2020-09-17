using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class EsqueceuSenha: Window
    {
        public EsqueceuSenha()
        {
            InitializeComponent();
        }
        public static string emails = "";
        public Boolean email = false;
        //Cria um objeto relacionado ao MainWindow que esconderá o Window e poderá proporcionar o evento Show do Window
        public MainWindow frm2 { get; set; }
        //Cria o Command para poder executar, presente nos botãos de Minimizar e Retornar ao Menu de Login
        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        //Comando do Botão que retornará ao Menu de Login
        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            frm2.Show();
            SystemCommands.CloseWindow(this);
        }
        //Comando que minimiza a tela
        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }
        //Click do Botão que abre a tela cadastro após a introdução
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EmailText.Text.Trim() != "" && DataNascText.Text.Trim() != "" && NomeText.Text.Trim() != "")
            {
                if (email)
                {
                    Banco.conn.Open();
                    //Seleciona a Data de Nascimento pelo usuário
                    Banco.ExecSelect("SELECT DataNascimento FROM usuarioinfo WHERE Email = '" + EmailText.Text + "' and DataNascimento='" + DataNascText.Text + "' and SobreNome='" + NomeText.Text + "'");
                    if (Banco.leitor.Read())
                    {
                        Banco.leitor.Close();
                        Banco.conn.Close();
                        //Abre a pagina do Cadastro escondendo a outra
                        this.Visibility = Visibility.Collapsed;
                        EsqueceuSenhaPerguntas esqueci = new EsqueceuSenhaPerguntas();
                        esqueci.Show();
                        esqueci.esquecido = this;
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
                    MessageBox.Show("Email Inválido!");
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios,preencha-os!");
            }
        }

        private void NomeText_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            NomeText.SelectionStart = 0;
        }

        private void EmailText_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            EmailText.SelectionStart = 0;
        }

        private void EmailText_Leave(object sender, TextChangedEventArgs e)
        {
            //Checa se o email é válido,ou seja, se está no formato example@example.qualquercoisa(...)
            if (Regex.IsMatch(EmailText.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                email = true;
                emails = EmailText.Text;
            }
            else
            {
                //Muda email para falso
                email = false;
            }

        }


    }
}
