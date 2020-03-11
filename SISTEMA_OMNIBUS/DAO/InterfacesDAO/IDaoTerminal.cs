using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;
using System.Data;

namespace DAO
{
    public interface IDaoTerminal
    {

        void agregarTerminal(Terminal terminal);

        List <Terminal> traerTerminales();
    }
}
