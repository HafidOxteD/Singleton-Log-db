using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dbc
{
    class Program
    {

        static void Main(string[] args)
        {
            LogSingleton.Instance.Add("INFORMATIVO", "Se inicio el programa");
            //Console.WriteLine("Inicio del programa\n");

            /*
             * Ya no se usa instancia de base de datos ya que se realizo el singleton del mismo
             * 
              ConexionBD test1 = new ConexionBD();
              test1.AbrirConexion();
              test1.InsertarPersona("1403333");
              ConexionDBSingleton.Instance.TestConexion();
            */

            /* Se utiliza el singleton de la base de datos para agregar usuarios */
            //ConexionDBSingleton.Instance.InsertarPersona("140300099");
            //ConexionDBSingleton.Instance.InsertarPersona("140300100");

            /* se usa el singleton para eliminar usuarios */
            //ConexionDBSingleton.Instance.BorrarPersona("140300000");

            /* Validacion de la persona, true si se encuentra en la base de datos, false en caso contrario */
            //bool ss = ConexionDBSingleton.Instance.ConsultarPersona("140300042");

            while (true)
            {
                Console.WriteLine("______________________________________________\n");
                Console.WriteLine("Escribe la opcion que desees:");
                Console.WriteLine("1 Validar entrada");
                Console.WriteLine("2 registrar persona\n");

                int c = int.Parse(System.Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.WriteLine("Escribe ID o matricula a validar:");
                        string a = Console.ReadLine();
                        //Console.WriteLine(a);
                        bool ss = ConexionDBSingleton.Instance.ConsultarPersona(a);
                        Console.WriteLine(ss);
                        if (ss == true)
                        {
                            Console.WriteLine("Puede pasar");
                        } else
                        {
                            Console.WriteLine("No registrado, no puede pasar");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Escribe id");
                        string i = Console.ReadLine();
                        Console.WriteLine("Escribe nombre");
                        string n = Console.ReadLine();
                        ConexionDBSingleton.Instance.InsertarPersona(i,n);
                        break;
                    default:
                        Console.WriteLine("Opcion no valida, intente nuevamente");
                        break;
                }
            }
            
            /*
            while (true)
            {
                string a = Console.ReadLine();
                //Console.WriteLine(a);
                bool ss = ConexionDBSingleton.Instance.ConsultarPersona(a);
                Console.WriteLine(ss);
            }
            */
            /* dejar en espera la consola */
            //string z = Console.ReadLine();
        }
    }
}