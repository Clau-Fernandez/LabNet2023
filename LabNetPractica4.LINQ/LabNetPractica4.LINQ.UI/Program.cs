using LabNetPractica4.LINQ.Entities;
using LabNetPractica4.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica4.LINQ.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuerySintax querySintax = new QuerySintax();
            MethodSintax methodSintax = new MethodSintax();

            //------------Query1------------
            //var customer = querySintax.GetTheFirstCustomer();
            //Console.WriteLine($"CustomerID: {customer.CustomerID}");
            //Console.WriteLine($"ContactName: {customer.ContactName}");
            //Console.WriteLine($"CompanyName: {customer.CompanyName}");
            //Console.WriteLine($"ContactName: {customer.ContactTitle}");
            //Console.WriteLine($"CompanyName: {customer.Address}");
            //Console.WriteLine($"CompanyName: {customer.City}");
            //Console.WriteLine($"CompanyName: {customer.Region}");
            //Console.WriteLine($"CompanyName: {customer.PostalCode}");
            //Console.WriteLine($"CompanyName: {customer.Country}");
            //Console.WriteLine($"CompanyName: {customer.Phone}");
            //Console.WriteLine($"CompanyName: {customer.Fax}");

            //------------Query2------------

            //var productsOutOfStock = querySintax.GetOutOfStockProducts();

            //foreach (var product in productsOutOfStock)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //------------Query3------------

            //var productsInStockAndCostMoreThan3 = methodSintax.GetProductsInStockAndCostMoreThan3();

            //foreach (var product in productsInStockAndCostMoreThan3)
            //{
            //    Console.WriteLine($"Product Name: {product.ProductName} | Units in Stock: {product.UnitsInStock} | Unit Price: {product.UnitPrice}" );
            //}

            //------------Query4------------

            //var customersFromWA = methodSintax.GetCustomersFromWARegion();

            //foreach (var customer in customersFromWA)
            //{
            //    Console.WriteLine(customer.CustomerID + " - " + customer.ContactName);
            //}

            //------------Query5------------

            //var productById = methodSintax.GetProductById();

            //if (productById == null)
            //{
            //    Console.WriteLine("null");
            //}
            //else
            //{
            //    Console.WriteLine(productById.ProductName);
            //}

            //------------Query6------------

            //var customersInUpperCase = methodSintax.GetCustomersNamesInUpperCase();
            //Console.WriteLine("Nombre de los clientes en mayúscula:\n");
            //foreach (var name in customersInUpperCase)
            //{
            //    Console.WriteLine(name);
            //}

            //Console.WriteLine("\nNombre de los clientes en minúscula\n");

            //foreach (var name in customersInUpperCase)
            //{
            //    Console.WriteLine(name.ToLower());
            //}

            //------------Query7------------
                     
            //var customersOrders = querySintax.GetCustomersOrders();

            //foreach (var co in customersOrders)
            //{
            //    Console.WriteLine($"Customer Name: {co.CustomerName} - Order ID: {co.OrderID}");
            //}

            //------------Query8------------








            Console.ReadLine(); 
        }
    }
}
