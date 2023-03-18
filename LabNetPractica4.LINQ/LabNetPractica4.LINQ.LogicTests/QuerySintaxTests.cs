using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabNetPractica4.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica4.LINQ.Logic.Tests
{
    [TestClass]
    public class MyTests
    {
        private DbContextOptions<MyDbContext> options;

        [TestInitialize]
        public void Initialize()
        {
            options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "MyDatabase")
                .Options;

            using (var context = new MyDbContext(options))
            {
                context.Customers.Add(new Customer { CustomerID = "ALFKI", ContactName = "Maria Anders", Country = "Germany" });
                context.Customers.Add(new Customer { CustomerID = "ANATR", ContactName = "Ana Trujillo", Country = "Mexico" });
                context.Customers.Add(new Customer { CustomerID = "ANTON", ContactName = "Antonio Moreno", Country = "Mexico" });
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void Test_GetTheFirstCustomer_ReturnsCorrectCustomer()
        {
            using (var context = new MyDbContext(options))
            {
                // Arrange
                var sut = new MyService(context);

                // Act
                var result = sut.GetTheFirstCustomer();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("ALFKI", result.CustomerID);
                Assert.AreEqual("Maria Anders", result.ContactName);
                Assert.AreEqual("Germany", result.Country);
            }
        }
    }
}