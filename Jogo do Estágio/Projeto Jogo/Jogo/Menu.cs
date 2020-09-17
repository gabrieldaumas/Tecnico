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
    public partial class Menu : Form
    {
        public static WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            //Põe a música do LBP3 como backgroundmusic
            wplayer.URL = @"Som/song.mp3";
            //Inicia o wplayer para musica rodar em background
            wplayer.controls.play();
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
            if (e.Control && e.KeyCode == Keys.T)
            {
                this.Hide();
                Secret m = new Secret();
                m.Show();
                m.VoltaMenu = this;
            }
        }

    }
}
