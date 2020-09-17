using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Jogo
{
    public partial class Secret : Form
    {
        public Form VoltaMenu { get; set; }
        public Secret()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Menu2 m = new Menu2();
            m.Show();
            m.VoltaMenu = this;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdicionarTema m = new AdicionarTema();
            m.Show();
            m.VoltaSecret = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdicionarFrase m = new AdicionarFrase();
            m.Show();
            m.VoltaSecret = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdicionarPalavra m = new AdicionarPalavra();
            m.Show();
            m.VoltaSecret = this;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            VoltaMenu.Show();
            this.Close();
        }
    }
}
