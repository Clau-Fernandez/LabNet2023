using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.UI
{
    public class Validations
    {
        public int ValidatingNumberEntry() 
        {
            int opcion = 0;
            bool numValido = false;

            while (!numValido)
            {                
                string input = Console.ReadLine();

                if (input == "x")
                {
                    Console.WriteLine("Gracias por usar la app, hasta pronto!");
                    break;

                }
                else if (int.TryParse(input, out opcion))
                {
                    if (opcion == 1)
                    {
                        numValido = true;
                        return opcion;
                    }
                    else if(opcion == 2)
                    {
                        numValido = true;
                        return opcion;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida.\n");
                }
            }

            return opcion;
        }

        public int ValidatingCaseNumbers() 
        {
            int opcion = 0;
            bool numValido = false;

            while (!numValido)
            {
                string input = Console.ReadLine();
                                
                if (int.TryParse(input, out opcion))
                {
                    if (opcion >= 1 && opcion <= 5)
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
