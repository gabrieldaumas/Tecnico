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
    public partial class Menu2 : Form
    {
        public static Boolean rima1 = false;
        public static Boolean rima2 = false;
        public static Boolean rima3 = false;
        public static String tema1 = "";
        public static String tema2 = "";
        public static String tema3 = "";
        public Form VoltaMenu { get; set; }
        public Menu2()
        {

            InitializeComponent();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCT frase_tag.tema FROM frase_tag, palavra WHERE frase_tag.tema = palavra.tema", conexao);
            conexao.Open();
            MySqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                comboBox1.Items.Add(leitor.GetString(0));
            }
            leitor.Close();
            conexao.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.SelectedItem = "";
            rima1 = false;
            tema1 = "";
            if (comboBox1.SelectedItem.ToString() == "Rima")
            {
                MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
                MySqlCommand comando = new MySqlCommand("SELECT DISTINCT frase_tag.tema FROM frase_tag, palavra WHERE frase_tag.tema = palavra.tema", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    comboBox2.Items.Add(leitor.GetString(0));
                }
                leitor.Close();
                conexao.Close();
                rima1 = true;
                tema1 = "Rima";
            }
            else
            {
                MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
                MySqlCommand comando = new MySqlCommand("SELECT DISTINCT frase_tag.tema FROM frase_tag, palavra WHERE frase_tag.tema = palavra.tema and palavra.tema != '"+ comboBox1.SelectedItem.ToString() + "' and frase_tag.tema != '" + comboBox1.SelectedItem.ToString() + "'", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    comboBox2.Items.Add(leitor.GetString(0));
                }
                leitor.Close();
                conexao.Close();
                rima1 = false;
                tema1 = comboBox1.SelectedItem.ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            rima3 = false;
            tema3 = "";
            if (comboBox3.SelectedItem.ToString() == "Rima")
            {
                rima3 = true;
                tema3 = "Rima";
            }
            else
            {
                rima3 = false;
                tema3 = comboBox3.SelectedItem.ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
            MySqlCommand comando;
            comboBox3.Items.Clear();
            comboBox3.SelectedItem = "";
            rima2 = false;
            tema2 = "";
            if (comboBox2.SelectedItem.ToString() == "Rima")
            {
                comando = new MySqlCommand("SELECT DISTINCT frase_tag.tema FROM frase_tag, palavra WHERE frase_tag.tema = palavra.tema", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    comboBox3.Items.Add(leitor.GetString(0));
                }
                leitor.Close();
                conexao.Close();
                rima2 = true;
                tema2 = "Rima";
            }
            else
            {
                comando = null;
                if (rima1)
                {
                    comando = new MySqlCommand("SELECT DISTINCT frase_tag.tema FROM frase_tag, palavra WHERE frase_tag.tema = palavra.tema and palavra.tema != '" + comboBox2.SelectedItem.ToString() + "' and frase_tag.tema != '" + comboBox2.SelectedItem.ToString() + "'", conexao);
                }
                else
                {
                    comando = new MySqlCommand("SELECT DISTINCT frase_tag.tema FROM frase_tag, palavra WHERE frase_tag.tema = palavra.tema and palavra.tema != '" + comboBox2.SelectedItem.ToString() + "' and frase_tag.tema != '" + comboBox2.SelectedItem.ToString() + "'and palavra.tema != '" + comboBox1.SelectedItem.ToString() + "' and frase_tag.tema != '" + comboBox1.SelectedItem.ToString() + "'", conexao);
                }

                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    comboBox3.Items.Add(leitor.GetString(0));
                }
                leitor.Close();
                conexao.Close();
                rima2 = false;
                tema2 = comboBox2.SelectedItem.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                Jogo.Menu.wplayer.controls.stop();
                this.Hide();
                Fase1 m = new Fase1();
                m.Show();
                m.VoltaMenu = this;
            }
            else
            {
                MessageBox.Show("Selecione temas para todas as fases!");
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            VoltaMenu.Show();
            this.Close();
        }
    }
}
