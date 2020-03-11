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
    public class ImplementacionDaoDia : IDaoDia
    {
        public List<Dia> traerDias()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();
            List<Dia> dias = new List<Dia>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT * FROM DIA";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach(DataRow dia in objTablaDatos.Rows)
            {
                Dia objDia = new Dia();
                objDia.IdDia = Convert.ToInt32(dia["ID"]);
                objDia.Nombre = dia["NOMBRE"].ToString();
                dias.Add(objDia);
            }
            return dias;
        }
    }
}
