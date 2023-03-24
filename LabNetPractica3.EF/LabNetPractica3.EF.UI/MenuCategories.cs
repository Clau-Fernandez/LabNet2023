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
    public class MenuCategories : MenuBase
    {
        public override void ChooseMethodToExecute() 
        {
            
            DisplayLists displayLists = new DisplayLists();
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            CategoriesABMExceptions exceptions = new CategoriesABMExceptions();

            while (true)
            {
                Validations validations = new Validations();

                Console.WriteLine("Ingresa el numero del método que queres ejecutar:");
                int numberCase = validations.ValidatingCaseNumbers();

                switch (numberCase)
                {
                    case 1:
                        Console.WriteLine(displayLists.CategoriesList());
                        break;
                    case 2:
                        Console.WriteLine(exceptions.AddException());
                        break;
                    case 3:
                        Console.WriteLine(exceptions.UpdateException());
                        break;
                    case 4:
                        Console.WriteLine(exceptions.DeleteException());
                        break;
                    case 5:
                        Console.WriteLine("Realizamos una consulta a la base de datos para obtener una lista de todas las categorías cuyo nombre comienza con la letra C \n");
                       // Console.WriteLine(categoriesLogic.CategoriesQuery());
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
                
                Console.WriteLine("\n¿Querés seguir probando métodos? Ingresa 's' para continuar o cualquier otra tecla para salir.");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() != "s")
                {
                    break;
                }
               

            }

        }
    }
}
