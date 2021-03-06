using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.View;

namespace CRUDTests.ViewTests
{
    [TestClass]
    public class CRUDViewTests
    {
        /// <summary>
        /// Метод который тестирует метод используя входные данные из трех значений
        /// </summary>
        [TestMethod]
        public void ParseToDataTest_TripleData()
        {
            // Arrange 
            var crudView = new CRUDView();

            // Act
            string[] res = crudView.ParseToData("Sasha Kosilov 18");

            string[] rightRes = new string[] { null, "Sasha", "Kosilov", "18" };

            //Assert
            for(int i = 0; i < 4; i++)
            {
                Assert.AreEqual(res[i], rightRes[i]);
            }
            
        }

        /// <summary>
        /// Метод который тестирует метод используя входные данные из одного значений
        /// </summary>
        [TestMethod]
        public void ParseToDataTest_SingleData()
        {
            // Arrange 
            var crudView = new CRUDView();

            // Act
            string[] res = crudView.ParseToData("5");

            string[] rightRes = new string[] { "5" };

            //Assert
            for (int i = 0; i < rightRes.Length; i++)
            {
                Assert.AreEqual(res[i], rightRes[i]);
            }

        }


        /// <summary>
        /// Метод который тестирует метод используя входные данные из четырех значений
        /// </summary>
        [TestMethod]
        public void ParseToDataTest_QuadData()
        {
            // Arrange 
            var crudView = new CRUDView();

            // Act
            string[] res = crudView.ParseToData("4 Sasha Kosilov 18");

            string[] rightRes = new string[] { "4", "Sasha", "Kosilov", "18" };

            //Assert
            for (int i = 0; i < rightRes.Length; i++)
            {
                Assert.AreEqual(res[0], rightRes[0]);
            }
        }

    }
}
