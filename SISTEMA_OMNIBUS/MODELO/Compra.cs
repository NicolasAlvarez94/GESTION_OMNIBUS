using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Compra
    {
        public int IdCompra { set; get; }
        public int IdFkItinerario { set; get; }
        public int IdFkUsuario { set; get; }
        public int CantidadPasajes { set; get; }


        public void mostrarComprasPorUsuario(DataTable comprasPorUsuarios)
        {
            foreach(DataRow compraPorUsuario in comprasPorUsuarios.Rows)
            {
                Console.Write(compraPorUsuario["NOMBRE"].ToString());
                Console.Write(" " + compraPorUsuario["APELLIDO"].ToString());
                Console.Write(" - CANTIDAD PASAJES COMPRADOS: (" + compraPorUsuario["CANTIDAD_PASAJES_VENDIDOS"].ToString() + ")");

                Console.WriteLine();
            }
        }

    }
}
