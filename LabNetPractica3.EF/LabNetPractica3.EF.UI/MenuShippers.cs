using LabNetPractica3.EF.Exceptions;
using LabNetPractica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.EF.UI
{
    public class MenuShippers : MenuBase
    {
        public override void ChooseMethodToExecute()
        {
            DisplayLists displayLists = new DisplayLists();
            ShippersLogic shippersLogic = new ShippersLogic();
            ShippersABMExceptions exceptions = new ShippersABMExceptions();

            while (true)
            {
                Validations validations = new Validations();

                Console.WriteLine("Ingresa el numero del método que queres ejecutar:");
                int numberCase = validations.ValidatingCaseNumbers();

                switch (numberCase)
                {
                    case 1:
                        Console.WriteLine(displayLists.ShippersList());
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
                        Console.WriteLine("Realizamos una consulta a la base de datos para obtener la compañía que contiene la palabra 'United' en su nombre\n");
                        Console.WriteLine(shippersLogic.ShippersQuery());
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
