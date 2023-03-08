using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{

    public static class MiMetodoExtensivo
    {
        public static int DividiendoPorCero(this int numero)
        {
            return numero / 0;

        }
    }


    public static class MisMetodos
    {
        public static double Division(double dividendo, double divisor)
        {
            double resultado = dividendo / divisor;
            return resultado;
        }
    }

    
}
