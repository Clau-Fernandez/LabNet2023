using Microsoft.VisualStudio.TestTools.UnitTesting;
using labNetPractica2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2.Tests
{
    [TestClass()]
    public class MisMetodosTests
    {
        [TestMethod()]
        public void DividirPorCeroTest()
        {
            int numero = 5;

            Assert.ThrowsException<DivideByZeroException>(() => { MisMetodos.DividirPorCero(numero); });
        }

        [TestMethod()]
        public void DivisionTest()
        {
            //Arrange
            double dividendo = 12;
            double divisor = 2;
            double valorEsperado = 6;

            //Act

            double valorObtenido = MisMetodos.Division(dividendo, divisor);

            //Assert
            Assert.AreEqual(valorEsperado, valorObtenido);

        }

     
    }
}