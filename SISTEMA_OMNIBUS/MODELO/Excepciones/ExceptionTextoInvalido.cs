using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ExceptionTextoInvalido: Exception
    {
        public void mensajeError()
        {
            Console.WriteLine("No se Permite el Ingreso de Numeros");
        }
    }
}
