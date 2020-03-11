using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISTA
{
    class FabricaInterfazSubMenuVentaPasajes : FabricaInterfazMenuPrincipal
    {
        public override IInterfazSubMenu crearSubMenu()
        {
            return new InterfazVentaPasajes();
        }
    }
}
