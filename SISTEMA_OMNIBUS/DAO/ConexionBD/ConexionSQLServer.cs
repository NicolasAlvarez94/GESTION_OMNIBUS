using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    abstract class ConexionSQLServer
    {

        static string conexion = @"server=DESKTOP-CJGMKNL;DataBase=GESTION_OMNIBUS;Integrated Security=true";


        public static string getConexion()
        {
            return conexion;
        }


    }
}
