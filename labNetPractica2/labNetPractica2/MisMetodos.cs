using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    static class MisMetodos
    {
        public static int DividirPorCero(int numero)
        {
            int resultado = numero / 0;
            return resultado;
            
        }

        public static double Division(double dividendo, double divisor)
        {
            double resultado = dividendo / divisor;
            return resultado;
        }
    }
}
