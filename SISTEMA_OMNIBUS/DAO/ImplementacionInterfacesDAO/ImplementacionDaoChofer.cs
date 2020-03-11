using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public class ImplementacionDaoChofer : IDaoChofer
    {
        public void agregarChofer(Chofer chofer)
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "INSERT INTO CHOFER VALUES (@NOMBRE, @APELLIDO, @DNI)";
            objComando.CommandType = CommandType.Text;

            objComando.Parameters.AddWithValue("@NOMBRE", chofer.Nombre);
            objComando.Parameters.AddWithValue("@APELLIDO", chofer.Apellido);
            objComando.Parameters.AddWithValue("@DNI", chofer.DNI);

            objConexion.Open();
            objComando.ExecuteNonQuery();
            objConexion.Close();
        }

        public List<string> traerDNIChoferes()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();
            List<string> dniChoferesExistentes = new List<string>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT DNI FROM CHOFER";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach(DataRow fila in objTablaDatos.Rows)
            {
                dniChoferesExistentes.Add(fila["DNI"].ToString());
            }

            return dniChoferesExistentes;
        }

        public List<Chofer> traerChoferes()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();
            List<Chofer> choferes = new List<Chofer>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT LEGAJO, NOMBRE, APELLIDO FROM CHOFER";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach(DataRow chofer in objTablaDatos.Rows)
            {
                Chofer objChofer = new Chofer();
                objChofer.NumeroLegajo = Convert.ToInt32(chofer["LEGAJO"]);
                objChofer.Nombre = chofer["NOMBRE"].ToString();
                objChofer.Apellido = chofer["APELLIDO"].ToString();
                choferes.Add(objChofer);
            }
            return choferes;
        }

    }
}
