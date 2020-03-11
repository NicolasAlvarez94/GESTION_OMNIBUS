using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using MODELO;

namespace CONTROLADOR
{
    public class ControladorOmnibus
    {
        IDaoOmnibus omnibusDao = new ImplementacionDaoOmnibus();
        Omnibus objOmnibus = new Omnibus();        

        public void agregarOmnibus(Omnibus omnibus)
        {            
            omnibusDao.agregarOmnibus(omnibus);
        }

        public int obtenerNumeroUnidadIngresado()
        {            
            return omnibusDao.obtenerNumeroUnidadIngresado();
        }

        public List<Omnibus> traerOmnibus()
        {
            return omnibusDao.traerOmnibus();
        }

        public Boolean validarCapacidadOmnibus(int capacidad)
        {
            return objOmnibus.validarCapacidadOmnibus(capacidad);
        }

        public Boolean validarTipoOmnibus(string tipo)
        {
            return objOmnibus.validarTipoOmnibus(tipo);
        }

        public bool validarAltaOmnibus(Omnibus omnibus)
        {            
            return objOmnibus.validarAltaOmnibus(omnibus);
        }

        public void mostrarOmnibus(List<Omnibus> omnibus)
        {
            objOmnibus.mostrarOmnibus(omnibus);
        }
    }
}
