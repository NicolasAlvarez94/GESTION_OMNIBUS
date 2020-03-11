using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISTA
{
    abstract class FabricaInterfazMenuPrincipal
    {

        public static IInterfazSubMenu crearInterfaz(int pOpcion)
        {
            FabricaInterfazMenuPrincipal interfazSubMenu = null;

            switch (pOpcion)
            {
                case 1:
                    interfazSubMenu = new FabricaInterfazSubMenuArmadoRecorridos();                  
                    break;
                case 2:
                    interfazSubMenu = new FabricaInterfazSubMenuGestionChoferes();
                    break;
                case 3:
                    interfazSubMenu = new FabricaInterfazSubMenuVentaPasajes();
                    break;
                case 4:
                    interfazSubMenu = new FabricaInterfazSubMenuEstadisticas();
                    break;               
            }
            return interfazSubMenu.crearSubMenu();
        }

        public abstract IInterfazSubMenu crearSubMenu();
   


    }
}
