using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTablero.Dominio;

namespace ProyectoTablero.Dominio.Exceptions
{
    public class CodigoTareaNoExisteException : Exception
    {
        public CodigoTareaNoExisteException(int codigo) : base("ERROR! El código de tarea " + codigo + " no corresponde a una tarea existente, por favor intente nuevamente.") { }
    }
}
