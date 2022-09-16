using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTablero.Dominio.Exceptions
{
    public class FechaAltaMayorAFechaFinException : Exception
    {
        public FechaAltaMayorAFechaFinException() : base("ERROR! La fecha de alta de una tarea no puede ser superior a la fecha de finalización de la misma, por favor intente nuevamente.") { }
    }
}
