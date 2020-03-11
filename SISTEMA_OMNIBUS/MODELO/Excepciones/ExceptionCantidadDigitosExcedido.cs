using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ExceptionCantidadDigitosExcedido : Exception
    {

        public void mensajeIngresoIncorrecto()
        {
            Console.WriteLine("Se ha Excedido la Longitud de Digitos en el Ingreso.");
        }
    }
}
