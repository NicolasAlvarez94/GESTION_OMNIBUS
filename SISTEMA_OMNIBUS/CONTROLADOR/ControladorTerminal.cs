using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using MODELO;

namespace CONTROLADOR
{
    public class ControladorTerminal
    {
        IDaoTerminal terminalDAO = new ImplementacionDaoTerminal();
        Terminal objTerminal = new Terminal();

        public void agregarTerminal(Terminal terminal)
        {            
            terminalDAO.agregarTerminal(terminal);
        }

        public List<Terminal> traerTerminales()
        {
            return terminalDAO.traerTerminales();
        }

        public bool validarAltaTerminal(Terminal terminal)
        {
            return objTerminal.validarAltaTerminal(terminal);
        }

        public void mostrarNombresTerminales(List<Terminal> terminales)
        {
            objTerminal.mostrarNombresTerminales(terminales);
        }

        public Boolean validarTerminalesSeleccionadas(Terminal terminalPartida, Terminal terminalArribo)
        {
            return objTerminal.validarTerminalesSeleccionadas(terminalPartida, terminalArribo);
        }

        public Boolean validarTerminalesEnRecorridos(List<Recorrido> recorridos, Terminal partida, Terminal arribo)
        {
            return objTerminal.validarTerminalesEnRecorridos(recorridos, partida, arribo);
        }



    }
}
