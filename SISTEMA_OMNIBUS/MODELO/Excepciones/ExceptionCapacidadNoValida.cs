using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ExceptionCapacidadNoValida : Exception
    {
        public void mensajeError()
        {
            Console.WriteLine("El Ingreso de la Capacidad no es Valida");
        }
    }
}
