using LabNetPractica4.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica4.LINQ.Logic
{
    public class MethodSintax: BaseLogic
    {
        public List<Products> GetProductsInStockAndCostMoreThan3()
        {
            return context.Products .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3)
                                    .ToList();
           
        }

        public List<Customers> GetCustomersFromWARegion()
        {
            return context.Customers
                           .Where(c => c.Region == "WA")
                           .ToList();
        }

        public Products GetProductById()
        {
            return context.Products.SingleOrDefault(p => p.ProductID == 789);

        }

        public List<string> GetCustomersNamesInUpperCase()
        {
            var customerNames = context.Customers
                .Select(c => c.CompanyName.ToUpper());

            return customerNames.ToList();
        }

        public List<Customers> GetFirstThreeCustomersFromWA()
        {
            var customers = context.Customers
                .Where(c => c.Region == "WA")
                .Take(3)
                .ToList();
            return customers;
        }

        public List<Products> GetProductsOrderedByUnitsInStockDescending()
        {
            var products = context.Products.OrderByDescending(p => p.UnitsInStock).ToList();
            return products;
        }

        public Products GetFirstProduct()
        {
            var firstProduct = context.Products.FirstOrDefault();
            return firstProduct;
        }

       
    }
}
