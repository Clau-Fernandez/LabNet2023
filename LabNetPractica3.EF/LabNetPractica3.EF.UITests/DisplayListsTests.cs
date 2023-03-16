using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabNetPractica3.EF.Entities;
using LabNetPractica3.EF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabNetPractica3.EF.Logic;
using Moq;

namespace LabNetPractica3.EF.UI.Tests
{
    [TestClass()]
    public class DisplayListsTests
    {
        [TestMethod()]
        public void CategoriesListTest()
        {
            // Arrange
            var categoriesLogicMock = new Mock<CategoriesLogic>();
            categoriesLogicMock.Setup(mock => mock.GetAll())
                .Returns(new List<Category> {
                new Category { CategoryID = 1, CategoryName = "Category 1", Description = "Description 1" },
                new Category { CategoryID = 2, CategoryName = "Category 2", Description = "Description 2" }
                });
            var controller = new CategoriesController(categoriesLogicMock.Object);

            // Act
            var result = controller.CategoriesList();

            // Assert
            Assert.AreEqual("1 - Category 1 - Description 1\n2 - Category 2 - Description 2\n", result);

        }
    }
}