using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica1
{
    class Omnibus: TransportePublico
    {
        
        public override string Avanzar()
        {
            return "El  ómnibus avanza a la siguiente parada.";
        }

        public override string Detenerse()
        {
            return "EL ómnibus se detiene en la parada correspondiente.";
        }
    }
}
