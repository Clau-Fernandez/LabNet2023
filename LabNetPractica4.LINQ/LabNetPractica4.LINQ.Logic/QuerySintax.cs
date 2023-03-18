using LabNetPractica4.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica4.LINQ.Logic
{
    public class QuerySintax : BaseLogic
    {

        public Customers GetTheFirstCustomer()
        {
            var customer = (from c in context.Customers
                            select c).FirstOrDefault();
            return customer;

        }

        public List<Products> GetOutOfStockProducts()
        {
            var outOfStockProducts = from p in context.Products
                                     where p.UnitsInStock == 0
                                     select p;

            return outOfStockProducts.ToList();
        }

        public List<CustomerOrder> GetCustomersOrders()
        {
            var customersOrders = from c in context.Customers
                                  join o in context.Orders on c.CustomerID equals o.CustomerID
                                  where c.Region == "WA" && o.OrderDate > new DateTime(1997, 1, 1)
                                  select new CustomerOrder { CustomerName = c.ContactName, Order = o.OrderID };

            return customersOrders.ToList();
        }

        public List<Products> GetProductsOrderedByName()
        {
            var productsOrdered = from p in context.Products
                                  orderby p.ProductName
                                  select p;
            return productsOrdered.ToList();
        }

        public List<string> GetDistinctCategories()
        {
            var categories = (from p in context.Products
                              join c in context.Categories on p.CategoryID equals c.CategoryID
                              select c.CategoryName).Distinct().ToList();
            return categories;
        }
        public List<CustomerOrder> GetCustomerOrdersCount()
        {
            var customerOrders = from c in context.Customers
                                 join o in context.Orders on c.CustomerID equals o.CustomerID into g
                                 select new CustomerOrder
                                 {
                                     CustomerName = c.ContactName,
                                     Order = g.Count()
                                 };
            return customerOrders.ToList();
        }

    }
}
