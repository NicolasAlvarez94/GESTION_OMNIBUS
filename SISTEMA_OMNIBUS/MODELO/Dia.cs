using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Dia
    {
        public int IdDia { set; get; }

        public string Nombre { set; get; }



        public Boolean validarDia (int seleccion)
        {
            if (seleccion >= 1 && seleccion <= 7)
                return true;
            else
                return false;
        }


        public void mostrarDias (List<Dia> dias)
        {           
            foreach(Dia dia in dias)
            {
                Console.WriteLine(dia.IdDia + ") " + dia.Nombre);
            }
        }

    }
}
