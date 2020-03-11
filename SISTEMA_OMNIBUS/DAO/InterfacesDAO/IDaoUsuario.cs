using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace DAO
{
    public interface IDaoUsuario
    {
        void agregarUsuario(Usuario usuario);

        List<Usuario> traerUsuarios();
        List<string> traerDniUsuarios();

        int traerMaximoIdUsuario();

    }
}
