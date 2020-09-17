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
    public partial class AdicionarPalavra : Form
    {
        public Form VoltaSecret { get; set; }
        public static List<string> palavras,palavraserradas,tags,checkpalavras;
        public AdicionarPalavra()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VoltaSecret.Show();
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Selecione um Tema";
            tag.SelectedItem = "Selecione uma Rima";
            DoubleBuffered = true;
            MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
            MySqlCommand comando;
            conexao.Open();
            comando = new MySqlCommand("SELECT DISTINCT(palavra.tema) FROM palavra,frase_tag where frase_tag.tema = palavra.tema", conexao);
            MySqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                comboBox1.Items.Add(leitor.GetString(0));
            }
            leitor.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tags = new List<string>();
            tags.Clear();
            if (comboBox1.SelectedItem.ToString() == "Rima")
            {
                tag.Visible = true;
                label2.Visible = true;
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
                label2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool temrepetidas = false;
            if (comboBox1.SelectedItem.ToString() != "Selecione um Tema")
            {
                palavras = new List<string>() { palavra1.Text, palavra2.Text, palavra3.Text, palavra4.Text, palavra5.Text, palavra6.Text, palavra7.Text, palavra8.Text, palavra9.Text, palavra10.Text };
                checkpalavras = new List<string>();
                for (int i = 0; i < palavras.Count; i++)
                {
                    if (checkpalavras.Contains(palavras[i]))
                    {
                        temrepetidas = true;
                        break;
                    }
                    else
                    {
                        checkpalavras.Add(palavras[i]);
                    }
                }
                if (temrepetidas)
                {
                    MessageBox.Show("Existem palavras repetidas para adicionar.");
                }
                else
                {
                    palavraserradas = new List<string>();
                    MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
                    MySqlCommand comando;
                    MySqlDataReader leitor;
                    conexao.Open();
                    for (int i = 0; i < palavras.Count(); i++)
                    {
                        comando = new MySqlCommand("SELECT palavra FROM palavra WHERE palavra ='" + palavras[i] + "' AND tema='" + comboBox1.SelectedItem.ToString() + "'", conexao);
                        leitor = comando.ExecuteReader();
                        if (leitor.Read())
                        {
                            palavraserradas.Add(leitor.GetString(0));
                        }
                        leitor.Close();
                    }
                    string frase = "";
                    if (palavraserradas.Count() == 0)
                    {
                        for (int i = 0; i < palavras.Count(); i++)
                        {
                            if (comboBox1.SelectedItem.ToString() == "Rima")
                            {
                                comando = new MySqlCommand("INSERT INTO `palavra`  VALUES ('" + palavras[i] + "','" + tags[tag.SelectedIndex - 1] + "','" + comboBox1.SelectedItem.ToString() + "')", conexao);
                                comando.ExecuteNonQuery();
                            }
                            else
                            {
                                comando = new MySqlCommand("INSERT INTO `palavra` (palavra,tema) VALUES ('" + palavras[i] + "','" + comboBox1.SelectedItem.ToString() + "')", conexao);
                                comando.ExecuteNonQuery();
                            }
                        }
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
                        comboBox1.SelectedIndex = 0;
                        tag.SelectedIndex = 0;
                        tag.Items.Clear();
                        palavraserradas.Clear();
                        palavras.Clear();
                        tag.Visible = false;
                        label2.Visible = false;
                        MessageBox.Show("Gravado com sucesso!");
                    }
                    else
                    {
                        for (int i = 0; i < palavraserradas.Count(); i++)
                        {
                            frase += "\n" + palavraserradas[i] + " já está presente no Banco de Dados \n";
                        }
                        MessageBox.Show(frase);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um Tema");
            }
               
        }
    }
}
