using ProyectoTablero.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTablero.InterfazGrafica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaración de variables
            List<Tarea> _listadoTareas = new List<Tarea>();
            string estado = "";

            Tarea T1 = new Tarea("Tarea 1", 1, DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-7));
            Tarea T2 = new Tarea("Tarea 2", 2, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5));
            Tarea T3 = new Tarea("Tarea 3", 3, DateTime.Now.AddDays(-18), DateTime.Now.AddDays(-2));

            Tablero tableroElectronico = new Tablero("Trabajo", "Contiene tareas de trabajo", DateTime.Now.AddYears(-2));

            tableroElectronico.AgregarTarea(T1);
            tableroElectronico.AgregarTarea(T2);
            tableroElectronico.AgregarTarea(T3);

            _listadoTareas = tableroElectronico.TraerTareas(estado);

            Console.WriteLine(_listadoTareas);
        }
    }
}
