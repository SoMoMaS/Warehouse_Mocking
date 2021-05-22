using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse;
using Assert = NUnit.Framework.Assert;

namespace WarehouseTests
{
    [TestClass]
    public class SimpleWarehouseTests
    {
        [TestMethod]
        [DataRow("toothpaste", 2)]
        [DataRow("running shoes", 99)]
        [DataRow("shirt", 7)]
        public void Simplewarehouse_Creates_A_New_Product_By_Calling_AddStock(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, amount);
            Assert.AreEqual(amount, warehouse.stock[product]);
        }


        [TestMethod]
        [DataRow("running shoes", -5)]
        [DataRow("shirt", -147)]
        public void Trying_To_Add_Negative_Amount_Should_Throw_Exception(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.AddStock(product, amount);
            Assert.Throws<InvalidOperationException>(test, "The amount can't be less than 1");
        }

        [TestMethod]
        [DataRow("", 5)]
        public void Trying_To_Add_Empty_String_Should_Throw_Exception(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.AddStock(product, amount);
            Assert.Throws<InvalidOperationException>(test, "Product name can't be empty");
        }


        [TestMethod]
        [DataRow("toothpaste", 2)]
        [DataRow("running shoes", 99)]
        [DataRow("shirt", 7)]
        public void CurrentStock_New_Product_Given_Should_Return_Amount(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, amount);
            int stock = warehouse.CurrentStock(product);
            Assert.AreEqual(amount, stock);
        }

        [TestMethod]
        [DataRow("toothpaste", 2)]
        public void CurrentStock_Existing_Product_Given_Should_Return_New_Amount(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 99);
            warehouse.AddStock(product, amount);
            int stock = warehouse.CurrentStock(product);
            Assert.AreEqual(amount + 99, stock);
        }
    }
}

