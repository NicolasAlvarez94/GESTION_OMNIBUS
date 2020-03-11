using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ExceptionCantidadDigitosInsuficientes: Exception
    {

        public void mensajeIngresoIncorrecto()
        {
            Console.WriteLine("Digitos Insuficientes en el Ingreso.");
        }
    }


}
