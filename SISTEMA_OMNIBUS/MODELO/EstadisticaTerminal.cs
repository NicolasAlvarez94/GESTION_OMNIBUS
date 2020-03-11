using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class EstadisticaTerminal
    {
        public int IdTerminalPartida { set; get; }
        public int IdTerminalArribo { set; get; }


        public EstadisticaTerminal() { }

        public EstadisticaTerminal (int idPartida, int idArribo)
        {
            this.IdTerminalPartida = idPartida;
            this.IdTerminalArribo = idArribo;
        }


        public void mostrarEstadisticaTerminales(DataTable datosTerminales)
        {
            foreach (DataRow estadisticaTerminal in datosTerminales.Rows)
            {
                Console.Write(estadisticaTerminal["NOMBRE_TERMINAL"].ToString() + " (");
                Console.Write(estadisticaTerminal["CANTIDAD"].ToString() + ")");
                Console.WriteLine();
            }
        }


    }
}
