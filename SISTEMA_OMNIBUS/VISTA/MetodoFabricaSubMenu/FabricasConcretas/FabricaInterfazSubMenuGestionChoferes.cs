﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISTA
{
    class FabricaInterfazSubMenuGestionChoferes : FabricaInterfazMenuPrincipal
    {
        public override IInterfazSubMenu crearSubMenu()
        {
            return new InterfazGestionChoferes();
        }
    }
}
