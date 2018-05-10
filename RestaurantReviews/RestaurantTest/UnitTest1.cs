using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestaurantBL;
using RestaurantDL;

namespace RestaurantTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RestaurantDL.Restaurant rest = new RestaurantDL.Restaurant();
            string actual = rest.name = "Five Guys";
            string expected = rest.name;
            Assert.AreEqual(actual, expected);
        }
    }
}