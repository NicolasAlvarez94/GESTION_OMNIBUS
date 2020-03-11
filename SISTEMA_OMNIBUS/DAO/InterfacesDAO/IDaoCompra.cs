using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace DAO
{
    public interface IDaoCompra
    {
        void agregarCompra(Compra compra);

        DataTable traerCantidadPasajesVendidosPorUsuario();

        int traerCantidadPasajesVendidosTotal();

    }
}
