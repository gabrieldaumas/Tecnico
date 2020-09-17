using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace Projeto_Maromba_Test
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        public Cadastro()
        {
            InitializeComponent();
        }
        public static string emails = "";
        //Bools pra liberar a gravação dos dados
        public Boolean email = false, senha = false;
        //Cria um objeto relacionado ao CadastroIntro que esconderá o Window e poderá proporcionar o evento Show do Window
        public CadastroIntro CadastroIntro { get; set; }
        //Cria o Command para poder executar, presente nos botãos de Minimizar e Retornar ao Menu de Login
        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        //Comando do Botão que retornará ao Menu de Login
        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            CadastroIntro.frm2.Show();
            CadastroIntro.Close();
            SystemCommands.CloseWindow(this);
        }
        //Comando que minimiza a tela
        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Código do botão que grava dados e gera outros dados
            //Checa se tem algum campo vago
            if (NomeText.Text.Trim() != "" && SobreNomeText.Text.Trim() != "" && DataNascText.Text.Trim() != "" && EmailText.Text.Trim() != "" && ConfEmailText.Text.Trim() != "" && SenhaText.Password.Trim() != "" && ConfSenhaText.Password.Trim() != "" && ToraxText.Text != "" && CinturaText.Text != "" && AbdomenText.Text != "" && QuadrilText.Text != "" && AlturaText.Text != "" && PesoText.Text != "" && Pergunta1Text.Text.Trim() != "" && Pergunta2Text.Text.Trim() != "" && Pergunta3Text.Text.Trim() != "" && Resp1Text.Text.Trim() != "" && Resp2Text.Text.Trim() != "" && Resp3Text.Text.Trim() != "" && AceitoCheck.IsChecked == true)
            {
                //Checa se tem um radiobutton marcado
                if (MascRadio.IsChecked == true || FemRadio.IsChecked == true)
                {
                    //Checa se tem um radiobutton marcado
                    if (SedenRadio.IsChecked == true || LevAtivRadio.IsChecked == true || AtivRadio.IsChecked == true || MuitoAtivRadio.IsChecked == true)
                    {
                        //Checa se tem um radiobutton marcado
                        if (SimRadio.IsChecked == true || NaoRadio.IsChecked == true)
                        {
                                if (QuantoText.Text != "" || _12M20FRadio.IsChecked == true || _15M25FRadio.IsChecked == true || _20M30FRadio.IsChecked == true || _25M35FRadio.IsChecked == true || _30M40FRadio.IsChecked == true || _35M45FRadio.IsChecked == true || _8M15FRadio.IsChecked == true)
                                {
                                    //Checa se o email está validado, não existe no banco de dados ou se os campos email e confirma email "bate"
                                    if (email)
                                    {
                                        //Checa se a senha está validada, ou se os campos senha e confirma senha "bate"
                                        if (senha)
                                        {

                                            Banco.conn.Open();
                                            Banco.ExecNonSelect("INSERT INTO usuarioinfo VALUES('" + EmailText.Text + "','" + NomeText.Text + "','" + SobreNomeText.Text + "','" + DataNascText.Text + "')");
                                            
                                            //Calcula o Índice de Massa Corporal a partir do Função IMC da Classe Calculos
                                            double IMC = Calculos.IMC(double.Parse(AlturaText.Text), double.Parse(PesoText.Text));
                                            //Calcula o Relação Cintura-Quadril a partir do Função RCQ da Classe Calculos
                                            double RCQ = Calculos.RCQ(double.Parse(CinturaText.Text), double.Parse(QuadrilText.Text));
                                            //Calcula a Taxa de Metabolismo Basal a partir da Função TMBMasc ou TMBFem da Classe Calculos
                                            //Checa se foi o sexo escolhido como masculino ou feminino
                                            //Pega o ano do nascimento do DataNascText
                                            string ano = DataNascText.Text[6].ToString() + DataNascText.Text[7].ToString() + DataNascText.Text[8].ToString() + DataNascText.Text[9].ToString();
                                            double idade = DateTime.Today.Year - double.Parse(ano);
                                            double TMB = 0,percentual;
                                            string BF1 = "", BF2 = "", BF3= "", BF4="", BF5="", BF6="", BF7="";
                                            if (MascRadio.IsChecked == true)
                                            {
                                                //Recolhe os dados de cada radiobutton referente à percentual Masculino
                                                BF1 = "12";
                                                BF2 = "15";
                                                BF3 = "20";
                                                BF4 = "25";
                                                BF5 = "30";
                                                BF6 = "35";
                                                BF7 = "8";
                                                //Checa qual foi o nivel de atividade escolhida
                                                if (SedenRadio.IsChecked == true)
                                                {
                                                    percentual = 1.2;
                                                    TMB = Calculos.TMBMasc(double.Parse(PesoText.Text), double.Parse(AlturaText.Text), idade, percentual);
                                                    //Grava essas informações
                                                    Banco.ExecNonSelect("INSERT INTO usuarioinfodetalhes VALUES('" + EmailText.Text + "','Masculino','Sedentário','"+DateTime.Today.ToString()+"')");
                                                }
                                                else if (LevAtivRadio.IsChecked == true)
                                                {
                                                    percentual = 1.375;
                                                    TMB = Calculos.TMBMasc(double.Parse(PesoText.Text), double.Parse(AlturaText.Text), idade, percentual);
                                                    //Grava essas informações
                                                    Banco.ExecNonSelect("INSERT INTO usuarioinfodetalhes VALUES('" + EmailText.Text + "','Masculino','Levemente Ativo','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (AtivRadio.IsChecked == true)
                                                {
                                                    percentual = 1.55;
                                                    TMB = Calculos.TMBMasc(double.Parse(PesoText.Text), double.Parse(AlturaText.Text), idade, percentual);
                                                    //Grava essas informações
                                                    Banco.ExecNonSelect("INSERT INTO usuarioinfodetalhes VALUES('" + EmailText.Text + "','Masculino','Ativo','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (MuitoAtivRadio.IsChecked == true)
                                                {
                                                    percentual = 1.725;
                                                    TMB = Calculos.TMBMasc(double.Parse(PesoText.Text), double.Parse(AlturaText.Text), idade, percentual);
                                                    //Grava essas informações
                                                    Banco.ExecNonSelect("INSERT INTO usuarioinfodetalhes VALUES('" + EmailText.Text + "','Masculino','Muito Ativo','" + DateTime.Today.ToString() + "')");
                                                }

                                            }
                                            else if (FemRadio.IsChecked == true)
                                            {
                                                //Recolhe os dados de cada radiobutton referente à percentual Feminino
                                                BF1 = "20";
                                                BF2 = "25";
                                                BF3 = "30";
                                                BF4 = "35";
                                                BF5 = "40";
                                                BF6 = "45";
                                                BF7 = "15";
                                                //Checa qual foi o nivel de atividade escolhida
                                                if (SedenRadio.IsChecked == true)
                                                {
                                                    percentual = 1.2;
                                                    TMB = Calculos.TMBFem(double.Parse(PesoText.Text), double.Parse(AlturaText.Text), idade, percentual);
                                                    //Grava essas informações
                                                    Banco.ExecNonSelect("INSERT INTO usuarioinfodetalhes VALUES('" + EmailText.Text + "','Feminino','Sedentário','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (LevAtivRadio.IsChecked == true)
                                                {
                                                    percentual = 1.375;
                                                    TMB = Calculos.TMBFem(double.Parse(PesoText.Text), double.Parse(AlturaText.Text), idade, percentual);
                                                    //Grava essas informações
                                                    Banco.ExecNonSelect("INSERT INTO usuarioinfodetalhes VALUES('" + EmailText.Text + "','Feminino','Levemente Ativo','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (AtivRadio.IsChecked == true)
                                                {
                                                    percentual = 1.55;
                                                    TMB = Calculos.TMBFem(double.Parse(PesoText.Text), double.Parse(AlturaText.Text), idade, percentual);
                                                    //Grava essas informações
                                                    Banco.ExecNonSelect("INSERT INTO usuarioinfodetalhes VALUES('" + EmailText.Text + "','Feminino','Ativo','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (MuitoAtivRadio.IsChecked == true)
                                                {
                                                    percentual = 1.725;
                                                    TMB = Calculos.TMBFem(double.Parse(PesoText.Text), double.Parse(AlturaText.Text), idade, percentual);
                                                    //Grava essas informações
                                                    Banco.ExecNonSelect("INSERT INTO usuarioinfodetalhes VALUES('" + EmailText.Text + "','Feminino','Muito Ativo','" + DateTime.Today.ToString() + "')");
                                                }
                                            }
                                            double meta, time;
                                            time = 30;
                                            meta = Calculos.Meta(TMB, double.Parse(PesoText.Text),IMC);
                                            //Grava informações do login
                                            Banco.ExecNonSelect("INSERT INTO usuariologin VALUES('" + EmailText.Text + "','"+SenhaText.Password +"','" + DateTime.Today.ToString() + "')");
                                            if (SimRadio.IsChecked == true)
                                            {
                                                //Grava as medidas se for a radiobutton sim checada
                                                Banco.ExecNonSelect("INSERT INTO usuariomedidas VALUES('" + EmailText.Text + "','" + AlturaText.Text + "','" + PesoText.Text + "','" + ToraxText.Text + "','" + AbdomenText.Text + "','" + CinturaText.Text + "','" + QuadrilText.Text + "','"+ QuantoText.Text +"','" + DateTime.Today.ToString() + "')");
                                            }
                                            else if (NaoRadio.IsChecked == true)
                                            {
                                                //Grava as medidas se for a radiobutton não checada, referente a qual percentual foi escolhido
                                                if (_12M20FRadio.IsChecked == true)
                                                {
                                                    Banco.ExecNonSelect("INSERT INTO usuariomedidas VALUES('" + EmailText.Text + "','" + AlturaText.Text + "','" + PesoText.Text + "','" + ToraxText.Text + "','" + AbdomenText.Text + "','" + CinturaText.Text + "','" + QuadrilText.Text + "','" + BF1 + "','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (_15M25FRadio.IsChecked == true)
                                                {
                                                    Banco.ExecNonSelect("INSERT INTO usuariomedidas VALUES('" + EmailText.Text + "','" + AlturaText.Text + "','" + PesoText.Text + "','" + ToraxText.Text + "','" + AbdomenText.Text + "','" + CinturaText.Text + "','" + QuadrilText.Text + "','" + BF2 + "','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (_20M30FRadio.IsChecked == true)
                                                {
                                                    Banco.ExecNonSelect("INSERT INTO usuariomedidas VALUES('" + EmailText.Text + "','" + AlturaText.Text + "','" + PesoText.Text + "','" + ToraxText.Text + "','" + AbdomenText.Text + "','" + CinturaText.Text + "','" + QuadrilText.Text + "','" + BF3 + "','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (_25M35FRadio.IsChecked == true)
                                                {
                                                    Banco.ExecNonSelect("INSERT INTO usuariomedidas VALUES('" + EmailText.Text + "','" + AlturaText.Text + "','" + PesoText.Text + "','" + ToraxText.Text + "','" + AbdomenText.Text + "','" + CinturaText.Text + "','" + QuadrilText.Text + "','" + BF4 + "','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (_30M40FRadio.IsChecked == true)
                                                {
                                                    Banco.ExecNonSelect("INSERT INTO usuariomedidas VALUES('" + EmailText.Text + "','" + AlturaText.Text + "','" + PesoText.Text + "','" + ToraxText.Text + "','" + AbdomenText.Text + "','" + CinturaText.Text + "','" + QuadrilText.Text + "','" + BF5 + "','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (_35M45FRadio.IsChecked == true)
                                                {
                                                    Banco.ExecNonSelect("INSERT INTO usuariomedidas VALUES('" + EmailText.Text + "','" + AlturaText.Text + "','" + PesoText.Text + "','" + ToraxText.Text + "','" + AbdomenText.Text + "','" + CinturaText.Text + "','" + QuadrilText.Text + "','" + BF6 + "','" + DateTime.Today.ToString() + "')");
                                                }
                                                else if (_8M15FRadio.IsChecked == true)
                                                {
                                                    Banco.ExecNonSelect("INSERT INTO usuariomedidas VALUES('" + EmailText.Text + "','" + AlturaText.Text + "','" + PesoText.Text + "','" + ToraxText.Text + "','" + AbdomenText.Text + "','" + CinturaText.Text + "','" + QuadrilText.Text + "','" + BF7 + "','" + DateTime.Today.ToString() + "')");
                                                }
                                            }
                                            //Grava a informação para recuperação da senha
                                            Banco.ExecNonSelect("INSERT INTO usuariorecuperacao VALUES('" + EmailText.Text + "','" + Pergunta1Text.Text + "','" + Resp1Text.Text + "','" + Pergunta2Text.Text + "','" + Resp2Text.Text + "','" + Pergunta3Text.Text + "','" + Resp3Text.Text + "')");
                                            //Grava os calculos feitos no programa
                                            Banco.ExecNonSelect("INSERT INTO usuariocalculos VALUES('" + EmailText.Text + "','" + IMC + "','" + RCQ + "','" + TMB + "','" + meta + "','" + DateTime.Today.ToString() + "')");
                                            DateTime diea = DateTime.Today.Date;
                                            diea = diea.AddDays(15);
                                            Banco.ExecNonSelect("INSERT INTO usuariometarestart VALUES('" + EmailText.Text + "','" + DateTime.Today.Date.ToShortDateString() + "','" + diea.ToShortDateString() + "','" + TMB + "')");
                                            Banco.conn.Close();
                                            //BD HAPPENS
                                            System.Windows.MessageBox.Show("Gravado com sucesso!");
                                            //Abre a pagina de Introdução do Cadastro escondendo a outra
                                            this.Visibility = Visibility.Collapsed;
                                            FimCadastro cadastro = new FimCadastro();
                                            cadastro.Show();
                                            cadastro.fim = this;
                                        }
                                        else
                                        {
                                            //Informa que a senha está validada, ou se os campos senha e confirma senha "bate"
                                            System.Windows.MessageBox.Show("Senha está inválidada ou os campos não estão com dados iguais");
                                        }
                                    }
                                    else
                                    {
                                        //Informa que email não está validado, existe no banco de dados ou os campos email e confirma email "bate"
                                        System.Windows.MessageBox.Show("Email inválidado, já existe no banco de dados ou os campos não estão com dados iguais");
                                    }
                                }
                                else
                                {
                                    //Informa ao usuário que existem campos vagos
                                    System.Windows.MessageBox.Show("Por favor, preencha todos os campos obrigatórios!");
                                }
                        }
                        else
                        {
                            //Informa ao usuário que existem campos vagos
                            System.Windows.MessageBox.Show("Por favor, preencha todos os campos obrigatórios!");
                        }
                    }
                    else
                    {
                        //Informa ao usuário que existem campos vagos
                        System.Windows.MessageBox.Show("Por favor, preencha todos os campos obrigatórios!");
                    }
                }
                else
                {
                    //Informa ao usuário que existem campos vagos
                    System.Windows.MessageBox.Show("Por favor, preencha todos os campos obrigatórios!");
                }
            }
            else
            {
                //Informa ao usuário que existem campos vagos
                System.Windows.MessageBox.Show("Por favor, preencha todos os campos obrigatórios!");
            }
        }

        private void EmailText_Leave(object sender, TextChangedEventArgs e)
        {
            //Checa se o Email é igual ao da confirmação
            if (EmailText.Text == ConfEmailText.Text)
            {
                //Checa se o email é válido,ou seja, se está no formato example@example.qualquercoisa(...)
                if (Regex.IsMatch(EmailText.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") && Regex.IsMatch(ConfEmailText.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    //Checa no BD se esse email está disponivel
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT Email from usuariologin where Email='" + EmailText.Text + "'");
                    if (Banco.leitor.Read() ==false)
                    {
                        //Informa que o email está disponivel
                        CheckEmail.Content = "Email Disponivel";
                        //Bota a Imagem de que não deu certo ou um X
                        ImagemCheck.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "check.png", UriKind.Absolute));
                        email = true;
                        emails = EmailText.Text;
                    }
                    else
                    {
                        //Informa que o email está indisponivel
                        CheckEmail.Content = "Email Indisponivel";
                        //Bota a Imagem de que não deu certo ou um X
                        ImagemCheck.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
                        email = false;
                    }
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
                else
                {
                    //Informa que o email é inválido
                    CheckEmail.Content = "Email Inválido";
                    //Bota a Imagem de que não deu certo ou um X
                    ImagemCheck.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
                    email = false;
                }
            }
            else
            {
                //Informa que os dados não batem
                CheckEmail.Content = "Os dados não batem";
                //Bota a Imagem de que não deu certo ou um X
                ImagemCheck.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
                email = false;
            }
        }

        private void ConfEmailText_Text(object sender, TextChangedEventArgs e)
        {
            //Checa se o Email é igual ao da confirmação
            if (EmailText.Text == ConfEmailText.Text)
            {
                //Checa se o email é válido,ou seja, se está no formato example@example.qualquercoisa(...)
                if (Regex.IsMatch(EmailText.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") && Regex.IsMatch(ConfEmailText.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    //Checa no BD se esse email está disponivel
                    Banco.conn.Open();
                    Banco.ExecSelect("SELECT Email from usuariologin where Email='" + EmailText.Text + "'");
                    if (Banco.leitor.Read() == false)
                    {
                        //Informa que o email está disponivel
                        CheckEmail.Content = "Email Disponivel";
                        //Bota a Imagem de que não deu certo ou um X
                        ImagemCheck.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "check.png", UriKind.Absolute));
                        email = true;
                        emails = EmailText.Text;
                    }
                    else
                    {
                        //Informa que o email está indisponivel
                        CheckEmail.Content = "Email Indisponivel";
                        //Bota a Imagem de que não deu certo ou um X
                        ImagemCheck.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
                        email = false;
                    }
                    Banco.leitor.Close();
                    Banco.conn.Close();
                }
                else
                {
                    //Informa que o email é inválido
                    CheckEmail.Content = "Email Inválido";
                    //Bota a Imagem de que deu certo ou um check
                    ImagemCheck.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
                    email = false;
                }
            }
            else
            {
                //Informa que os dados não batem
                CheckEmail.Content = "Os dados não batem";
                //Bota a Imagem de que não deu certo ou um X
                ImagemCheck.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
                email = false;
            }
        }

        private void EmailText_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            EmailText.SelectionStart = 0;
        }

        private void NomeText_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            NomeText.SelectionStart = 0;
        }

        private void SobreNomeText_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            SobreNomeText.SelectionStart = 0;
        }

        private void ConfEmailText_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            ConfEmailText.SelectionStart = 0;
        }

        private void Pergunta1Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Pergunta1Text.SelectionStart = 0;
        }

        private void Resp1Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Resp1Text.SelectionStart = 0;
        }

        private void Pergunta2Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Pergunta2Text.SelectionStart = 0;
        }

        private void Resp2Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Resp2Text.SelectionStart = 0;
        }

        private void Pergunta3Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Pergunta3Text.SelectionStart = 0;
        }

        private void Resp3Text_LostFocus(object sender, RoutedEventArgs e)
        {
            //Faz o texto ficar no inicio. inves de ...outlook.com ficaria gabrieldaumas@...
            Resp3Text.SelectionStart = 0;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Informa o usuário sobre os Níveis de atividade
            System.Windows.MessageBox.Show(" Nível de atividade: \n\n Sedentário: não pratica atividade física. \n Levemente Ativo: pratica atividade física 1 a 3 vezes por semana. \n Ativo: pratica atividade física 3 a 5 dias por semana. \n Muito Ativo: pratica atividade física 6 a 7 dias por semana.", "Informativo");
        }

        private void ConfSenhaText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Checa se o Senha é igual ao da confirmação
            if (SenhaText.Password == ConfSenhaText.Password)
            {
                //Checa se o senha tem 8 ou mais caracteres
                if (SenhaText.Password.Count() > 7)
                {
                    //Checa se o senha tem 10 ou mais caracteres
                    if (SenhaText.Password.Count() > 9)
                    {
                        senha = true;
                        CheckSenha.Content = "Senha segura";
                        //Bota a Imagem de que deu certo ou um check
                        ImagemCheckSenha.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "check.png", UriKind.Absolute));
                    }
                    else
                    {
                        senha = true;
                        CheckSenha.Content = "Senha correta";
                        //Bota a Imagem de que deu certo ou um check
                        ImagemCheckSenha.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "check.png", UriKind.Absolute));
                    }
                }
                else
                {
                    senha = false;
                    //Informa que o senha é pequena demais
                    CheckSenha.Content = "Senha muito curta";
                    //Bota a Imagem de que não deu certo ou um X
                    ImagemCheckSenha.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
                }
            }
            else
            {
                //Informa que os dados não batem
                CheckSenha.Content = "Os dados não batem";
                //Bota a Imagem de que não deu certo ou um X
                ImagemCheckSenha.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
                senha = false;
            }
        }

        private void SenhaText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Checa se o Senha é igual ao da confirmação
            if (SenhaText.Password == ConfSenhaText.Password)
            {
                //Checa se o senha tem 8 ou mais caracteres
                if (SenhaText.Password.Count() > 7)
                {
                    //Checa se o senha tem 10 ou mais caracteres
                    if (SenhaText.Password.Count() > 9)
                    {
                        senha = true;
                        CheckSenha.Content = "Senha correta";
                        //Bota a Imagem de que deu certo ou um check
                        ImagemCheckSenha.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "check.png", UriKind.Absolute));
                    }
                    else
                    {
                        senha = true;
                        CheckSenha.Content = "Senha segura";
                        //Bota a Imagem de que deu certo ou um check
                        ImagemCheckSenha.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "check.png", UriKind.Absolute));
                    }
                }
                else
                {
                    senha = false;
                    //Informa que o senha é pequena demais
                    CheckSenha.Content = "Senha muito curta";
                    //Bota a Imagem de que não deu certo ou um X
                    BitmapImage logo = new BitmapImage();
                    ImagemCheckSenha.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
                }
            }
            else
            {
                senha = false;
                //Informa que os dados não batem
                CheckSenha.Content = "Os dados não batem";
                //Bota a Imagem de que não deu certo ou um X
                ImagemCheckSenha.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "nocheck.png", UriKind.Absolute));
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LabelInformativoBF_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Informa o usuário sobre o Percentual de Gordura
            if (MascRadio.IsChecked == true)
            {
                //Informativo para homens
                System.Windows.MessageBox.Show(" Percentual de Gordura \n\n Gordura essencial: o percentual fica entre 2% à 5%. \n Atleta: o percentual fica entre 6% à 13% \n Fitness: o percentual fica entre 14% à 17% \n Acima do recomendado: o percentual fica entre 18% à 24% \n Obesidade: o percentual fica acima de 25%", "Informativo");
            }
            else if (FemRadio.IsChecked == true)
            {
                //Informativo para mulheres
                System.Windows.MessageBox.Show(" Percentual de Gordura \n\n Gordura essencial: o percentual fica entre 10% à 13%. \n Atleta: o percentual fica entre 14% à 20% \n Fitness: o percentual fica entre 21% à 24% \n Acima do recomendado: o percentual fica entre 25% à 31% \n Obesidade: o percentual fica acima de 32%", "Informativo");
            }
            else
            {
                //Informa ao usuario que o sexo não foi determinado
                System.Windows.MessageBox.Show("Sexo não determinado em Informações!!!");
            }
        }


        private void SimRadio_Click(object sender, RoutedEventArgs e)
        {
            //Checa se há um sexo selecionado
            if (MascRadio.IsChecked == true || FemRadio.IsChecked == true)
            {
                //Checa se é o MascRadio que tá selecionado
                if (MascRadio.IsChecked == true)
                {
                    FotoBFM.Visibility = Visibility.Collapsed;

                }
                //Checa se é o FemRadio que tá selecionado
                else
                {
                    FotoBFF.Visibility = Visibility.Collapsed;
                }
                //Muda a visibilidade das RadioButtons
                _12M20FRadio.Visibility = Visibility.Collapsed;
                _15M25FRadio.Visibility = Visibility.Collapsed;
                _20M30FRadio.Visibility = Visibility.Collapsed;
                _25M35FRadio.Visibility = Visibility.Collapsed;
                _30M40FRadio.Visibility = Visibility.Collapsed;
                _35M45FRadio.Visibility = Visibility.Collapsed;
                _8M15FRadio.Visibility = Visibility.Collapsed;
                //Limpa tudo
                _8M15FRadio.IsChecked = false;
                _35M45FRadio.IsChecked = false;
                _30M40FRadio.IsChecked = false;
                _25M35FRadio.IsChecked = false;
                _20M30FRadio.IsChecked = false;
                _15M25FRadio.IsChecked = false;
                _12M20FRadio.IsChecked = false;
                QuantoText.Text = "";
                //Muda a visibilidade das Labels
                CasoLabel.Visibility = Visibility.Collapsed;
                QuantoLabel.Visibility = Visibility.Visible;
                LabelInformativoBF.Visibility = Visibility.Visible;
                //Muda a visibilidade do Texts
                QuantoText.Visibility = Visibility.Visible;
            }
            else
            {
                //Informa ao usuario que o sexo não foi determinado
                System.Windows.MessageBox.Show("Sexo não determinado em Informações!!!");
                //"Descheca" a radiobutton
                SimRadio.IsChecked = false;
            }
        }

        private void NaoRadio_Click(object sender, RoutedEventArgs e)
        {
            //Checa se há um sexo selecionado
            if (MascRadio.IsChecked == true || FemRadio.IsChecked == true)
            {
                //Checa se é o MascRadio que tá selecionado
                if (MascRadio.IsChecked == true)
                {
                    FotoBFM.Visibility = Visibility.Visible;

                }
                //Checa se é o FemRadio que tá selecionado
                else
                {
                    FotoBFF.Visibility = Visibility.Visible;
                }
                //Muda a visibilidade das RadioButtons
                _12M20FRadio.Visibility = Visibility.Visible;
                _15M25FRadio.Visibility = Visibility.Visible;
                _20M30FRadio.Visibility = Visibility.Visible;
                _25M35FRadio.Visibility = Visibility.Visible;
                _30M40FRadio.Visibility = Visibility.Visible;
                _35M45FRadio.Visibility = Visibility.Visible;
                _8M15FRadio.Visibility = Visibility.Visible;
                //Limpa tudo
                _8M15FRadio.IsChecked = false;
                _35M45FRadio.IsChecked = false;
                _30M40FRadio.IsChecked = false;
                _25M35FRadio.IsChecked = false;
                _20M30FRadio.IsChecked = false;
                _15M25FRadio.IsChecked = false;
                _12M20FRadio.IsChecked = false;
                QuantoText.Text = "";
                //Muda a visibilidade das Labels
                CasoLabel.Visibility = Visibility.Visible;
                QuantoLabel.Visibility = Visibility.Collapsed;
                LabelInformativoBF.Visibility = Visibility.Visible;
                //Muda a visibilidade do Texts
                QuantoText.Visibility = Visibility.Collapsed;

            }
            else
            {
                //Informa ao usuario que o sexo não foi determinado
                System.Windows.MessageBox.Show("Sexo não determinado em Informações!!!");
                //"Descheca" a radiobutton
                NaoRadio.IsChecked = false;
            }
        }

        private void MascRadio_Click(object sender, RoutedEventArgs e)
        {
            //Para mudar a foto o NaoRadio tem de estar checado
            if (NaoRadio.IsChecked == true)
            {
                //Muda a foto
                FotoBFM.Visibility = Visibility.Visible;
                FotoBFF.Visibility = Visibility.Collapsed;
            }
        }

        private void FemRadio_Click(object sender, RoutedEventArgs e)
        {
            //Para mudar a foto o NaoRadio tem de estar checado
            if (NaoRadio.IsChecked == true)
            {
                //Muda a foto
                FotoBFM.Visibility = Visibility.Collapsed;
                FotoBFF.Visibility = Visibility.Visible;
            }
        }

    }
}
