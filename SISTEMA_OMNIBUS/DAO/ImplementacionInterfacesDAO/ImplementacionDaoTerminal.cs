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
    public class ImplementacionDaoTerminal : IDaoTerminal
    {
        public void agregarTerminal(Terminal terminal)
        {
            SqlConnection objConexion = new SqlConnection();
            objConexion.ConnectionString = ConexionSQLServer.getConexion();
            
            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "INSERT INTO TERMINAL VALUES (@NOMBRE_TERMINAL, @NOMBRE_CIUDAD)";
            objComando.CommandType = CommandType.Text;

            objComando.Parameters.AddWithValue("@NOMBRE_TERMINAL", terminal.NombreTerminal);
            objComando.Parameters.AddWithValue("@NOMBRE_CIUDAD", terminal.NombreCiudad);

            objConexion.Open();
            objComando.ExecuteNonQuery();
            objConexion.Close();
        }

        public List <Terminal> traerTerminales()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());            
            DataTable objTablaDatos = new DataTable();
            List<Terminal> termianlesRegistradas = new List<Terminal>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT * FROM TERMINAL";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach (DataRow terminal in objTablaDatos.Rows)
            {
                Terminal objTerminal = new Terminal();
                objTerminal.IdTerminal = Convert.ToInt32(terminal["ID"]);
                objTerminal.NombreTerminal = terminal["NOMBRE_TERMINAL"].ToString();
                objTerminal.NombreCiudad = terminal["NOMBRE_CIUDAD"].ToString();
                termianlesRegistradas.Add(objTerminal);
            }
            return termianlesRegistradas;
        }
    }
}
