using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse;

namespace WarehouseTests
{
    [TestClass]
    public class SimpleWarehouseTests
    {
        [TestMethod]
        [DataRow("toothpaste", 2)]
        public void Simplewarehouse_Creates_A_New_Product_By_Calling_AddStock(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, amount);
            Assert.AreEqual(amount, warehouse.stock[product]);
        }
    }
}

