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
using WMPLib;
using System.Runtime.InteropServices;

namespace Jogo
{
    public partial class Fase1 : Form
    {
        public static int n, t, mission_res, interval = 30, time = 0, label0 = 0,countertodas = 0,counter = 0,pontuacao=0;
        public static Boolean boolei = false, rima1 = false;
        public static string tema1 = "";
        public static Timer[] timers;
        public static Label[] labels;
        public static List<string> idcertas = new List<string>();
        public static List<string> palavras = new List<string>();
        public static List<string> id = new List<string>();
        public static List<string> iderradas = new List<string>();
        public static List<string> palavraserradas = new List<string>();
        public static List<string> tags = new List<string>();
        public static List<string> palavrascertas = new List<string>();
        public static WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        public static WindowsMediaPlayer wplayer2 = new WindowsMediaPlayer();
        public static WindowsMediaPlayer shotplayer = new WindowsMediaPlayer();

        public Form VoltaMenu { get; set; }
        public Fase1()
        {

            InitializeComponent();
            //Inicia timers que coordenam funções específicas
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Pega valor da rima selecionada e do tema selecionado no Menu 2 para a fase 1
            rima1 = Jogo.Menu2.rima1;
            tema1 = Jogo.Menu2.tema1;
            DoubleBuffered = true;
            //Coloca o button na posição que fica adequada
            ProximaFaseButton.Location = new Point(420, 408);
            //Põe a música do LBP3 como backgroundmusic
            wplayer.URL = @"Som/west.wma";
            //Inicia o wplayer para musica rodar em background
            wplayer.controls.play();
            //Bota o Intervalo para 30 segundos
            IntervaloLabel.Text = interval.ToString();
            if (rima1)
            {
                //String de conexão com BD
                MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
                //Query que pega a tag referente à rima
                MySqlCommand comando = new MySqlCommand("SELECT distinct tag FROM palavra WHERE tema = 'Rima' ORDER BY RAND()", conexao);
                conexao.Open();
                MySqlDataReader leitor = comando.ExecuteReader();
                int tag = 0;
                if (leitor.Read())
                {
                    tag = int.Parse(leitor.GetString(0));
                }
                leitor.Close();
                Random randome = new Random();
                iDFraseLabel.Text = tag.ToString();
                //Query para pegar palavras erradas
                comando = new MySqlCommand("SELECT * FROM palavra where tag!='" + iDFraseLabel.Text + "' and tema = 'Rima' ORDER BY RAND() LIMIT 10", conexao);
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    palavraserradas.Add(leitor.GetString(0));
                    iderradas.Add(leitor.GetString(1));
                }
                leitor.Close();
                //Query para pegar palavras certas
                comando = new MySqlCommand("SELECT * FROM palavra Where tag='" + iDFraseLabel.Text + "'  and tema = 'Rima' ORDER BY RAND() LIMIT 5", conexao);
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    palavrascertas.Add(leitor.GetString(0));
                    idcertas.Add(leitor.GetString(1));
                }
                leitor.Close();
                comando = new MySqlCommand("SELECT * FROM frase_tag where tag='" + iDFraseLabel.Text + "' and tema = 'Rima' ORDER BY RAND()", conexao);
                leitor = comando.ExecuteReader();
                if (leitor.Read())
                {
                    FraseRimaLabel.Text = leitor.GetString(0);
                }
                leitor.Close();
                int j = 0;
                for (int i = 0; i < palavrascertas.Count; i++)
                {
                    //Adiciona cada palavra certa ou errada e as torna maiúsculas
                    palavras.Add(palavraserradas[j].ToUpper());
                    id.Add(iderradas[j]);
                    j++;
                    palavras.Add(palavrascertas[i].ToUpper());
                    id.Add(idcertas[i]);
                    palavras.Add(palavraserradas[j].ToUpper());
                    id.Add(iderradas[j]);
                    j++;

                }
            }
            else
            {
                MySqlConnection conexao = new MySqlConnection("Persist Security Info = False; server=localhost; database=rimas;uid=root");
                MySqlCommand comando;
                conexao.Open();
                MySqlDataReader leitor;
                Random randome = new Random();
                iDFraseLabel.Text = tema1;
                //Query que pega palavras erradas
                comando = new MySqlCommand("SELECT * FROM palavra where tema != '" +tema1+ "' ORDER BY RAND() LIMIT 10", conexao);
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    palavraserradas.Add(leitor.GetString(0));
                    iderradas.Add(leitor.GetString(2));
                }
                leitor.Close();
                //Query que pega palavras certas
                comando = new MySqlCommand("SELECT * FROM palavra Where tema = '" + tema1 + "' ORDER BY RAND() LIMIT 5", conexao);
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    palavrascertas.Add(leitor.GetString(0));
                    idcertas.Add(leitor.GetString(2));
                }
                leitor.Close();
                comando = new MySqlCommand("SELECT * FROM frase_tag where tema = '" + tema1 + "' ORDER BY RAND()", conexao);
                leitor = comando.ExecuteReader();
                if (leitor.Read())
                {
                    FraseRimaLabel.Text = leitor.GetString(0);
                }
                leitor.Close();
                int j = 0;
                for (int i = 0; i < palavrascertas.Count; i++)
                {
                    //Adiciona cada palavra certa ou errada e as torna maiúsculas
                    palavras.Add(palavraserradas[j].ToUpper());
                    id.Add(iderradas[j]);
                    j++;
                    palavras.Add(palavrascertas[i].ToUpper());
                    id.Add(idcertas[i]);
                    palavras.Add(palavraserradas[j].ToUpper());
                    id.Add(iderradas[j]);
                    j++;

                }
            }
            
            n = palavras.Count;
            labels = new Label[n];
            timers = new Timer[n];
            List<int> TopLoc = new List<int>();
            List<int> LeftLoc = new List<int>();
            Random random2 = new Random();
            int Top = 70;
            for (int i = 0; i < n; i++)
            {
                //Nessa parte, é definido a posição das labels dentro do jogo e são definidas suas características
                labels[i] = new Label();
                labels[i].AutoSize = true;
                Font font = new Font("Western Bang Bang", 20);
                labels[i].Font = font;
                labels[i].ForeColor = Color.White;
                labels[i].Name = "label" + i;
                labels[i].Click += labels0_Click;
                labels[i].LocationChanged += labels_LocationChanged;
                labels[i].BackColor = Color.Transparent;
                labels[i].Tag = id[i];
                labels[i].Text = palavras[i];
                labels[i].Top = Top;
                Top += 30;
                int leftmin = -800;
                int leftmax = -10;
                bool check2 = true;
                int randomLeft = random2.Next(leftmin, leftmax);
                while (check2)
                {
                        if (LeftLoc.Contains(randomLeft))
                        {
                            check2 = true;
                            randomLeft = random2.Next(leftmin, leftmax);
                        }
                        else
                        {
                            if (randomLeft % 25 == 0)
                            {
                                LeftLoc.Add(randomLeft);
                                check2 = false;
                            }
                            else
                            {
                                check2 = true;
                                randomLeft = random2.Next(leftmin, leftmax);
                            }
                        }
                    }
                labels[i].Left = LeftLoc[i];
            }

           for(int i = 0; i < n; i++)
            {
                this.Controls.Add(labels[i]);
            }
           

        }

        private void labels_LocationChanged(object sender, EventArgs e)
        {
            //quando as labels atingem a distância limite, elas voltam para o início
            if((sender as Label).Left == 1017)
            {
                (sender as Label).Left = -10;
            }
        }

        private void Form1_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void labels0_Click(object sender, EventArgs e)
        {
            //Quando clica na label, sai som de tiro
            shotplayer.URL=@"Som/west_shot.mp3";
            shotplayer.controls.play();
            if (interval != 0)
            {
                if ((sender as Label).Name != "-1")
                {
                    if ((sender as Label).Tag.ToString() == iDFraseLabel.Text)
                    {
                        //Dá 10 pontos por acertar palavra
                        ContadorLabel.Text = (int.Parse(ContadorLabel.Text) + 10).ToString();
                        (sender as Label).ForeColor = Color.Green;
                        counter++;
                    }
                    else
                    {
                        //Tira 5 pontos por errar palavra
                        ContadorLabel.Text = (int.Parse(ContadorLabel.Text) - 5).ToString();
                        (sender as Label).Text = "Errou";
                        (sender as Label).ForeColor = Color.Red;
                    }
                (sender as Label).Name = "-1";
                    countertodas++;
                }

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //A cada Tick do timer, a label se move para a direita em uma unidade
            time = 0;
            while(time != palavras.Count)
            {
                labels[time].Location = new Point(labels[time].Location.X + 1, labels[time].Location.Y);
                time++;     
            }
                
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if(counter != palavrascertas.Count())
            {
                if (interval == 0)
                {
                    //Pontuação maior que 110 = vitória
                    if (int.Parse(ContadorLabel.Text) > 110)
                    {
                        //Som de vitória e imagem "Próxima Fase"
                        wplayer2.URL = @"Som\gg.mp3";
                        ProximaFaseButton.Image = Image.FromFile(@"Imgs\Próxima Fase-1.png");
                        ProximaFaseButton.Location = new Point(306, 418);
                        mission_res = 0;
                    }
                    else
                    {
                        //Som de perda e imagem "Tente Novamente"
                        wplayer2.URL = @"Som\noob.mp3";
                        ProximaFaseButton.Image = Image.FromFile(@"Imgs\Tente Novamente-1.png");
                        ProximaFaseButton.Location = new Point(292, 418);
                        mission_res = 1;
                    }
                    for (int jujuba = 0; jujuba < n; jujuba++)
                    {
                        labels[jujuba].Visible = false;
                        labels[jujuba].Update();
                    }
                    timer1.Stop();
                    timer2.Stop();
                    boolei = true;
                    if(int.Parse(ContadorLabel.Text) > 110)
                    {
                        //Imagem "Próxima Fase"
                        ProximaFaseButton.Image = Image.FromFile(@"Imgs\Próxima Fase-1.png");
                    }
                    else
                    {
                        //Imagem "Tente Novamente"
                        ProximaFaseButton.Image = Image.FromFile(@"Imgs\Tente Novamente-1.png");
                    }
                }
                else
                {
                    interval--;
                    IntervaloLabel.Text = interval.ToString();
                    boolei = false;
                }
            }
            else
            {
                timer1.Stop();
                for (int jujuba = 0; jujuba < n; jujuba++)
                {
                    labels[jujuba].Visible = false;
                    labels[jujuba].Update();
                }
                if((countertodas - counter)<= 6)
                {
                    int soma = int.Parse(IntervaloLabel.Text) * 2;
                    ContadorLabel.Text = (soma + int.Parse(ContadorLabel.Text)).ToString();
                }
                timer2.Stop();
                boolei = true;
                if (int.Parse(ContadorLabel.Text) > 110)
                {
                    //Som de vitória e imagem "Próxima Fase"
                    wplayer2.URL = @"Som\gg.mp3";
                    ProximaFaseButton.Image = Image.FromFile(@"Imgs\Próxima Fase-1.png");
                    ProximaFaseButton.Location = new Point(306, 418);
                    mission_res = 0;
                }
                else
                {
                    //Som de perda e imagem "Tente Novamente"
                    wplayer2.URL = @"Som\noob.mp3";
                    ProximaFaseButton.Image = Image.FromFile(@"Imgs\Tente Novamente-1.png");
                    ProximaFaseButton.Location = new Point(292, 418);
                    mission_res = 1;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (boolei)
            {
            if (PontosBox.Left == 494 && PontosBox.Top == 228 && ContadorLabel.Left == 398 && ContadorLabel.Top == 227)
            {
                    ProximaFaseButton.Visible = true;
                    if (wplayer2.playState == WMPPlayState.wmppsStopped)
                {
                        
                        timer3.Stop();
                }
            }
            else
            {
                    if (counter != palavrascertas.Count())
                    {
                        if (interval == 0)
                        {
                            if (PontosBox.Left >= 495)
                            {
                                PontosBox.Left -= 1;
                            }
                            else
                            {
                                if (PontosBox.Top != 228)
                                {
                                    PontosBox.Top -= 2;
                                }
                            }
                            if (ContadorLabel.Left >= 400)
                            {
                                ContadorLabel.Left -= 3;
                                ContadorLabel.Font = new Font(ContadorLabel.Font.FontFamily, ContadorLabel.Font.Size + 0.2f, ContadorLabel.Font.Style);
                            }
                            else
                            {
                                if (ContadorLabel.Top >= 228)
                                {
                                    ContadorLabel.Top -= 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (PontosBox.Left >= 495)
                        {
                            PontosBox.Left -= 1;
                        }
                        else
                        {
                            if (PontosBox.Top != 228)
                            {
                                PontosBox.Top -= 2;
                            }
                        }
                        if (ContadorLabel.Left >= 400)
                        {
                            ContadorLabel.Left -= 3;
                            ContadorLabel.Font = new Font(ContadorLabel.Font.FontFamily, ContadorLabel.Font.Size + 0.2f, ContadorLabel.Font.Style);
                        }
                        else
                        {
                            if (ContadorLabel.Top >= 228)
                            {
                                ContadorLabel.Top -= 1;
                            }
                        }
                }
                }
                }
        }


        private void timer4_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer6_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Caso a fase tenha sida vencida
            if (mission_res==0)
            {
                pontuacao = int.Parse(ContadorLabel.Text);
                this.Visible = false;
                Fase2 next = new Fase2();
                next.Show();
                wplayer.controls.stop();
                
            }
            else
            {
                //Caso não, reinicia o jogo
                Application.Restart();
                
            }


        }

        private void button1_VisibleChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            //VoltaMenu.Show();
            //this.Close();
            //wplayer.controls.stop();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
           
        }

       
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
