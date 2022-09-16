using ProyectoTablero.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTablero.Dominio.Validaciones;

namespace ProyectoTablero.InterfazGrafica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaración de variables
            List<Tarea> _listadoTareas = new List<Tarea>();
            string _estado = "";
            string _opcionMenu = "";

            Tarea T1 = new Tarea("Tarea 1", 1, DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-7));
            Tarea T2 = new Tarea("Tarea 2", 2, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5));
            Tarea T3 = new Tarea("Tarea 3", 3, DateTime.Now.AddDays(-18), DateTime.Now.AddDays(-2));

            Tablero tableroElectronico = new Tablero("Trabajo", "Contiene tareas de trabajo", DateTime.Now.AddYears(-2));

            tableroElectronico.AgregarTarea(T1);
            tableroElectronico.AgregarTarea(T2);
            tableroElectronico.AgregarTarea(T3);

            //_listadoTareas = tableroElectronico.TraerTareas(estado);

            //Console.WriteLine(_listadoTareas);

            bool _consolaActiva = true;

            try
            {
                while (_consolaActiva)
                {
                    //Despliego en pantalla las opciones para que el usuario decida
                    OpcionesMenu();

                    //Se valida que la opcion ingresada no sea vacío y/o distinta de las opciones permitidas
                    ValidacionesInput.FuncionValidacionOpcion(ref _opcionMenu);

                    //Estructura condicional para controlar el flujo del programa
                    switch (_opcionMenu)
                    {
                        case "1":
                            //Listar tareas del tablero por estado
                            Listar(tableroElectronico, _estado);
                            break;
                        case "2":
                            //Cambio el estado a una tarea del tablero
                            Cambiar(tableroElectronico);
                            break;
                        case "3":
                            //Agrego una tarea al tablero
                            Agregar(tableroElectronico);
                            break;
                        case "4":
                            //Salir del programa
                            Salir();
                            break;
                    }
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void OpcionesMenu()
        {
            Console.WriteLine(
                "Bienvenido al tablero! Seleccione una opción:" + Environment.NewLine +
                "1 - Listar tareas del tablero por estado" + Environment.NewLine +
                "2 - Cambiar el estado a una tarea" + Environment.NewLine +
                "3 - Agregar una tarea al tablero" + Environment.NewLine +
                "4 - Salir"
                )
                ;
        }

        //Método para listar las tareas del tablero por estado
        public static void Listar(Tablero _tablero, string estado)
        {
            //Se valida que el estado ingresado no sea distinto de las opciones permitidas
            ValidacionesInput.FuncionValidacionEstado(ref estado);

            _tablero.TraerTareas(estado);
        }

        //Método para cambiar el estado de una tarea que indique el usuario por codigo
        public static void Cambiar(Tablero t)
        {
            //Declaración de variables
            string _codigo;
            int _codigoValidado = 0;
            string _estado = "";
            bool flag;

            //Pido al usuario que ingrese el código de tarea y a la vez valido el input ingresado
            do
            {
                Console.WriteLine("Ingrese el código de la tarea que desea cambiar su estado");
                _codigo = Console.ReadLine();
                flag = ValidacionesInput.FuncionValidacionCodigo(_codigo, ref _codigoValidado);

            } while (flag == false);

            Console.WriteLine("Ahora ingrese el estado que desea poner para la tarea con código " + _codigoValidado);

            //Se valida que el estado ingresado no sea distinto de las opciones permitidas
            ValidacionesInput.FuncionValidacionEstado(ref _estado);

            //Llamo al método 'CambiarEstado' de la clase 'Tablero' para que busque el código y haga el cambio correspondiente
            t.CambiarEstado(_codigoValidado, _estado);
        }

        //Método para agregar una nueva tarea al tablero
        public static void Agregar(Tablero tableroElectronico)
        {
            //Declaración de variables
            string _descripcion;
            string _orden;
            int _ordenValidado = 0;
            string _fechaAlta;
            DateTime _fechaAltaValidada = DateTime.Now;
            string _fechaFin;
            DateTime _fechaFinValidada = DateTime.Now;
            bool flag;

            //Pido al usuario que ingrese los datos de la tarea y a la vez valido cada input ingresado
            do
            {
                Console.WriteLine("Ingrese la descripción de la nueva tarea");
                _descripcion = Console.ReadLine();
                flag = ValidacionesInput.FuncionValidacionCadena(ref _descripcion);

            }while (flag == false);

            do
            {
                Console.WriteLine("Ingrese el número de orden de la nueva tarea");
                _orden = Console.ReadLine();
                flag = ValidacionesInput.FuncionValidacionNumero(_orden, ref _ordenValidado);

            } while (flag == false);

            do
            {
                Console.WriteLine("Ingrese la fecha de alta de la nueva tarea");
                _fechaAlta = Console.ReadLine();
                flag = ValidacionesInput.FuncionValidacionFechaAlta(_fechaAlta, ref _fechaAltaValidada);

            } while (flag == false);

            do
            {
                Console.WriteLine("Ingrese la fecha de finalización de la nueva tarea");
                _fechaFin = Console.ReadLine();
                flag = ValidacionesInput.FuncionValidacionFechaFin(_fechaFin, ref _fechaFinValidada);

            } while (flag == false);

            //Instancio la clase Tarea y la agrego al Tablero
            Tarea t = new Tarea(
                _descripcion,
                _ordenValidado,
                _fechaAltaValidada,
                _fechaFinValidada
                );

            tableroElectronico.AgregarTarea(t);

            Console.WriteLine("La tarea fue agregada exitosamente al tablero, presione Enter para elegir otra opción.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Salir()
        {
            Console.WriteLine("Usted ha salido del tablero, presione Enter");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
