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
    public class ImplementacionDaoItinerario : IDaoItinerario
    {
        public void agregarItinerario(Itinerario recorridoAsignado)
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());           

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "INSERT INTO ITINERARIO VALUES (@ID_CHOFER, @ID_OMNIBUS, @ID_RECORRIDO, @ID_DIA)";
            objComando.CommandType = CommandType.Text;

            objComando.Parameters.AddWithValue("@ID_CHOFER", recorridoAsignado.IdChofer);
            objComando.Parameters.AddWithValue("@ID_OMNIBUS", recorridoAsignado.IdOmnibus);
            objComando.Parameters.AddWithValue("@ID_RECORRIDO", recorridoAsignado.IdRecorrido);
            objComando.Parameters.AddWithValue("@ID_DIA", recorridoAsignado.IdDia);

            objConexion.Open();
            objComando.ExecuteNonQuery();
            objConexion.Close();
        }

 

        public List<Itinerario> traerItinerario()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();
            List<Itinerario> recorridosAsignados = new List<Itinerario>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT * FROM ITINERARIO";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach (DataRow recorridoAsignado in objTablaDatos.Rows)
            {
                Itinerario objRecorridoAsignado = new Itinerario();
                objRecorridoAsignado.IdItinerario = Convert.ToInt32(recorridoAsignado["ID"]);
                objRecorridoAsignado.IdChofer = Convert.ToInt32(recorridoAsignado["ID_CHOFER"]);
                objRecorridoAsignado.IdOmnibus = Convert.ToInt32(recorridoAsignado["ID_OMNIBUS"]);
                objRecorridoAsignado.IdRecorrido = Convert.ToInt32(recorridoAsignado["ID_RECORRIDO"]);
                objRecorridoAsignado.IdDia = Convert.ToInt32(recorridoAsignado["ID_DIA"]);

                recorridosAsignados.Add(objRecorridoAsignado);
            }
            return recorridosAsignados;
        }



        public List<Recorrido> traerRecorridosdeItinerario()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();
            List<Recorrido> recorridos = new List<Recorrido>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT T.ID_RECORRIDO, R.TERMINALES_RECORRIDO AS TERMINALES FROM ITINERARIO AS T INNER JOIN RECORRIDO AS R ON                            (T.ID_RECORRIDO = R.ID) ";

            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach (DataRow recorrido in objTablaDatos.Rows)
            {
                Recorrido objRecorrido = new Recorrido();
                objRecorrido.IdRecorrido = Convert.ToInt32(recorrido["ID_RECORRIDO"]);
                objRecorrido.Terminales = recorrido["TERMINALES"].ToString();
                recorridos.Add(objRecorrido);
            }

            return recorridos;
        }



        public DataTable traerInformacionItinerario()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();            

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "PROC_TRAER_INFORMACION_ITINERARIO";
            objComando.CommandType = CommandType.StoredProcedure;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            return objTablaDatos;
        }



    }
}
