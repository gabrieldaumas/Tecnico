using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo
{
    public partial class Placar : Form
    {
        public static int codigoaluno = 0;
        public Placar()
        {
            InitializeComponent();

        }

        private void Placar_Load(object sender, EventArgs e)
        {
            codigoaluno = Dados.codigoaluno;
            MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
            MySqlCommand comando = new MySqlCommand("SELECT nome,pontuacao FROM topgeral ORDER BY pontuacao DESC LIMIT 5", conexao);
            conexao.Open();
            MySqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                if (LugarNome1.Text.Trim() == "" && LugarPonto1.Text.Trim() == "")
                {
                    LugarNome1.Text = leitor.GetString(0);
                    LugarPonto1.Text = leitor.GetString(1);
                }
                else if (LugarNome2.Text.Trim() == "" && LugarPonto2.Text.Trim() == "")
                {
                    LugarNome2.Text = leitor.GetString(0);
                    LugarPonto2.Text = leitor.GetString(1);
                }
                else if (LugarNome3.Text.Trim() == "" && LugarPonto3.Text.Trim() == "")
                {
                    LugarNome3.Text = leitor.GetString(0);
                    LugarPonto3.Text = leitor.GetString(1);
                }
                else if (LugarNome4.Text.Trim() == "" && LugarPonto4.Text.Trim() == "")
                {
                    LugarNome4.Text = leitor.GetString(0);
                    LugarPonto4.Text = leitor.GetString(1);
                }
                else if (LugarNome5.Text.Trim() == "" && LugarPonto5.Text.Trim() == "")
                {
                    LugarNome5.Text = leitor.GetString(0);
                    LugarPonto5.Text = leitor.GetString(1);
                }
            }
            leitor.Close();
            comando = new MySqlCommand("SELECT * FROM topgeral ORDER BY pontuacao DESC", conexao);
            int count = 1;
            leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                if (leitor.GetString(0) != codigoaluno.ToString())
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            LocPosicao.Text = count.ToString();
            leitor.Close();
            comando = new MySqlCommand("SELECT nome,pontuacao FROM topgeral WHERE codigo = '"+codigoaluno.ToString()+"'", conexao);
            leitor = comando.ExecuteReader();
            if (leitor.Read())
            {
                LocNome.Text = leitor.GetString(0);
                LocPontos.Text = leitor.GetString(1);
            }
            leitor.Close();
            conexao.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
