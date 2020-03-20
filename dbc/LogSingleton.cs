using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbc
{
    public sealed class LogSingleton
    {
        /* String estatico del path para guardar el archivo txt */
        private static string Path = @"C:\Users\Hafid\source\repos\dbc\dbc\Logger";

        /* Constructor privado con inicializacion directa en una sola linea */
        private readonly static LogSingleton _instance = new LogSingleton();

        /* Propiedad estatica publica */
        public static LogSingleton Instance
        {
            get
            {
                return _instance;
            }
        }

        /* Metodo para agregar mensaje */
        public void Add(string sCat, string sLog)
        {
            CreateDirectory();
            string nombre = "logger.txt";
            string cadena = "";

            cadena += $"[ {DateTime.Now} ]:   {sCat + ": [ " + sLog + " ]"} {Environment.NewLine}";

            StreamWriter sw = new StreamWriter(Path + "/" + nombre, true);
            sw.Write(cadena); /* abrir archivo para escibir una nueva linea */
            sw.Close(); /* cierra el archivo */
        }

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);

            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}