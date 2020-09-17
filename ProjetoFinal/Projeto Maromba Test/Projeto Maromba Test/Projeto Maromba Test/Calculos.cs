using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Maromba_Test
{
    public static class Calculos
    {
        //Função para calcular Índice de Massa Corporal
        public static double IMC(double medida,double peso)
        {
            //Cria duas variáveis que serão importantes para o cálculo
            double IMC,altura;
            //Converte de CM para M
            medida = medida / 100;
            //Eleva a altura do usuário ao quadrado
            altura = medida * medida;
            //Divide o peso do usuário pela altura do mesmo
            IMC = peso / altura;
            //Arredonda o IMC para duas casas decimais
            IMC = Math.Round(IMC, 2);
            return IMC;
        }
        //Função para Calcular Relação Cintura-Quadril
        public static double RCQ(double cintura, double quadril)
        {
            //Divide o valor da cintura pelo valor do quadril
            double RCQ = cintura / quadril;
            //Arredonda o RCQ para duas casas decimais
            RCQ = Math.Round(RCQ, 2);
            return RCQ;
        }
        //Função para Calcular Taxa de Metabolismo Basal Masculino
        public static double TMBMasc(double peso, double altura,double anos,double atividade)
        {
            double TMB = 66 + (13.8 * peso) + (5 * altura) - (6.8 * anos);
            TMB *= atividade;
            //Arredonda o TMB para duas casas decimais
            TMB = Math.Round(TMB, 2);
            return TMB;
        }
        //Função para Calcular Taxa de Metabolismo Basal Feminimo
        public static double TMBFem(double peso, double altura, double anos, double atividade)
        {
            double TMB = 655 + (9.6 * peso) + (1.8 * altura) - (4.7 * anos);
            TMB *= atividade;
            //Arredonda o TMB para duas casas decimais
            TMB = Math.Round(TMB, 2);
            return TMB;
        }
        //Função para Definir Meta de peso 
        public static double Meta(double TMB,double peso,double IMC)
        {
            //Apartir de quanto for o IMC do usuário
            if (IMC > 26)
            {
                TMB = TMB - 400;
                double meta = 400 * 15;
                //3500 kcal == 1kg (pelo menos teoricamente)
                meta = meta / 3500;
                meta = Math.Round(meta, 2);
                peso -= meta;
                return peso;
            }
            else if (IMC >= 25 || IMC < 27)
            {
                TMB = TMB - 200;
                double meta = 200 * 15;
                //3500 kcal == 1kg (pelo menos teoricamente)
                meta = meta / 3500;
                meta = Math.Round(meta, 2);
                peso -= meta;
                return peso;
            }
            else
            {
                if (IMC < 19 && IMC>23)
                {
                    TMB = TMB + 400;
                    double meta = 400 * 15;
                    //3500 kcal == 1kg (pelo menos teoricamente)
                    meta = meta / 3500;
                    meta = Math.Round(meta, 2);
                    peso += meta;
                    return peso;
                }
                else
                {
                    TMB = TMB + 200;
                    double meta = 200 * 15;
                    //3500 kcal == 1kg (pelo menos teoricamente)
                    meta = meta / 3500;
                    meta = Math.Round(meta, 2);
                    peso += meta;
                    return peso;
                }
            }
        }
    }
}
