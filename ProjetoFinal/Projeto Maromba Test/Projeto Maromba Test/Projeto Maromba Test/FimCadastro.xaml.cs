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
        public FimCadastro()
        {
            InitializeComponent();
        }
        public Cadastro fim { get; set; }
        //Pega o email para checar no bd
        public string email;
    }
}
