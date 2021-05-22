using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse;
using WareHouse.Exceptions;
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

        [TestMethod]
        [DataRow("")]
        public void Empty_Name_Given_Should_Throw_Exception(string product)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.CurrentStock(product);
            Assert.Throws<InvalidOperationException>(test, "Product name can't be empty");
        }

        [TestMethod]
        [DataRow("toothpaste")]
        [DataRow("shoes")]
        public void Hasproduct_Given_Product_Doesnt_Exist_Should_Return_False(string product)
        {
            var warehouse = new SimpleWarehouse();
            bool exist = warehouse.HasProduct(product);
            Assert.False(exist);
        }

        [TestMethod]
        [DataRow("toothpaste")]
        [DataRow("shoes")]
        public void Hasproduct_Given_Product_Exists_Should_Return_True(string product)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 5);
            bool exist = warehouse.HasProduct(product);
            Assert.True(exist);
        }

        [TestMethod]
        [DataRow("")]
        public void Hasproduct_Empty_Name_Given_Should_Throw_Exception(string product)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.HasProduct(product);
            Assert.Throws<InvalidOperationException>(test, "Product name can't be empty");
        }

        [TestMethod]
        [DataRow("")]
        public void TakeStock_Empty_Name_Given_Should_Throw_Exception(string product)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.TakeStock(product, 5);
            Assert.Throws<InvalidOperationException>(test, "Product name can't be empty");
        }

        [TestMethod]
        [DataRow("toothpaste", -20)]
        [DataRow("shoes", 0)]
        public void TakeStock_Amount_Less_Than_One_Should_Throw_Exception(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            TestDelegate test = () => warehouse.TakeStock(product, amount);
            Assert.Throws<InvalidOperationException>(test, "The amount can't be less than 1");
        }


        [TestMethod]
        [DataRow("toothpaste", 20)]
        [DataRow("shoes", 20)]
        public void TakeStock_Amount_Is_Bigger_Than_Stock_Should_Throw_Exception(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 10);
            TestDelegate test = () => warehouse.TakeStock(product, amount);
            Assert.Throws<InsufficientStockException>(test, $"The amount exceedes the stock of this product: {product}");
        }

        [TestMethod]
        [DataRow("knife")]
        [DataRow("ball")]
        public void TakeStock_Given_Product_Doesnt_Exist_Should_Throw_Exception(string product)
        {
            var warehouse = new SimpleWarehouse();
            TestDelegate test = () => warehouse.TakeStock(product, 5);
            Assert.Throws<NoSuchProductException>(test, $"There is no such product as: {product} in the stock ");
        }

        [TestMethod]
        [DataRow("toothpaste", 10)]
        [DataRow("shoes", 10)]
        public void TakeStock_Given_Product_Exists_Should_Take_The_Amount_Correctly(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 20);
            warehouse.TakeStock(product, amount);
            int newStock = warehouse.stock[product];
            Assert.AreEqual(10, newStock);
        }
    }
}

