using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Usuario : Persona
    {

        public int NumeroUsuario { set; get; }
        public DateTime FechaNacimiento { set; get; }




        public Boolean validarUsuarioExistente (List<Usuario> usuarios, int numeroUsuario, string dniUsuario)
        {
            Boolean validarUsuarioExistente = false;

            foreach(Usuario usuario in usuarios)
            {
                int intNumeroUsuario = usuario.NumeroUsuario;
                string strDniUsuario = usuario.DNI;

                if (intNumeroUsuario == numeroUsuario && strDniUsuario == dniUsuario)
                {
                    validarUsuarioExistente = true;
                    break;
                }                    
            }
            return validarUsuarioExistente;
        }



        public Boolean validarFechaNacimiento(string fecha)
        {
            Boolean validacionFecha = false;
            string strDia = "";
            string strMes = "";
            string strAño = "";

            if (fecha.Length == 10)
            {
                int intContador = 0;
                for (int i = 0; i <= fecha.Length - 1; i++)
                {
                    if (fecha[i] != '/' && intContador <= 1)
                        strDia += fecha[i];
                    else if (fecha[i] != '/' && intContador <= 4)
                        strMes += fecha[i];
                    else if (fecha[i] != '/' && intContador <= 9)
                        strAño += fecha[i];

                    intContador++;
                }
                validacionFecha = validarDiaMesYaño(strDia, strMes, strAño);                
            }
            return validacionFecha;
        }


        private Boolean validarDiaMesYaño(string dia, string mes, string año)
        {
            DateTime fechaActual = DateTime.Today;
             
            int intDia = Convert.ToInt32(dia);
            int intMes = Convert.ToInt32(mes);
            int intAño = Convert.ToInt32(año);

            if (intDia <= 31 && intMes <= 12 && intAño <= fechaActual.Year)
                return true;
            else
                return false;            
        }



    }
}
