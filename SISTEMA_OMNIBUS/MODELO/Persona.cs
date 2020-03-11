using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public abstract class Persona
    {

        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string DNI { set; get; }



        public Boolean validarDniExistenteRegistrado(List<string> dniPersonas, string DNIaRegistrar)
        {
            Boolean validarDni = true;

            foreach (string dniPersona in dniPersonas)
            {
                if (dniPersona == DNIaRegistrar)
                {
                    validarDni = false;
                    break;
                }
            }
            return validarDni;
        }


        public Boolean validarNombre(string nombre)
        {
            string[] numeros = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool boolValidar = true;

            for (int i = 0; i < nombre.Length - 1; i++)
            {
                for (int g = 0; g < numeros.Length - 1; g++)
                {
                    if (nombre[i] == Convert.ToChar(numeros[g]))
                    {
                        boolValidar = false;
                        return boolValidar;
                    }
                }
            }
            return boolValidar;
        }



    }
}
