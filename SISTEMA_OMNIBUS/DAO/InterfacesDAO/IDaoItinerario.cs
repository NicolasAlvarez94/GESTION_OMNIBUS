using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace DAO
{
    public interface IDaoItinerario
    {
        void agregarItinerario(Itinerario recorridoAsignado);

        List<Itinerario> traerItinerario();

        List<Recorrido> traerRecorridosdeItinerario();

        DataTable traerInformacionItinerario();
        
    }
}
