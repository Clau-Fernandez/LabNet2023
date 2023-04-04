using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Productos");

            ProductLogic productLogic = new ProductLogic();

            foreach (var prod in productLogic.GetAll())
            {
                Console.WriteLine($" {prod.ProductName} - {prod.UnitPrice}");
            }

            Console.ReadLine();


        }
    }
}
