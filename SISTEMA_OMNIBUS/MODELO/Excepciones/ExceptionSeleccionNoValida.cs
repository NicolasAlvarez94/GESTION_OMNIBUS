using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ExceptionSeleccionNoValida : Exception
    {

        public void mensajeError()
        {
            Console.WriteLine("Seleccion no Valida.");
        }
    }
}
