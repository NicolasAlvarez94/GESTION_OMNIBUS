using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISTA
{
    class FabricaInterfazSubMenuEstadisticas : FabricaInterfazMenuPrincipal
    {
        public override IInterfazSubMenu crearSubMenu()
        {
            return new InterfazEstadisticas();
        }
    }
}
