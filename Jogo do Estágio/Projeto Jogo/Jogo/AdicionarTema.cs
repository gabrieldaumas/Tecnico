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
using WMPLib;

namespace Jogo
{
    public partial class AdicionarTema : Form
    {
        public Form VoltaSecret { get; set; }
        public static List<string> palavras;
        public AdicionarTema()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (palavra1.Text.Trim() != "" && palavra2.Text.Trim() != "" && palavra3.Text.Trim() != "" && palavra4.Text.Trim() != "" && palavra5.Text.Trim() != "" && palavra6.Text.Trim() != "" && palavra7.Text.Trim() != "" && palavra8.Text.Trim() != "" && palavra9.Text.Trim() != "" && palavra10.Text.Trim() != "" && Tema.Text.Trim() != "" && frase.Text.Trim() != "")
            {
                bool temanexiste = true;
                palavras = new List<string>() { palavra1.Text, palavra2.Text, palavra3.Text, palavra4.Text, palavra5.Text, palavra6.Text, palavra7.Text, palavra8.Text, palavra9.Text, palavra10.Text };
                MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
                MySqlCommand comando;
                conexao.Open();
                comando = new MySqlCommand("SELECT DISTINCT(palavra.tema) FROM palavra,frase_tag where frase_tag.tema = palavra.tema", conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    if (leitor.GetString(0) == Tema.Text)
                    {
                        temanexiste = false;
                        MessageBox.Show("Tema já cadastrado");
                        break;
                    }
                    else
                    {
                        temanexiste = true;
                    }
                }
                leitor.Close();
                if (temanexiste)
                {
                    for (int i = 0; i < palavras.Count(); i++)
                    {
                        comando = new MySqlCommand("INSERT INTO `palavra` (palavra,tema) VALUES ('" + palavras[i] + "','" + Tema.Text + "')", conexao);
                        comando.ExecuteNonQuery();
                    }
                    comando = new MySqlCommand("INSERT INTO `frase_tag` (frase,tema) VALUES ('" + frase.Text + "','" + Tema.Text + "')", conexao);
                    comando.ExecuteNonQuery();
                    palavra1.Text = null;
                    palavra2.Text = null;
                    palavra3.Text = null;
                    palavra4.Text = null;
                    palavra5.Text = null;
                    palavra6.Text = null;
                    palavra7.Text = null;
                    palavra8.Text = null;
                    palavra9.Text = null;
                    palavra10.Text = null;
                    Tema.Text = null;
                    frase.Text = null;
                    MessageBox.Show("Gravado com sucesso!");
                }
                conexao.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VoltaSecret.Show();
            this.Close();
        }
    }
}
