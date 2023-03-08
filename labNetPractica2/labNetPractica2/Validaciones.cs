using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    static class Validaciones
    {
        public static int ValidandoMenu()
        {

            int opcion = 0;
            bool numValido = false;

            while (!numValido)
            {
                Console.WriteLine("1.Método dividir por cero");
                Console.WriteLine("2.Método dividir dos números");
                Console.WriteLine("3.Método que dispara una excepción");
                Console.WriteLine("4.Método que devuelve una excepción personalizada");
                Console.WriteLine("\nIngrese un número entre 1 y 4 o 'x' para salir:\n");

                string input = Console.ReadLine();

                if (input == "x")
                {
                    Console.WriteLine("Gracias por usar la app, hasta pronto!");
                    break;
                    
                }
                else if (int.TryParse(input, out opcion))
                {
                    if (opcion >= 1 && opcion <= 4)
                    {
                        numValido = true;
                        return opcion;
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida. Recordá que solo podés ingresar un número entre 1 y 4 o 'x' si querés salir.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Recordá que solo podés ingresar un número entre 1 y 4 o 'x' si querés salir.\n");
                }
            }

            return opcion;
            
        }
    }
}
