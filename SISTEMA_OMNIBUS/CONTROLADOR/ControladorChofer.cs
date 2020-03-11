using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using MODELO;

namespace CONTROLADOR
{
    public class ControladorChofer
    {
        IDaoChofer choferDAO = new ImplementacionDaoChofer();
        Chofer objChofer = new Chofer();

        public void agregarChofer(Chofer chofer)
        {
            choferDAO.agregarChofer(chofer);
        }

        public List<string> traerDNIChoferes()
        {
            return choferDAO.traerDNIChoferes();
        }

        public List<Chofer> traerChoferes()
        {
            return choferDAO.traerChoferes();
        }

        public Boolean validarDniExistenteRegistrado(List<string> dniPersonas, string DNIaRegistrar)
        {
            return objChofer.validarDniExistenteRegistrado(dniPersonas, DNIaRegistrar);
        }

        public Boolean validarNombre(string nombre)
        {
            return objChofer.validarNombre(nombre);
        }

        public void mostrarChoferes(List<Chofer> choferes)
        {
            objChofer.mostrarChoferes(choferes);
        }



    }
}
