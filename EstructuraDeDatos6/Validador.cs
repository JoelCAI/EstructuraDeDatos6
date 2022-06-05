using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos6
{
    internal class Validador
    {
        public static int PedirIntMenu(string mensaje, int min, int max)
        {

            int valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }

        public static long PedirLongMenu(string mensaje, long min, long max)
        {

            long valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!long.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }

        public static int PedirIntMayor(string mensaje, int min)
        {

            int valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor mayor a " + min;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!int.TryParse(Console.ReadLine(), out valor) || valor <= min)
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }

        public static string PedirCaracterString(string mensaje, int min, int max)
        {
            string valor;
            bool valido = false;
            string mensajeMenu = "\n El número de caracteres a ingresar es entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar dentro del rango solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                valor = Console.ReadLine();


                if (valor.Length < min || valor.Length > max)
                {
                    Console.Clear();
                    Console.WriteLine(mensajeError);

                }
                else
                {

                    valido = true;

                }

            } while (!valido);


            return valor;

        }



        public static string ValidarTipoRecargo(string mensaje)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Valores permitidos:" +
                                      "\n *URGENTE* ó" +
                                      "\n *RETIROENPUERTA* ó " +
                                      "\n *INTERNACIONAL* ó " +
                                      "\n *NINGUNO* ó ";
            string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeError);
                Console.WriteLine(mensajeValidador);
                opcion = Console.ReadLine().ToUpper();
                string opcionC = "URGENTE";
                string opcionD = "RETIROENPUERTA";
                string opcionE = "INTERNACIONAL";
                string opcionF = "NINGUNO";

                if (opcion == "" || (opcion != opcionC) & (opcion != opcionD) & (opcion != opcionE)
                                & (opcion != opcionF))
                {
                    continue;

                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return opcion;
        }

        public static string ValidarSioNo(string mensaje)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Valores permitidos:" +
                                      "\n *SI* ó" +
                                      "\n *NO*";
            string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeError);
                Console.WriteLine(mensajeValidador);
                opcion = Console.ReadLine().ToUpper();
                string opcionC = "SI";
                string opcionD = "NO";
 
                if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
                {
                    continue;

                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return opcion;
        }

        public static DateTime ValidarFechaIngresada(string mensaje)
        {
            bool ingresoCorrecto;
            DateTime fechaValida;

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine("\n Ingrese un formato válido.");
                Console.WriteLine("\n El formato correcto es *dd/mm/aaaa*.");
                Console.WriteLine("\n También puede ser *dd/mm/aaaa hh:mm:ss*.");

                string ingresoNacimiento = Console.ReadLine();

                ingresoCorrecto = DateTime.TryParse(ingresoNacimiento, out fechaValida);

                if (!ingresoCorrecto)
                {
                    continue;
                }


            } while (!ingresoCorrecto);

            return fechaValida;
        }

       

        public static void VolverMenu()
        {
            Console.WriteLine("\n Presione cualquier tecla para volver al Menú ");
            Console.ReadKey();
        }
    }
}
