using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTablero.Dominio.Validaciones
{
    public class ValidacionesInput
    {
        public static string FuncionValidacionOpcion(ref string opcion)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }
                else if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }
            }while (flag == false);

            return opcion;
        }

        public static string FuncionValidacionEstado(ref string estado)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                Console.WriteLine("Los estados son: " + Environment.NewLine +
                    "No iniciada" + Environment.NewLine +
                    "En curso" + Environment.NewLine +
                    "Finalizada" + Environment.NewLine +
                    "Ingrese el estado:");

                estado = Console.ReadLine();

                if (estado == "No iniciada" || estado == "En curso" || estado == "Finalizada" || estado == "")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! El estado " + estado + " no es un estado válido, intente nuevamente.");
                }

            }while(flag == false);

            return estado;
        }

        public static bool FuncionValidacionCodigo(string codigo, ref int codigoValidado)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                if (!int.TryParse(codigo, out codigoValidado))
                {
                    Console.WriteLine("El código ingresado debe ser de tipo numérico, intente nuevamente.");
                }
                else if (codigoValidado <= 0)
                {
                    Console.WriteLine("El código ingresado debe ser mayor a cero, intente nuevamente");
                }
                else
                {
                    flag = true;
                }
            } while (flag == false);

            return flag;
        }

        public static bool FuncionValidacionCadena(ref string cadena)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(cadena))
            {
                Console.WriteLine("ERROR! El valor ingresado no puede ser vacío, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionNumero(string numero, ref int numeroValidado)
        {
            //Declaración de variables
            bool flag = false;

            if (!int.TryParse(numero, out numeroValidado))
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser de tipo numérico, intente nuevamente.");
            }
            else if (numeroValidado <= 0)
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser mayor a cero, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionFechaAlta(string fecha, ref DateTime fechaValidada)
        {
            //Declaración de variables
            bool flag = false;

            if (!DateTime.TryParse(fecha, out fechaValidada))
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser de tipo fecha, intente nuevamente.");
            }
            else if (fechaValidada > DateTime.Now)
            {
                Console.WriteLine("ERROR! La fecha ingresada no puede ser superior al día de hoy, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionFechaFin(string fecha, ref DateTime fechaValidada)
        {
            //Declaración de variables
            bool flag = false;

            if (!DateTime.TryParse(fecha, out fechaValidada))
            {
                Console.WriteLine("ERROR! El valor ingresado tiene que ser de tipo fecha, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }
    }
}
