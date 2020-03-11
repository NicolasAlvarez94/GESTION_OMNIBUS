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
    public class ImplementacionDaoOmnibus : IDaoOmnibus
    {
        public void agregarOmnibus(Omnibus omnibus)
        {
            SqlConnection objConexion = new SqlConnection();
            objConexion.ConnectionString = ConexionSQLServer.getConexion();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "INSERT INTO OMNIBUS VALUES (@MARCA, @MODELO, @TIPO, @CAPACIDAD)";
            objComando.CommandType = CommandType.Text;

            objComando.Parameters.AddWithValue("@MARCA", omnibus.Marca);
            objComando.Parameters.AddWithValue("@MODELO", omnibus.Modelo);
            objComando.Parameters.AddWithValue("@TIPO", omnibus.Tipo);
            objComando.Parameters.AddWithValue("@CAPACIDAD", omnibus.Capacidad);
            

            objConexion.Open();
            objComando.ExecuteNonQuery();
            objConexion.Close();
        }

        public int obtenerNumeroUnidadIngresado()
        {
            SqlConnection objConexion = new SqlConnection();
            objConexion.ConnectionString = ConexionSQLServer.getConexion();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT COUNT(*) FROM OMNIBUS";
            objComando.CommandType = CommandType.Text;

          

            objConexion.Open();
            int dato = Convert.ToInt32(objComando.ExecuteScalar());
            objConexion.Close();

            return dato;
        }


        public List<Omnibus> traerOmnibus()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();
            List<Omnibus> omnibusRegistrados = new List<Omnibus>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT * FROM OMNIBUS";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach(DataRow omnibus in objTablaDatos.Rows)
            {
                Omnibus objOmnibus = new Omnibus();
                objOmnibus.NumeroUnidad = Convert.ToInt32(omnibus["NUMERO_UNIDAD"]);
                objOmnibus.Marca = omnibus["MARCA"].ToString();
                objOmnibus.Modelo = omnibus["MODELO"].ToString();
                objOmnibus.Tipo = omnibus["TIPO"].ToString();
                objOmnibus.Capacidad = Convert.ToInt32(omnibus["CAPACIDAD"]);
                omnibusRegistrados.Add(objOmnibus);
            }
            return omnibusRegistrados;
        }
    }
}
