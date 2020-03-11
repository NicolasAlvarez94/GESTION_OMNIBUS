using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using MODELO;

namespace CONTROLADOR
{
    public class ControladorDia
    {
        IDaoDia diaDAO = new ImplementacionDaoDia();
        Dia objDia = new Dia();

        public List<Dia> traerDias()
        {
            return diaDAO.traerDias();
        }

        public void mostrarDias(List<Dia> dias)
        {
            objDia.mostrarDias(dias);
        }

        public Boolean validarDia(int seleccion)
        {
            return objDia.validarDia(seleccion);
        }
    }
}
