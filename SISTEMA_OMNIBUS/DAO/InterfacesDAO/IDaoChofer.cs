using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;
using System.Data;

namespace DAO
{
    public interface IDaoChofer
    {
        void agregarChofer(Chofer chofer);

        List<string> traerDNIChoferes();

        List <Chofer> traerChoferes();

    }
}
