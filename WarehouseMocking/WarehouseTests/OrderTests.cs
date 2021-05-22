using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse;

namespace WarehouseTests
{
    [TestClass]
    class OrderTests
    {
        [TestMethod]
        [DataRow("toothpaste", 2)]
        [DataRow("running shoes", 99)]
        [DataRow("shirt", 7)]
        public void Simple_Order_Created_Cannot_Be_Fulfilled_Should_Return_False(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 1);

            var order = new Order(product, amount);
            bool canBeFulfilled = order.CanFillOrder(warehouse);
            Assert.IsFalse(canBeFulfilled);
        }

        [TestMethod]
        [DataRow("toothpaste", 2)]
        [DataRow("running shoes", 99)]
        [DataRow("shirt", 7)]
        public void Simple_Order_Created_Can_Be_Fulfilled_Should_Return_True(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 100);

            var order = new Order(product, amount);
            bool canBeFulfilled = order.CanFillOrder(warehouse);
            Assert.IsFalse(canBeFulfilled);
        }
    }
}
