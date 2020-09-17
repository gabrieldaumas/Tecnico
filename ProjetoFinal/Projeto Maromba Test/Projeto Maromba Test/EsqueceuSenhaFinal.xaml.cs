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
    public partial class EsqueceuSenhaFinal: Window
    {
        public EsqueceuSenhaFinal()
        {
            InitializeComponent();
        }
        public static string emails = "";
        public Boolean email = false,senha =false;
        //Cria um objeto relacionado ao MainWindow que esconderá o Window e poderá proporcionar o evento Show do Window
        public EsqueceuSenhaPerguntas esquecidofinal { get; set; }
        //Cria o Command para poder executar, presente nos botãos de Minimizar e Retornar ao Menu de Login
        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        //Comando do Botão que retornará ao Menu de Login
        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            esquecidofinal.esquecido.frm2.Show();
            esquecidofinal.esquecido.Close();
            esquecidofinal.Close();
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
            if (ConfSenhaText.Password.Trim() != "" &&  SenhaText.Password.Trim() != "")
            {
                if (senha)
                {
                    Banco.conn.Open();
                    //Seleciona a Data de Nascimento pelo usuário
                    Banco.ExecNonSelect("UPDATE usuariologin Set Senha='" + SenhaText.Password + "' WHERE Email = '" + EsqueceuSenhaPerguntas.email + "' ");
                    MessageBox.Show("Atualizado com sucesso!");
                    esquecidofinal.esquecido.frm2.Show();
                    esquecidofinal.Close();
                    esquecidofinal.esquecido.Close();
                    SystemCommands.CloseWindow(this);
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
                else
                {
                    MessageBox.Show("Senha inválida!");
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios,preencha-os!");
            }
        }


        private void ConfSenhaText_LostFocus(object sender, RoutedEventArgs e)
        {
            //Checa se o Senha é igual ao da confirmação
            if (SenhaText.Password == ConfSenhaText.Password)
            {
                //Checa se o senha tem 8 ou mais caracteres
                if (SenhaText.Password.Count() > 7)
                {
                    //Checa se o senha tem 10 ou mais caracteres
                    if (SenhaText.Password.Count() > 9)
                    {
                        senha = true;
                    }
                    else
                    {
                        senha = true;
                    }
                }
                else
                {
                    senha = false;
                }
            }
            else
            {
                senha = false;
            }
        }

        private void SenhaText_LostFocus(object sender, RoutedEventArgs e)
        {
            //Checa se o Senha é igual ao da confirmação
            if (SenhaText.Password == ConfSenhaText.Password)
            {
                //Checa se o senha tem 8 ou mais caracteres
                if (SenhaText.Password.Count() > 7)
                {
                    //Checa se o senha tem 10 ou mais caracteres
                    if (SenhaText.Password.Count() > 9)
                    {
                        senha = true;
                    }
                    else
                    {
                        senha = true;
                    }
                }
                else
                {
                    senha = false;
                }
            }
            else
            {
                senha = false;
            }
        }


    }
}
