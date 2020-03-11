using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MODELO;
using DAO;

namespace CONTROLADOR
{
    public class ControladorRecorrido
    {
        IDaoRecorrido recorridoDAO = new ImplementacionDaoRecorrido();
        Recorrido objRecorrido = new Recorrido();

        public void agregarRecorrido(List<Terminal> terminales)
        {
            recorridoDAO.agregarRecorrido(terminales);
        }

        public List<Recorrido> traerRecorridos()
        {
            return recorridoDAO.traerRecorridos();
        }

        public int obtenerIdRecorridoMaximo()
        {
            return recorridoDAO.obtenerIdRecorridoMaximo();
        }

        public void mostrarRecorridos(List<Recorrido> recorridos)
        {
            objRecorrido.mostrarRecorridos(recorridos);
        }

        public Boolean validarRecorrido(List<Recorrido> recorridos, int seleccion)
        {
            return objRecorrido.validarRecorrido(recorridos, seleccion);
        }

    }
}
