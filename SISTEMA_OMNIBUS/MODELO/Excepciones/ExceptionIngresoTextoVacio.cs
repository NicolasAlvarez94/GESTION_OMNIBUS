using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ExceptionIngresoTextoVacio : Exception
    {
        public void mensajeError()
        {
            Console.WriteLine("Ingreso no Valido");
        }
    }
}
