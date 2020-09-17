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
using MySql.Data.MySqlClient;

namespace Jogo
{
    public partial class AdicionarFrase : Form
    {
        public Form VoltaSecret { get; set; }
        public static List<string> frases, fraseserradas, tags;
        public AdicionarFrase()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
            MySqlCommand comando;
            conexao.Open();
            comando = new MySqlCommand("SELECT DISTINCT(palavra.tema) FROM palavra,frase_tag where frase_tag.tema = palavra.tema", conexao);
            MySqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                temabox.Items.Add(leitor.GetString(0));
            }
            leitor.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            VoltaSecret.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (temabox.SelectedItem.ToString() != "Selecione um Tema")
            {
                frases = new List<string>() { frase1.Text, frase2.Text, frase3.Text };
                fraseserradas = new List<string>();
                MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
                MySqlCommand comando;
                MySqlDataReader leitor;
                conexao.Open();
                for (int i = 0; i < frases.Count(); i++)
                {
                    comando = new MySqlCommand("SELECT frase FROM frase_tag WHERE frase ='" + frases[i] + "' AND tema='" + temabox.SelectedItem.ToString() + "'", conexao);
                    leitor = comando.ExecuteReader();
                    if (leitor.Read())
                    {
                        fraseserradas.Add(leitor.GetString(0));
                    }
                    leitor.Close();
                }
                string frase = "";
                if (fraseserradas.Count() == 0)
                {
                    for (int i = 0; i < frases.Count(); i++)
                    {
                        if (temabox.SelectedItem.ToString() == "Rima")
                        {
                            comando = new MySqlCommand("INSERT INTO `frase_tag`  VALUES ('" + frases[i] + "','" + tags[tag.SelectedIndex - 1] + "','" + temabox.SelectedItem.ToString() + "')", conexao);
                            comando.ExecuteNonQuery();
                        }
                        else
                        {
                            comando = new MySqlCommand("INSERT INTO `frase_tag` (frase,tema) VALUES ('" + frases[i] + "','" + temabox.SelectedItem.ToString() + "')", conexao);
                            comando.ExecuteNonQuery();
                        }
                    }

                    frase1.Text = null;
                    frase2.Text = null;
                    frase3.Text = null;
                    temabox.SelectedIndex = 0;
                    tag.SelectedItem = 0;
                    tag.Items.Clear();
                    fraseserradas.Clear();
                    frases.Clear();
                    tag.Visible = false;
                    label5.Visible = false;
                    MessageBox.Show("Gravado com sucesso!");
                }
                else
                {
                    for (int i = 0; i < fraseserradas.Count(); i++)
                    {
                        frase += "\n" + fraseserradas[i] + " já está presente no Banco de Dados \n";
                    }
                    MessageBox.Show(frase);
                }
            }
            else
            {
                MessageBox.Show("Selecione um tema!");
            }
        }

        private void temabox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tags = new List<string>();
            tags.Clear();
            if (temabox.SelectedItem.ToString() == "Rima")
            {
                tag.Visible = true;
                label5.Visible = true;
                MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
                MySqlCommand comando;
                conexao.Open();
                comando = new MySqlCommand("SELECT DISTINCT(palavra.tag) FROM palavra,frase_tag where frase_tag.tema = palavra.tema and palavra.tema = 'Rima'", conexao);
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    tags.Add(leitor.GetString(0));
                }
                leitor.Close();
                for (int i = 0; i < tags.Count(); i++)
                {
                    comando = new MySqlCommand("SELECT DISTINCT palavra.palavra FROM palavra where palavra.tag = '" + tags[i] + "' and palavra.tema = 'Rima' LIMIT 1", conexao);
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        tag.Items.Add(leitor.GetString(0));
                    }
                    leitor.Close();
                }
            }
            else
            {
                tag.Visible = false;
                label5.Visible = false;
            }
        }
    }
}
