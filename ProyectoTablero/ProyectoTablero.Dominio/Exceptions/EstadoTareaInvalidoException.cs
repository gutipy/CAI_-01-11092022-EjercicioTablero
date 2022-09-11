using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTablero.Dominio.Exceptions
{
    public class EstadoTareaInvalidoException : Exception
    {
        public EstadoTareaInvalidoException(string estado) : base("ERROR! El estado de tarea " + estado + " no corresponde a un estado existente, por favor intente nuevamente.") { }
    }
}
