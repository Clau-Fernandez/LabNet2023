using LabNetPractica3.EF.Entities;
using LabNetPractica3.EF.Exceptions;
using LabNetPractica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido/a a la aplicación: Probando Métodos");
            Console.WriteLine("Tenemos dos tablas diferentes");
            Console.WriteLine("1.Tabla Categorias");
            Console.WriteLine("2.Tabla Remitentes");
            Console.WriteLine("Ingresa el numero de la tabla con la que quieras iniciar o x para salir");

            int option = 0;
            bool numValido = false;

            while (!numValido)
            {
                string input = Console.ReadLine();

                if (input == "x")
                {
                    Console.WriteLine("Gracias por usar la app, hasta pronto!");
                    break;

                }
                else if (int.TryParse(input, out option))
                {
                    if (option == 1)
                    {
                        Console.WriteLine("------CATEGORIAS------");
                        MenuCategories menuCategories = new MenuCategories();
                        menuCategories.ShowMenu();
                        menuCategories.ChooseMethodToExecute();

                        numValido = true;
                        
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("------REMITENTES------");
                        MenuShippers menuShippers = new MenuShippers(); 
                        menuShippers.ShowMenu();
                        menuShippers.ChooseMethodToExecute();
                      
                        numValido = true;
                        
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intentalo de nuevo..\n");
                }
            }
      

            Console.ReadLine();
        }
    }




   
}
