using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using MODELO;


namespace CONTROLADOR
{
    public class ControladorUsuario
    {
        IDaoUsuario usuarioDAO = new ImplementacionDaoUsuario();
        Usuario objUsuario = new Usuario();

        public void agregarUsuario(Usuario usuario)
        {
            usuarioDAO.agregarUsuario(usuario);
        }

        public List<Usuario> traerUsuarios()
        {
            return usuarioDAO.traerUsuarios();
        }

        public List<string> traerDniUsuarios()
        {
            return usuarioDAO.traerDniUsuarios();
        }

        public Boolean validarNombre(string nombre)
        {
            return objUsuario.validarNombre(nombre);
        }

        public Boolean validarFechaNacimiento(string fecha)
        {
            return objUsuario.validarFechaNacimiento(fecha);
        }

        public Boolean validarDniExistenteRegistrado(List<string> dniPersonas, string DNIaRegistrar)
        {
            return objUsuario.validarDniExistenteRegistrado(dniPersonas, DNIaRegistrar);
        }

        public Boolean validarUsuarioExistente(List<Usuario> usuarios, int numeroUsuario, string dniUsuario)
        {
            return objUsuario.validarUsuarioExistente(usuarios, numeroUsuario, dniUsuario);
        }

        public int traerMaximoIdUsuario()
        {
            return usuarioDAO.traerMaximoIdUsuario();
        }
    }
}
