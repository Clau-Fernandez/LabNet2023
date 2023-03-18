using LabNetPractica4.LINQ.Entities;
using LabNetPractica4.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            ListOfQueries listOfQueries = new ListOfQueries();

            while (true)
            {
                listOfQueries.ShowListOfQueries();
                Validation validation = new Validation();
                Console.WriteLine("Ingresa el numero del método que queres ejecutar:");

                int numberCase = validation.ValidatingCaseNumbers();

                switch (numberCase)
                {
                    case 1: 
                        Func<Customers, string> customerInfo = c => $"ClienteID: {c.CustomerID}\nNombre de contacto: {c.ContactName}\nNombre de la compañia: {c.CompanyName}\nTítulo: {c.ContactTitle}\nDirección: {c.Address}\nCiudad: {c.City}\nRegión: {c.Region}\nCódigo postal: {c.PostalCode}\nPaís: {c.Country}\nTeléfono: {c.Phone}\nFax: {c.Fax}";
                        Console.WriteLine(customerInfo(querySintax.GetTheFirstCustomer()));

                        break;
                    case 2:
                        var productsOutOfStock = querySintax.GetOutOfStockProducts();
                        productsOutOfStock.ForEach(product => Console.WriteLine(product.ProductName));
                        break;

                    case 3:
                        Func<List<Products>> productsInStockAndCostMoreThan3 = () => methodSintax.GetProductsInStockAndCostMoreThan3();
                        productsInStockAndCostMoreThan3().ForEach(product => Console.WriteLine($"Nombre del producto: {product.ProductName} | Unidades en stock: {product.UnitsInStock} | Precio unitario :$ {product.UnitPrice}"));
                        break;

                    case 4:
                        Func<List<Customers>> customersFromWA = () => methodSintax.GetCustomersFromWARegion();
                        customersFromWA().ForEach(customer => Console.WriteLine($"{customer.CustomerID} - {customer.ContactName}"));
                        break;
                    case 5:
                        Func<Products> productById = () => methodSintax.GetProductById();
                        Products selectedProduct = productById();
                        Console.WriteLine(selectedProduct == null ? "null" : selectedProduct.ProductName);
                        break;
                    case 6:
                        Func<List<string>> customersNamesInUpperCase = () => methodSintax.GetCustomersNamesInUpperCase();
                        List<string> namesInUpperCase = customersNamesInUpperCase();
                        Console.WriteLine("----Nombre de los clientes en mayúscula----");
                        namesInUpperCase.ForEach(name => Console.WriteLine(name));
                        Console.WriteLine("\n----Nombre de los clientes en minúscula----");
                        namesInUpperCase.ForEach(name => Console.WriteLine(name.ToLower()));
                        break;
                    case 7:
                        var customersOrders = querySintax.GetCustomersOrders();
                        foreach (var co in customersOrders)
                        {
                            Console.WriteLine($"Nombre del cliente: {co.CustomerName} - Order ID: {co.Order}");
                        }
                        break;
                    case 8:
                        Func<List<Customers>> firstThreeCustomersFromWA = () => methodSintax.GetFirstThreeCustomersFromWA();
                        firstThreeCustomersFromWA().ForEach(c => Console.WriteLine($"ID: {c.CustomerID} - Nombre: {c.ContactName}"));
                        break;
                    case 9:
                        Func<List<Products>> productsOrderedByName = () => querySintax.GetProductsOrderedByName();
                        productsOrderedByName().ForEach(p => Console.WriteLine(p.ProductName));
                        break;
                    case 10:
                        Func<List<Products>> productsOrderedByUnitsInStockDescending = () => methodSintax.GetProductsOrderedByUnitsInStockDescending();
                        productsOrderedByUnitsInStockDescending().ForEach(p => Console.WriteLine($"Nombre del producto: {p.ProductName}, Unidades en stock: {p.UnitsInStock}"));
                        break;
                    case 11:
                        querySintax.GetDistinctCategories().ForEach(category => Console.WriteLine(category));
                        break;
                    case 12:
                        var firstProduct = methodSintax.GetFirstProduct();
                        Console.WriteLine($"Producto ID: {firstProduct.ProductID}, Nombre Producto: {firstProduct.ProductName}, Precio unitario:$ {firstProduct.UnitPrice}");
                        break;
                    case 13:
                        querySintax.GetCustomerOrdersCount().ForEach(item => Console.WriteLine($"Cliente: {item.CustomerName} - Cantidad de órdenes: {item.Order}"));
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
                
                Console.WriteLine("\n¿Querés seguir probando métodos? Ingresa cualquier letra para continuar o 'X' para salir");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() == "x")
                {
                    break;
                }

               Console.Clear();

                 
            }
               Console.ReadLine();
            
        }
    }
}
