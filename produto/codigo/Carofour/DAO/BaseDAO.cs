using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Carofour.DAO
{
    public class BaseDAO
    {
        public static MySqlConnection ObterConexao()
        {
            MySqlConnection connection = new MySqlConnection();
            //connection.ConnectionString = "Server = localhost; Database = Sgat; Uid = root; Pwd = SenhaRootMySQL";
            //connection.ConnectionString = "Server = localhost; Database = Sgat; Uid = root; Pwd = SenhaRootMySQL";
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["CarofourConnectionString"].ConnectionString;

            connection.Open();
            return connection;
        }

        public static int ExecutarComando(string comando)
        {
            return ExecutarComando(comando, null);
        }

        public static int ExecutarComando(string comando, Dictionary<string, object> parametros)
        {
            using (MySqlConnection connection = ObterConexao())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = comando;

                if (parametros != null)
                {
                    foreach (string key in parametros.Keys)
                    {
                        command.Parameters.AddWithValue("?" + key, parametros[key]);
                    }
                }

                return command.ExecuteNonQuery();
            }
        }

        public static DataSet ExecutarQuery(string query)
        {
            return ExecutarQuery(query, null);
        }

        public static DataSet ExecutarQuery(string query, Dictionary<string, object> parametros)
        {
            using (MySqlConnection connection = ObterConexao())
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;

                if (parametros != null)
                {
                    foreach (string key in parametros.Keys)
                    {
                        command.Parameters.AddWithValue("?" + key, parametros[key]);
                    }
                }

                DataSet ds = new DataSet();

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(ds);
                return ds;
            }
        }
    }
}