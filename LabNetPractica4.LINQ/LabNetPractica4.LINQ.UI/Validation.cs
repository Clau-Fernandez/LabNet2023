using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica4.LINQ.UI
{
    public class Validation
    {
        public int ValidatingCaseNumbers()
        {
            int opcion = 0;
            bool numValido = false;

            while (!numValido)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out opcion))
                {
                    if (opcion >= 1 && opcion <= 13)
                    {
                        numValido = true;
                        return opcion;
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida. Recordá que solo podés ingresar un número del 1 al 5");
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Recordá que solo podés ingresar un número del 1 al 5\n");
                }
            }

            return opcion;
        }


    }
}
