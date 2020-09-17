using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Jogo
{
    public partial class Dados : Form
    {
        public static int pontuacao = 0,codigoaluno=0;
        public Dados()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pontuacao = Fase1.pontuacao + Fase2.pontuacao + Fase3.pontuacao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
                MySqlCommand comando = new MySqlCommand("SELECT COUNT(*) FROM topgeral", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                if (leitor.Read())
                {
                    codigoaluno = int.Parse(leitor.GetString(0));
                    codigoaluno++;
                }
                leitor.Close();
                comando = new MySqlCommand("INSERT INTO `topgeral` VALUES ('" + codigoaluno.ToString() + "','" + textBox1.Text + "','" + pontuacao + "')", conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
                this.Visible = false;
                Placar next = new Placar();
                next.Show();
            }
          
        }
    }
}
