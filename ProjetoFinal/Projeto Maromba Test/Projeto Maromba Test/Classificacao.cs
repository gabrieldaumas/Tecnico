using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Maromba_Test
{
    public static class Classificacao
    {
        public static string IMCComp(string email)
        {
            //Cria variavel IMC que receberá o valor do IMC do usuário
            double IMC = 0.00;
            //Cria a string Class que será o retorno da função
            string Class = "";
            Banco.conn.Open();
            //Seleciona o IMC pelo Email
            Banco.ExecSelect("SELECT IMC FROM usuariocalculos WHERE Email='"+email+"'");
            if (Banco.leitor.Read())
            {
                //IMC recebe valor do IMC do usuário
                IMC = double.Parse(Banco.leitor.GetString(0));
            }
            Banco.leitor.Close();
            //Seleciona tudo da Tabela IMC que serve para comparar o IMC, e descobrir a classificação
            Banco.ExecSelect("SELECT * FROM IMC");
            while (Banco.leitor.Read())
            {
                //Checa se está entre os niveis de uma classificação
                if (IMC >= double.Parse(Banco.leitor.GetString(0)) && IMC <= double.Parse(Banco.leitor.GetString(1)))
                {
                    //Seleciona o nivel da classificação apos a checagem
                    Class = Banco.leitor.GetString(2);
                    break;
                }
                else
                {
                    continue;
                }
            }
            Banco.leitor.Close();
            Banco.conn.Close();
            //Retorna o nivel
            return Class;
        }
        public static string RCQInforma(string email)
        {
            //Cria duas variaveis, informa é utilizada para retornar alguma informação pro usuário e data é para receber a Data de Nascimento do usuário
            string informa = "",data= "";
            Banco.conn.Open();
            //Seleciona a Data de Nascimento pelo usuário
            Banco.ExecSelect("SELECT DataNascimento FROM usuarioinfo WHERE Email = '"+email+"'");
            if (Banco.leitor.Read())
            {
                //Data recebe a Data de Nascimento do usuário
                data= Banco.leitor.GetString(0);
            }
            Banco.leitor.Close();
            //Seleciona o texto da mensagem que será recebida pelo usuario.
            Banco.ExecSelect("SELECT Texto FROM RCQ,usuarioinfo,usuarioinfodetalhes WHERE Idade_Inicio<='" + Calculos.Idadele(data).ToString() + "' and Idade_Fim>='" + Calculos.Idadele(data).ToString() + "' and usuarioinfodetalhes.Sexo = rcq.Sexo AND usuarioinfo.Email=usuarioinfodetalhes.Email and usuarioinfo.Email = '"+email+"'");
            if (Banco.leitor.Read())
            {
                //Informa recebe esse texto que será retornado para o usuário
                informa = Banco.leitor.GetString(0);
            }
            Banco.leitor.Close();
            Banco.conn.Close();
            //Retorna o texto
            return informa;
        }
        public static string RCQComp(string email)
        {
            //Variavel que irá receber o RCQ do usuário
            double RCQ = 0.00;
            //Variavel que irá receber a idade do usuário
            int idade = 0;
            //String sexo receberá o sexo do usuário e Class é a variavel que irá receber o nivel de Risco do usuário
            string sexo = "",Class = "";
            Banco.conn.Open();
            //Seleciona o Sexo e a Data de Nascimento apartir do email
            Banco.ExecSelect("SELECT Sexo,DataNascimento FROM usuarioinfodetalhes,usuarioinfo WHERE usuarioinfodetalhes.Email = usuarioinfo.Email and usuarioinfo.Email='" + email + "'");
            if (Banco.leitor.Read())
            {
                //Destina essas informações nas variaveis abaixo
                sexo = Banco.leitor.GetString(0);
                idade = Calculos.Idadele(Banco.leitor.GetString(1));

            }
            Banco.leitor.Close();
            //Seleciona o RCQ apartir do Email
            Banco.ExecSelect("SELECT RCQ FROM usuariocalculos WHERE Email='" + email + "'");
            if (Banco.leitor.Read())
            {
                //Destina essa informação na variavel RCQ
                RCQ = double.Parse(Banco.leitor.GetString(0));
            }
            Banco.leitor.Close();
            //Seleciona o texto com as informações de idade e sexo
            Banco.ExecSelect("SELECT * FROM RCQ WHERE Sexo='" + sexo + "' and Idade_Inicio<='" + idade.ToString() + "' and Idade_Fim>='" + idade.ToString() + "'");
            while (Banco.leitor.Read())
            {
                //Checa se o RCQ é maior ou igual valor minimo de um risco e se menor ou igual valor maximo de um risco
                if (RCQ >= double.Parse(Banco.leitor.GetString(2)) && RCQ <= double.Parse(Banco.leitor.GetString(3)))
                {
                    //Class recebe esse texto
                    Class = Banco.leitor.GetString(5);
                    break;
                }
                else
                {
                    continue;
                }
            }
            Banco.leitor.Close();
            Banco.conn.Close();
            //Retorna esse texto
            return Class;
        }
        public static string IMCIdeais(string email)
        {
            //Cria a variavel que irá receber o peso ideal minimo, maximo e o peso que será aplicado a formula do IMC
            double pesoid = 0,pesoid2= 0,pesoteste;
            Banco.conn.Open();
            //Seleciona a Altura apartir dos emails
            Banco.ExecSelect("SELECT Altura FROM usuariomedidas WHERE Email='" + email + "'");
            if (Banco.leitor.Read())
            {
                //Recebe a altura e põe nessa altura
                double altura = double.Parse(Banco.leitor.GetString(0));
                //Converte de CM para M
                altura = altura / 100;
                //cria um for que irá roda o peso de 0.01 até 2000 kgs
                for (double i = 0.01; i <= 2000.00; i += 0.01)
                {
                    //Faz a formula do IMC com i e deposita no pesoteste
                    pesoteste = i /(altura * altura);
                    //arredonda pra duas casas decimais
                    pesoteste = Math.Round(pesoteste,2);
                    //Checa se o peso teste está no valor minimo do Peso Normal que é 18.5(IMC)
                    if (pesoteste == 18.50)
                    {
                        //deposita o peso do momento em que bate 18.50
                        pesoid = i;
                        //arredonda pra duas casas decimais
                        pesoid = Math.Round(pesoid, 2);
                    }
                    //Checa se o peso teste está no valor maximo do Peso Normal que é 24.99(IMC)
                    if (pesoteste>18.50  && pesoteste == 24.99)
                    {
                        ////deposita o peso do momento em que estar maior que 18.50 e igual a 24.99
                        pesoid2 = i;
                        //arredonda pra duas casas decimais
                        pesoid2 = Math.Round(pesoid2, 2);
                        //quebra o for porque não tem necessidade de continuar 
                        break;
                    }
                }
            }
            Banco.leitor.Close();
            Banco.conn.Close();
            //Retorna os pesos ideias formatando-os
            return "Seu Peso Ideal fica entre " + pesoid.ToString()+ " e " + pesoid2.ToString();
        }
    }
}
