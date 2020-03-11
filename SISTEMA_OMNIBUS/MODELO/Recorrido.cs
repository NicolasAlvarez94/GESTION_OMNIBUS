using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MODELO
{
    public class Recorrido
    {
  
        public int IdRecorrido { set; get; }

        public string Terminales { set; get; }


        public Boolean validarRecorrido(List<Recorrido> recorridos, int seleccionIdRecorrido)
        {
            if (seleccionIdRecorrido <= recorridos.Count)
                return true;
            else
                return false;            
        }


        public void mostrarRecorridos(List<Recorrido> recorridos)
        {
            int intContadorRegistro = 1;

            foreach(Recorrido recorrido in recorridos)
            {
                Console.WriteLine(intContadorRegistro + ") "+ recorrido.Terminales);
                intContadorRegistro++;
            }               
        }





    }
}
