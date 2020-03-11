using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using MODELO;

namespace CONTROLADOR
{
    public class ControladorCompra
    {
        IDaoCompra compraDAO = new ImplementacionDaoCompra();
        Compra objCompra = new Compra();

        public void agregarCompra(Compra compra)
        {
            compraDAO.agregarCompra(compra);
        }

        public DataTable traerCantidadPasajesVendidosPorUsuario()
        {
            return compraDAO.traerCantidadPasajesVendidosPorUsuario();
        }

        public int traerCantidadPasajesVendidosTotal()
        {
            return compraDAO.traerCantidadPasajesVendidosTotal();
        }

        public void mostrarComprasPorUsuario(DataTable comprasPorUsuarios)
        {
            objCompra.mostrarComprasPorUsuario(comprasPorUsuarios);
        }
    }
}
