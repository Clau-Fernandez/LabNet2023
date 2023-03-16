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

            Validations validations = new Validations();
            int opcion = validations.ValidatingNumberEntry();

            if (opcion == 1) 
            {
                MenuCategories menuCategories = new MenuCategories();
                menuCategories.ShowMenu();

                Console.WriteLine("Ingresa el numero del método que queres ejecutar");
                int numberCase = validations.ValidatingCaseNumbers();
                menuCategories.ChooseMethodToExecute(numberCase);

            }
            else if (opcion == 2) 
            {
                Console.WriteLine("ingresaste 2");
            }

            Console.WriteLine("Saliste");


           

            




            Console.ReadLine();
        }
    }




   
}
