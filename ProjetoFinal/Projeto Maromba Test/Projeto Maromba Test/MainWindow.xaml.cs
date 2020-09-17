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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Projeto_Maromba_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Email = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Checa se há algum campo vazio
            if (SenhaText.Password.Trim() != "" && EmailText.Text.Trim() != "")
            {
                //Checa se o email é válido,ou seja, se está no formato example@example.qualquercoisa(...)
                if (Regex.IsMatch(EmailText.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT * FROM usuariologin WHERE Email='" + EmailText.Text + "' and Senha='"+SenhaText.Password+"'");
                    if (Banco.leitor.Read())
                    {
                        Email = EmailText.Text;
                        Banco.leitor.Close();
                        Banco.conn.Close();
                        //Abrir o inicio do programa
                        InicioMaromba inicio = new InicioMaromba();
                        this.Close();
                        inicio.Show();

                    }
                    else
                    {
                        //Informa que os dados não conferem
                        MessageBox.Show("Dados não confere com o Banco de Dados!");
                        Banco.leitor.Close();
                        Banco.conn.Close();
                    }

                }
                else
                {
                    //Informa que o email é inválido
                    MessageBox.Show("Email inválido!");

                }
            }
            else
            {
                //Interage com o usuário avisando que tem campos vazios
                MessageBox.Show("Preencha todos os campos","Não foi possivel completar o login");
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void SenhaLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Abre a pagina de Introdução do Cadastro escondendo a outra
            this.Visibility = Visibility.Collapsed;
            EsqueceuSenha window = new EsqueceuSenha();
            window.Show();
            window.frm2 = this;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Abre a pagina de Introdução do Cadastro escondendo a outra
            this.Visibility = Visibility.Collapsed;
            CadastroIntro window = new CadastroIntro();
            window.Show();
            window.frm2 = this;
        }

        private void CadastroBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            //Muda a decoração do texto para nada
            CadastroBlock.TextDecorations = null;
        }

        private void CadastroBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            //Muda a decoração do texto para sublinhado
            CadastroBlock.TextDecorations = TextDecorations.Underline;
        }

        private void SenhaBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            //Muda a decoração do texto para nada
            SenhaBlock.TextDecorations = null;
        }

        private void SenhaBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            //Muda a decoração do texto para sublinhado
            SenhaBlock.TextDecorations = TextDecorations.Underline;
        }

        private void EmailText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EmailText_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            EmailText.SelectionStart = 0;
        }

    }
}
