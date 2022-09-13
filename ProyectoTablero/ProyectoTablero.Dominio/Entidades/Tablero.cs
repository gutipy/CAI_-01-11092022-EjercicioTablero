using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTablero.Dominio;
using ProyectoTablero.Dominio.Exceptions;

namespace ProyectoTablero.Dominio
{
    public class Tablero
    {
        //Atributos
        private string _titulo;
        private string _descripcion;
        private List<Tarea> _tareas = new List<Tarea>();
        private DateTime _fechaInicioProyecto;

        //Constructor
        public Tablero(string titulo, string descripcion, DateTime fechaInicioProyecto)
        {
            _titulo = titulo;
            _descripcion = descripcion;
            _tareas = new List<Tarea>();
            _fechaInicioProyecto = fechaInicioProyecto;
        }

        //Propiedades
        public string Titulo
        {
            get
            {
                return _titulo;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
        }

        public List<Tarea> Tareas
        {
            get
            {
                return _tareas;
            }
        }

        public DateTime FechaInicioProyecto
        {
            get
            {
                return _fechaInicioProyecto;
            }
        }

        //Método para agregar una tarea al tablero
        public void AgregarTarea(Tarea tarea)
        {
            //Asignación del código de tarea de manera incremental
            tarea.Codigo = _tareas.Count + 1;

            _tareas.Add(tarea);
        }

        //Método para cambiar el estado de una tarea
        public void CambiarEstado(int codigo, string estado)
        {
            foreach(Tarea t in _tareas)
            {
                if(t.Codigo == codigo)
                {
                    t.Estado = estado;
                }
            }

            Console.WriteLine("Cambio satisfactorio! La tarea con codigo " + codigo + " ahora posee el estado " + estado);

        }

        //Función para listar las tareas del tablero
        public List<Tarea> TraerTareas(string estado)
        {
            //Declaración de lista
            List<Tarea> _tareasTablero = new List<Tarea>();

            if (string.IsNullOrEmpty(estado))
            {
                foreach (Tarea t in _tareas)
                {
                    _tareasTablero.Add(t);

                    Console.WriteLine(t.Codigo + " " + t.Descripcion + " " + t.Estado + " " + t.Orden + " " + t.FechaAlta + " " + t.FechaRealizacion);
                }
            }
            else
            {
                foreach(Tarea t in _tareas)
                {
                    if (t.Estado == estado)
                    {
                        _tareasTablero.Add(t);

                        Console.WriteLine(
                            t.Codigo + " " + t.Descripcion + " " + t.Estado + " " + t.Orden + " " + t.FechaAlta + " " + t.FechaRealizacion
                            )
                            ;
                    }
                    else
                    {
                        throw new EstadoTareaInvalidoException(estado);
                    }
                }
            }

            return _tareasTablero;
        }

        //Función para buscar y traer la tarea más antigua del tablero
        public void TraerTareaMasAntigua()
        {
            //Declaración de variables
            DateTime _fechaAltaTareaMasAntigua = DateTime.Now;
            int _codigoTarea = 0;
            

            foreach (Tarea t in _tareas)
            {
                if(t.FechaAlta < _fechaAltaTareaMasAntigua)
                {
                    _fechaAltaTareaMasAntigua = t.FechaAlta;
                    _codigoTarea = t.Codigo;
                }
            }

            Console.WriteLine("La tarea más antigua es la que tiene código: " + _codigoTarea + " y fecha de alta " + _fechaAltaTareaMasAntigua);
        }
    }
}
