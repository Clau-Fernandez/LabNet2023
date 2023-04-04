using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabNetPractica3.EF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabNetPractica3.EF.UI.Tests
{
    [TestClass()]
    public class ValidationsTests
    {
        [TestMethod()]
        public void ValidatingCaseNumbersTest__InputIsNumberInRange()
        {
            var input = "3";
            var expected = 3;
            var consoleReader = new StringReader(input);
            Console.SetIn(consoleReader);
            var validations = new Validations();

            
            var result = validations.ValidatingCaseNumbers();

            Assert.AreEqual(expected, result);
        }

        


    }
}