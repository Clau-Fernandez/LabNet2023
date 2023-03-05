using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica1
{
    class Taxi : TransportePublico
    {
        
        public override string Avanzar()
        {
            return "El taxi avanza tranquilo, no podemos decir lo mismo del taxímetro.";
        }

        public override string Detenerse()
        {
            return "El taxi se detiene donde le indica el pasajero.";
        }

        public double CalcularPrecioViaje(double metros)
        {
            double tarifaBase = 225;
            double precioPorMetro = metros * 0.1125;

            return precioPorMetro + tarifaBase;
        }

    }
}
