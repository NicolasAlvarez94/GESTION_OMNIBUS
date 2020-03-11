using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;
using DAO;
using System.Data;

namespace CONTROLADOR
{
    public class ControladorEstadisticaTerminal
    {
        IDaoEstadisticaTerminal estadisticaTerminalDAO = new ImplementacionDaoEstadisticaTerminal();
        EstadisticaTerminal objEstadisticaTerminal = new EstadisticaTerminal();

        public void agregarEstadisticaTerminal(EstadisticaTerminal estadisticaTerminal)
        {
            estadisticaTerminalDAO.agregarEstadisticaTerminal(estadisticaTerminal);
        }

        public DataTable traerTerminalescomoPartida()
        {
            return estadisticaTerminalDAO.traerTerminalescomoPartida();
        }

        public DataTable traerTerminalescomoArribo()
        {
            return estadisticaTerminalDAO.traerTerminalescomoArribo();
        }

        public void mostrarEstadisticaTerminales(DataTable datosTerminales)
        {
            objEstadisticaTerminal.mostrarEstadisticaTerminales(datosTerminales);
        }
    }
}
