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
    public partial class CadastroIntro : Window
    {
        public CadastroIntro()
        {
            InitializeComponent();
        }
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
            //Abre a pagina do Cadastro escondendo a outra
            this.Visibility = Visibility.Collapsed;
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
            cadastro.CadastroIntro = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

    }
}
