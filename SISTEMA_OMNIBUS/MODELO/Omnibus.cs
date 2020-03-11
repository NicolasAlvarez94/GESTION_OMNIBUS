using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Omnibus
    {
        public int NumeroUnidad { set; get; }
        public string Marca { set; get; }
        public string Modelo { set; get; }
        public int Capacidad { set; get; }
        public string Tipo { set; get; }


  
        public Boolean validarTipoOmnibus(string tipo)
        {
            Boolean boolValidarIngreso = ("BASICO" == tipo) || ("SEMI-CAMA" == tipo) || ("COCHE-CAMA" == tipo) || ("SUITE" == tipo);

            if (boolValidarIngreso)
                return true;
            else
                return false;                        
        }

        public Boolean validarCapacidadOmnibus(int capacidad)
        {
            if (capacidad > 0)
                return true;
            else
                return false;
        }


        public bool validarAltaOmnibus(Omnibus omnibus)
        {
            if (omnibus.Marca != " " && omnibus.Modelo != " " && omnibus.Capacidad.ToString() != " " && omnibus.Tipo != " ")           
                return true;            
            else
                return false;
        }


        public void mostrarOmnibus(List<Omnibus> omnibus)
        {
            int intContador = 1;

            foreach (Omnibus omnibu in omnibus)
            {
                Console.WriteLine(intContador + ") "+ omnibu.NumeroUnidad + " (" + omnibu.Marca + " - " +
                    omnibu.Modelo + " - " + omnibu.Tipo +  " - " +  omnibu.Capacidad + ")");

                intContador++;
            }
        }


    }




}
