using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ExceptionTipoOmnibusNoValido : Exception
    {
        public void mensajeError()
        {
            Console.WriteLine("El Tipo de Omnibus Ingresado no es Valido.");
        }
    }
}
