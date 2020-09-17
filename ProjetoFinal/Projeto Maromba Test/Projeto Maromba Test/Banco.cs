using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TrabTecCbd
{
    class BD
    {
        static public MySqlConnection conn = new MySqlConnection("Persist Security Info=False;server=179.34.35.127;database=tcc;uid=root");
        static public MySqlCommand comando;
        static public MySqlDataReader leitor;

        static public MySqlDataReader ExecSelect(string comand)
        {
            comando = new MySqlCommand(comand, conn);
            leitor = comando.ExecuteReader();
            return leitor;
        }
        static public MySqlDataReader ExecSelect2(string comand)
        {
            comando = new MySqlCommand(comand, conn);
            leitor = comando.ExecuteReader();
            return leitor;
        }
        static public MySqlDataReader ExecSelectComand(string comand)
        {
            comando = new MySqlCommand(comand, conn);
            leitor = comando.ExecuteReader();
            return leitor;
        }

        static public void ExecNonSelect(string comand)
        {
            comando = new MySqlCommand(comand, conn);
            comando.ExecuteNonQuery();
        }
    }
}
