using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Terminal
    {

        public int IdTerminal { set; get; }
        public string NombreTerminal { set; get; }
        public string NombreCiudad { set; get; }



        public Boolean validarTerminalesSeleccionadas(Terminal terminalPartida, Terminal terminalArribo)
        {
            if (terminalPartida.NombreTerminal != terminalArribo.NombreTerminal)
                return true;
            else
                return false;
        }



        public bool validarAltaTerminal(Terminal terminal)
        {
            if (terminal.NombreTerminal != "" && terminal.NombreCiudad != "")
                return true;
            else
                return false;
        }



        public Boolean validarTerminalesEnRecorridos(List<Recorrido> recorridos, Terminal partida, Terminal arribo)
        {
            Boolean boolValidacion = false;

            string strTerminalPartida = partida.NombreTerminal;
            string strTerminalArribo = arribo.NombreTerminal;

            foreach (Recorrido recorrido in recorridos)
            {
                int intContadorValidar = 0;
                string [] terminales = recorrido.Terminales.Split('-');

                foreach(string terminal in terminales)
                {                    
                    if (terminal == strTerminalPartida || terminal == strTerminalArribo)
                        intContadorValidar++;

                    if (intContadorValidar == 2)
                    {
                        boolValidacion = true;
                        break;
                    }                    
                }
            }
            return boolValidacion;
        }


        public void mostrarNombresTerminales(List<Terminal> terminales)
        {
            int intContador = 1;

            foreach (Terminal terminal in terminales)
            {
                Console.WriteLine(intContador + ") " + terminal.NombreTerminal);
                intContador++;
            }
        }




    }
}
