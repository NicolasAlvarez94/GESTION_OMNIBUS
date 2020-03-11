using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MODELO;

namespace DAO
{
    public class ImplementacionDaoCompra : IDaoCompra
    {
        public void agregarCompra(Compra compra)
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "INSERT INTO COMPRA VALUES (@ID_ITINERARIO, @ID_USUARIO, @CANTIDAD_PASAJES)";
            objComando.CommandType = CommandType.Text;

            objComando.Parameters.AddWithValue("@ID_ITINERARIO", compra.IdFkItinerario);
            objComando.Parameters.AddWithValue("@ID_USUARIO", compra.IdFkUsuario);
            objComando.Parameters.AddWithValue("@CANTIDAD_PASAJES", compra.CantidadPasajes);

            objConexion.Open();
            objComando.ExecuteNonQuery();
            objConexion.Close();
        }

        public DataTable traerCantidadPasajesVendidosPorUsuario()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "PROC_TRAER_CANTIDAD_PASAJES_POR_USUARIO";
            objComando.CommandType = CommandType.StoredProcedure;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            return objTablaDatos;
        }

        public int traerCantidadPasajesVendidosTotal()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT SUM(CANTIDAD_PASAJES) AS CANTIDAD_PASAJES_VENDIDOS_TOTAL FROM COMPRA ";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            int intCantidadPasajesTotal =Convert.ToInt32(objComando.ExecuteScalar());
            objConexion.Close();

            return intCantidadPasajesTotal;
        }
    }
}
