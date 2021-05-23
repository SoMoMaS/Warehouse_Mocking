using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse;

namespace WarehouseTests
{
    class OrderTests
    {
        [SetUp]
        public static void Setup()
        {
        }

        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void Simple_Order_Created_Cannot_Be_Fulfilled_Should_Return_False(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 1);

            var order = new Order(product, amount);
            bool canBeFulfilled = order.CanFillOrder(warehouse);
            Assert.IsFalse(canBeFulfilled);
        }

        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void Simple_Order_Created_Can_Be_Fulfilled_Should_Return_True(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 100);

            var order = new Order(product, amount);
            bool canBeFulfilled = order.CanFillOrder(warehouse);
            Assert.IsTrue(canBeFulfilled);
        }

        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void Fill_Order_CanBeFilled_Should_Take_The_Product_Correctly(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 100);

            var order = new Order(product, amount);
            order.CanFillOrder(warehouse);
            order.Fill(warehouse);
            int stock = warehouse.stock[product];
            Assert.AreEqual(100 - amount, stock);


        }

        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void IsFilled_Called_Before_Fill_Should_Return_False(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();

            var order = new Order(product, amount);
            bool isFilled = order.isFilled();
            Assert.IsFalse(isFilled);

        }

        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void IsFilled_Called_After_Fill_Should_Return_True(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 100);
            var order = new Order(product, amount);
            order.CanFillOrder(warehouse);
            order.Fill(warehouse);

            bool isFilled = order.isFilled();
            Assert.IsTrue(isFilled);

        }
    }
}
