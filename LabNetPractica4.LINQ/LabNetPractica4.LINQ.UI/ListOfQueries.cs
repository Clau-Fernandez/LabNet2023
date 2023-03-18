using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica4.LINQ.UI
{
    public class ListOfQueries
    {
        public void ShowListOfQueries() 
        {
            Console.WriteLine("----Menú de Queries----");
            Console.WriteLine("1. Query para devolver objeto customer ");
            Console.WriteLine("2. Query para devolver todos los productos sin stock ");
            Console.WriteLine("3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad ");
            Console.WriteLine("4. Query para devolver todos los customers de la Región WA ");
            Console.WriteLine("5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789 ");
            Console.WriteLine("6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula. ");
            Console.WriteLine("7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997. ");
            Console.WriteLine("8. Query para devolver los primeros 3 Customers de la Región WA ");
            Console.WriteLine("9. Query para devolver lista de productos ordenados por nombre ");
            Console.WriteLine("10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.");
            Console.WriteLine("11. Query para devolver las distintas categorías asociadas a los productos ");
            Console.WriteLine("12. Query para devolver el primer elemento de una lista de productos");
            Console.WriteLine("13. Query para devolver los customer con la cantidad de ordenes asociadas");
        }
    }
}
