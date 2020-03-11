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
    public class ControladorItinerario
    {
        IDaoItinerario itineraioDAO = new ImplementacionDaoItinerario();
        Itinerario objItinerario = new Itinerario();

        public void agregarItinerario(Itinerario itinerario)
        {
            itineraioDAO.agregarItinerario(itinerario);
        }

        public List<Itinerario> traerItinerario()
        {
            return itineraioDAO.traerItinerario();
        }

        public List<Recorrido> traerRecorridosdeItinerario()
        {
            return itineraioDAO.traerRecorridosdeItinerario();
        }

        public DataTable traerInformacionItinerario()
        {
            return itineraioDAO.traerInformacionItinerario();
        }

        public Boolean validarDiadelViajeChofer(List<Itinerario> itinerariosRegistrados, Itinerario ItinerarioaRegistrar)
        {
            return objItinerario.validarDiadelViajeChofer(itinerariosRegistrados, ItinerarioaRegistrar);
        }

        public Boolean validarDiadeReservaOmnibus(List<Itinerario> itinerariosRegistrados, Itinerario ItinerarioaRegistrar)
        {
            return objItinerario.validarDiadeReservaOmnibus(itinerariosRegistrados, ItinerarioaRegistrar);
        }

        public void mostrarItinerarioDeTerminalesSeleccionadas(DataTable informacionItinerario, Terminal terminalPartida, Terminal terminalArribo)
        {
            objItinerario.mostrarItinerarioDeTerminalesSeleccionadas(informacionItinerario, terminalPartida, terminalArribo);
        }

        public Boolean validarSeleccionItinerario(int seleccion)
        {
            return objItinerario.validarSeleccionItinerario(seleccion);
        }
    }
}
