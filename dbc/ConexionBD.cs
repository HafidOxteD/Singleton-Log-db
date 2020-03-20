using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbc
{
    public class ConexionBD
    {
        /*
        static string Servidor = "localhost";
        static string Puerto = "3306";
        static string Usuario = "root";
        static string Password = "";
        
        static string item = "140300042";
        */
        //static string cadenaConexion = "Server=" + Servidor + "; port=" + Puerto + "; userid=" + Usuario + "; password=" + Password + "; database=sergio;";

        static string datos = "";

        private static string cadenaConexion = "server=localhost;port=3306;userid=root;password=;database=proyecto;";

        MySqlConnection Conexiondb = new MySqlConnection(cadenaConexion);


        public void AbrirConexion()
        {
            try
            {
                Conexiondb.Open();
                LogSingleton.Instance.Add("INFORMATIVO", "Se conecto a la base de datos");

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
                LogSingleton.Instance.Add("CRITICO", "Error en la conexion a la base de datos");
                // LogSingleton.Instance.Add("CRITICO", ex.ToString());
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine(datos);

        }

        public void InsertarPersona(String item)
        {
            string mat = item;
            string query = "INSERT INTO `persona` (`id`, `name`) VALUES('"+ mat + "', 'Hafid Oxte')";

            MySqlCommand commandDatabase = new MySqlCommand(query, Conexiondb);
            try
            {
                Conexiondb.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                Console.WriteLine("Usuario insertado satisfactoriamente");

                Conexiondb.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                Console.WriteLine(ex.Message);
            }
        }



        /*
         * private void SaveUser()
{
    string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";
    string query = "INSERT INTO user(`id`, `first_name`, `last_name`, `address`) VALUES (NULL, '"+textBox1.Text+ "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
    // Que puede ser traducido con un valor a:
    // INSERT INTO user(`id`, `first_name`, `last_name`, `address`) VALUES (NULL, 'Bruce', 'Wayne', 'Wayne Manor')
    
    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
    commandDatabase.CommandTimeout = 60;
    
    try
    {
        databaseConnection.Open();
        MySqlDataReader myReader = commandDatabase.ExecuteReader();
        
        MessageBox.Show("Usuario insertado satisfactoriamente");
   
        databaseConnection.Close();
    }
    catch (Exception ex)
    {
        // Mostrar cualquier error
        MessageBox.Show(ex.Message);
    }
}
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
        bool AbrirConexion()
        {

            try
            {
                ConexionBD.Open();
                if (ConexionBD.State == ConnectionState.Open)
                {
                    Console.WriteLine(ConexionBD.State);
                }
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }
        }
        */
    }
}
