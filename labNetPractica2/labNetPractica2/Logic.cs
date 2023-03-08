using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    static class Logic
    {
        public static void MetodoQueLanzaExcepcion()
        {
            
            throw new ArgumentOutOfRangeException();
        }
    }

    class MiExcepcionPersonalizada : Exception
    {
        public MiExcepcionPersonalizada(string mensaje) : base("¡Hola! Soy un mensaje personalizado :D." + mensaje)
        {
        }

        public static void MetodoQueLanzaExcepcionPersonalizada()
        {
            
            throw new MiExcepcionPersonalizada("Se ha lanzado una excepción personalizada.");
        }
    }
}
