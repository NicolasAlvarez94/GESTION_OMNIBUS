using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace DAO
{
    public interface IDaoEstadisticaTerminal
    {
        void agregarEstadisticaTerminal(EstadisticaTerminal estadisticaTerminal);

        DataTable traerTerminalescomoPartida();

        DataTable traerTerminalescomoArribo();
    }
}
