using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbc
{
    public sealed class ConexionDBSingleton
    {
        private static string cadenaConexion = "server=localhost;port=3306;userid=root;password=;database=proyecto;";
        MySqlConnection Conexiondb = new MySqlConnection(cadenaConexion);
        MySqlCommand commandDatabase;
        MySqlDataReader reader;

        private readonly static ConexionDBSingleton _instancedb = new ConexionDBSingleton();

        public ConexionDBSingleton()
        {
            try
            {
                Conexiondb.Open();
                LogSingleton.Instance.Add("ADVERTENCIA", "Se conecto a la base de datos con conexion singleton");
                //Console.WriteLine("Se conecto base de datos con conexion singleton\n\n");
            }
            catch (MySqlException e)
            {
                LogSingleton.Instance.Add("CRITICO", "Error en la conexion a la base de datos");
                //Console.WriteLine("Error al conectar base de datos\n\n");
            }

        }


        public static ConexionDBSingleton Instance
        {
            get
            {
                return _instancedb;
            }


        }

        public void InsertarPersona(String item, String item2)
        {
            /*
            string mat = item;
            string mat = item;
            */
            string query = "INSERT INTO `persona` (`id`, `name`) VALUES('" + item + "', '"+item2+"')";


            commandDatabase = new MySqlCommand(query, Conexiondb);
            try
            {

                reader = commandDatabase.ExecuteReader();

                Console.WriteLine("Usuario insertado satisfactoriamente");
                reader.Close();

            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                Console.WriteLine(ex.Message);
            }
        }

        public void BorrarPersona(String item2)
        {

            string mat2 = item2;
            string query2 = "DELETE FROM `persona` WHERE `persona`.`id` =" + mat2 + ";";

            commandDatabase = new MySqlCommand(query2, Conexiondb);

            try
            {

                reader = commandDatabase.ExecuteReader();

                Console.WriteLine("El usuario se elimino correctamente");

                reader.Close();

            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                Console.WriteLine(ex.Message);
            }
        }

        public bool ConsultarPersona(String item3)
        {
            if (item3 == null)
            {
                Console.WriteLine("ingresaste vacio chamo");
            }
            string mat3 = item3;
            
            string query3 = "SELECT* FROM `persona` WHERE `persona`.`id` =" + mat3 + ";";

            commandDatabase = new MySqlCommand(query3, Conexiondb);
            
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //                   ID                              First name    
                        Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1));
                    }
                    reader.Close();
                    return true;
                }
                reader.Close();
                return false;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error en la consulta para validar persona");
                Console.WriteLine(e);
                return false;                
            }            
        }

        public void TestConexion()
        {
            string datos = "";
            try
            {
                Conexiondb.Open();
                //LogSingleton.Instance.Add("INFORMATIVO", "Se conecto a la base para test");

                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand("Show databases", Conexiondb);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    datos += reader.GetString(0) + "\n";
                }
            }
            catch (MySqlException ex)
            {
                LogSingleton.Instance.Add("CRITICO", "Error en la conexion a la base de datos de test");
                // LogSingleton.Instance.Add("CRITICO", ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine(datos);
            Conexiondb.Close();

        }
    }
}