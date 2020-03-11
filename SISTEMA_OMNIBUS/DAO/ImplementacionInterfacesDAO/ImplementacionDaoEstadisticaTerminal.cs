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
    public class ImplementacionDaoEstadisticaTerminal : IDaoEstadisticaTerminal
    {
        public void agregarEstadisticaTerminal(EstadisticaTerminal estadisticaTerminal)
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "INSERT INTO ESTADISTICA_TERMINALES VALUES (@ID_TERMINAL_PARTIDA, @ID_TERMINAL_ARRIBO)";
            objComando.CommandType = CommandType.Text;

            objComando.Parameters.AddWithValue("@ID_TERMINAL_PARTIDA", estadisticaTerminal.IdTerminalPartida);
            objComando.Parameters.AddWithValue("@ID_TERMINAL_ARRIBO", estadisticaTerminal.IdTerminalArribo);
            
            objConexion.Open();
            objComando.ExecuteNonQuery();
            objConexion.Close();
        }

        public DataTable traerTerminalescomoPartida()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "PROC_TRAER_TERMINALES_COMO_PARTIDA";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReade = objComando.ExecuteReader();
            objTablaDatos.Load(objReade);
            objConexion.Close();

            return objTablaDatos;
        }

        public DataTable traerTerminalescomoArribo()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "PROC_TRAER_TERMINALES_COMO_ARRIBO";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReade = objComando.ExecuteReader();
            objTablaDatos.Load(objReade);
            objConexion.Close();

            return objTablaDatos;
        }
    }
}
