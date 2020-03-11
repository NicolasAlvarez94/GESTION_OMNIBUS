using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MODELO
{
    public class Chofer : Persona
    {
        public int NumeroLegajo { set; get; }





        public void mostrarChoferes(List<Chofer> choferes)
        {
            int intContador = 1;

            foreach (Chofer chofer in choferes)
            {
                Console.WriteLine(intContador + ") " + chofer.Nombre + " " + chofer.Apellido + " ("+ chofer.NumeroLegajo + ")");
                intContador++;
            }
        }

 




    }
}
