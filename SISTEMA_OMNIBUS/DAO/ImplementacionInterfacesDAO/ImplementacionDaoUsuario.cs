using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MODELO;

namespace DAO
{
    public class ImplementacionDaoUsuario : IDaoUsuario
    {
        public void agregarUsuario(Usuario usuario)
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "INSERT INTO USUARIO VALUES (@NOMBRE, @APELLIDO, @DNI, @FECHA_NACIMIENTO)";
            objComando.CommandType = CommandType.Text;

            objComando.Parameters.AddWithValue("@NOMBRE", usuario.Nombre);
            objComando.Parameters.AddWithValue("@APELLIDO", usuario.Apellido);
            objComando.Parameters.AddWithValue("@DNI", usuario.DNI);
            objComando.Parameters.AddWithValue("@FECHA_NACIMIENTO", usuario.FechaNacimiento);

            objConexion.Open();
            objComando.ExecuteNonQuery();
            objConexion.Close();
        }


        public List<Usuario> traerUsuarios()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            DataTable objTablaDatos = new DataTable();
            List<Usuario> usuarios = new List<Usuario>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT * FROM USUARIO";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach (DataRow usuario in objTablaDatos.Rows)
            {
                Usuario objUsuario = new Usuario();
                objUsuario.NumeroUsuario = Convert.ToInt32(usuario["ID"]);
                objUsuario.Nombre = usuario["NOMBRE"].ToString();
                objUsuario.Apellido = usuario["APELLIDO"].ToString();
                objUsuario.DNI = usuario["DNI"].ToString();
                objUsuario.FechaNacimiento = Convert.ToDateTime(usuario["FECHA_NACIMIENTO"]);

                usuarios.Add(objUsuario);
            }
            return usuarios;
        }


        public List<string> traerDniUsuarios()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());

            DataTable objTablaDatos = new DataTable();
            List<string> dniUsuarios = new List<string>();

            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT DNI FROM USUARIO";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            SqlDataReader objReader = objComando.ExecuteReader();
            objTablaDatos.Load(objReader);
            objConexion.Close();

            foreach(DataRow dni in objTablaDatos.Rows)
            {
                dniUsuarios.Add(dni["DNI"].ToString());
            }

            return dniUsuarios;
        }

        public int traerMaximoIdUsuario()
        {
            SqlConnection objConexion = new SqlConnection(ConexionSQLServer.getConexion());
            int intMaximoId = 0;
     
            SqlCommand objComando = new SqlCommand();
            objComando.Connection = objConexion;
            objComando.CommandText = "SELECT MAX(ID) FROM USUARIO";
            objComando.CommandType = CommandType.Text;

            objConexion.Open();
            try
            {                
                intMaximoId = Convert.ToInt32(objComando.ExecuteScalar());
                objConexion.Close();
                return intMaximoId;

            }
            catch (InvalidCastException)
            {
                objConexion.Close();
                return intMaximoId;
            }                       
        }


    }
}
