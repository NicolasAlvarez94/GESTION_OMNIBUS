using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace DAO
{
    public interface IDaoOmnibus
    {
        void agregarOmnibus(Omnibus omnibus);
        int obtenerNumeroUnidadIngresado();

        List<Omnibus> traerOmnibus();
    }
}
