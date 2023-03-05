using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica1
{
    abstract class TransportePublico
    {
        private int pasajeros;
        private String nombre;

        public int GetPasajeros() { return pasajeros; }
        public void SetPasajeros(int pasajeros)
        {
           this.pasajeros = pasajeros;
        }

        public String GetNombre() { return nombre; }
        public void SetNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
