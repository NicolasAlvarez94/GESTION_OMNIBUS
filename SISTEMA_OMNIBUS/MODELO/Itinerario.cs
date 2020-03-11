using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Itinerario
    {
        private static List<int> identificadoresItinerarios = new List<int>();

        public int IdItinerario { set; get; }
        public int IdChofer { set; get; }
        public int IdOmnibus { set; get; }
        public int IdRecorrido { set; get; }
        public int IdDia { set; get; }





        public Boolean validarDiadelViajeChofer(List<Itinerario> itinerariosRegistrados, Itinerario ItinerarioaRegistrar)
        {
            Boolean boolValidar = true;

            if (itinerariosRegistrados.Count > 0)
            {
                foreach(Itinerario itinerario in itinerariosRegistrados)
                {
                    int intIdChoferItinerario = itinerario.IdChofer;
                    int intIdChoferSeleccionado = ItinerarioaRegistrar.IdChofer;

                    int intIdDiaItinerario = itinerario.IdDia;
                    int intIdDiaSeleccionado = ItinerarioaRegistrar.IdDia;

                    if (intIdChoferItinerario == intIdChoferSeleccionado && intIdDiaItinerario == intIdDiaSeleccionado)
                    {
                        boolValidar = false;
                        break;
                    }
                }
            }
            return boolValidar;
        }



        public Boolean validarDiadeReservaOmnibus(List<Itinerario> itinerariosRegistrados, Itinerario ItinerarioaRegistrar)
        {
            Boolean boolValidar = true;

            if (itinerariosRegistrados.Count > 0)
            {
                foreach (Itinerario itinerario in itinerariosRegistrados)
                {
                    int intIdOmnibusItinerario = itinerario.IdOmnibus;
                    int intIdOmnibusSeleccionado = ItinerarioaRegistrar.IdOmnibus;

                    int intIdDiaItinerario = itinerario.IdDia;
                    int intIdDiaSeleccionado = ItinerarioaRegistrar.IdDia;

                    if (intIdOmnibusItinerario == intIdOmnibusSeleccionado && intIdDiaItinerario == intIdDiaSeleccionado)
                    {
                        boolValidar = false;
                        break;
                    }
                }
            }
            return boolValidar;
        }


       

        public void mostrarItinerarioDeTerminalesSeleccionadas(DataTable informacionItinerario, Terminal terminalPartida, Terminal terminalArribo)
        {
            string strTerminalPartida = terminalPartida.NombreTerminal;
            string strTerminalArribo = terminalArribo.NombreTerminal;
            int intContadorItinerario = 1;            

            foreach(DataRow itinerario in informacionItinerario.Rows)
            {
                int intContadorValidar = 0;
                string[] terminales = itinerario["TERMINALES"].ToString().Split('-');

                foreach (string terminal in terminales)
                {
                    if (terminal == strTerminalPartida || terminal == strTerminalArribo)
                        intContadorValidar++;

                    if (intContadorValidar == 2)
                    {
                        Console.WriteLine(intContadorItinerario + ") SELECCIONE IDENTIFICADOR: " + itinerario["ID"].ToString() +
                            " - RECORRIDO: (" + itinerario["TERMINALES"].ToString() + ") - CHOFER: " + itinerario["NOMBRE_CHOFER"].ToString() +
                            " - DIA: " + itinerario["DIA"].ToString() + " - TIPO OMNIBUS: " + itinerario["TIPO"].ToString());
                     
                        Itinerario.identificadoresItinerarios.Add(Convert.ToInt32(itinerario["ID"]));
                        intContadorItinerario++;
                        break;
                    }
                }
            }
        }



        public Boolean validarSeleccionItinerario(int seleccion)
        {
            Boolean validacion = false;

            foreach(int identificador in identificadoresItinerarios)
            {
                if (seleccion == identificador)
                {
                    validacion = true;
                    break;
                }
            }
            return validacion;
        }


  
    }
}
