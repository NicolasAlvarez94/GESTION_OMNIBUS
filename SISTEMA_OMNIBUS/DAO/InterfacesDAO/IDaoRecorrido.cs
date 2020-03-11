using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace DAO
{
    public interface IDaoRecorrido
    {
        void agregarRecorrido(List<Terminal> terminales);

        int obtenerIdRecorridoMaximo();

        List<Recorrido> traerRecorridos();
    }
}
