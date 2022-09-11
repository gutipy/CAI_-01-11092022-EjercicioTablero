using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTablero.Dominio
{
    public class Tarea
    {
        //Atributos
        private int _codigo;
        private string _descripcion;
        private string _estado;
        private int _orden;
        private DateTime _fechaAlta;
        private DateTime _fechaRealizacion;

        //Constructor
        public Tarea(string descripcion, int orden, DateTime fechaAlta, DateTime fechaRealizacion)
        {
            _descripcion = descripcion;
            _estado = "No iniciada";
            _orden = orden;
            _fechaAlta = fechaAlta;
            _fechaRealizacion = fechaRealizacion;
        }

        //Propiedades
        public int Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
        }

        public string Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        public int Orden
        {
            get
            {
                return _orden;
            }
        }

        public DateTime FechaAlta
        {
            get
            {
                return _fechaAlta;
            }
        }

        public DateTime FechaRealizacion
        {
            get
            {
                return _fechaRealizacion;
            }
        }

        //Función que valida si la tarea solicitada está finalizada
        public bool IsFinalizada()
        {
            if(Estado == "Finalizada")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
