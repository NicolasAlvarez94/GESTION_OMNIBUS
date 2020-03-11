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
    public class ImplementacionDaoRecorrido : IDaoRecorrido
    {
        public void agregarRecorrido(List<Terminal> terminales)
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "INSERT INTO RECORRIDO VALUES (@TERMINALES_RECORRIDO)";
            objComando.CommandType = CommandType.Text;

            string strTerminales = "";
            List<Terminal> terminalesRecorrido = terminales;        

            foreach(Terminal terminal in terminalesRecorrido)
            {
                strTerminales += terminal.NombreTerminal + "-";
            }

            objComando.Parameters.AddWithValue("@TERMINALES_RECORRIDO", strTerminales);
            objConexion.Open();
            objComando.ExecuteNonQuery();
            objConexion.Close();
        }


        public int obtenerIdRecorridoMaximo()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            int intMaximoIdRegistro = 0;

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT MAX(ID) FROM RECORRIDO";
            objComando.CommandType = CommandType.Text;
           
            objConexion.Open();
            try
            {
                intMaximoIdRegistro = Convert.ToInt32(objComando.ExecuteScalar());
                objConexion.Close();
                return intMaximoIdRegistro;
            }
            catch (InvalidCastException)
            {
                objConexion.Close();
                return intMaximoIdRegistro;
            }                                             
        }

        public List<Recorrido> traerRecorridos()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();
            List<Recorrido> recorridos = new List<Recorrido>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT * FROM RECORRIDO";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach(DataRow recorrido in objTablaDatos.Rows)
            {
                Recorrido objRecorrido = new Recorrido();
                objRecorrido.IdRecorrido = Convert.ToInt32(recorrido["ID"]);
                objRecorrido.Terminales = recorrido["TERMINALES_RECORRIDO"].ToString();
                recorridos.Add(objRecorrido);
            }
            return recorridos;
        }
    }
}
