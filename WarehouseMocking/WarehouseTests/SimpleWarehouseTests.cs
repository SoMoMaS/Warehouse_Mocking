//----------------------------------------------------------------------
// <copyright file=".cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace WarehouseTests
{
    using NUnit.Framework;
    using System;
    using WareHouse;
    using WareHouse.Exceptions;

    /// <summary>
    /// Defines the <see cref="SimpleWarehouseTests" />.
    /// </summary>
    public class SimpleWarehouseTests
    {
        /// <summary>
        /// The Setup.
        /// </summary>
        [SetUp]
        public static void Setup()
        {
        }

        /// <summary>
        /// The Simplewarehouse_Creates_A_New_Product_By_Calling_AddStock.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void Simplewarehouse_Creates_A_New_Product_By_Calling_AddStock(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, amount);
            Assert.AreEqual(amount, warehouse.stock[product]);
        }

        /// <summary>
        /// The Trying_To_Add_Negative_Amount_Should_Throw_Exception.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("running shoes", -5)]
        [TestCase("shirt", -147)]
        public void Trying_To_Add_Negative_Amount_Should_Throw_Exception(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.AddStock(product, amount);
            Assert.Throws<InvalidOperationException>(test, "The amount can't be less than 1");
        }

        /// <summary>
        /// The Trying_To_Add_Empty_String_Should_Throw_Exception.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("", 5)]
        public void Trying_To_Add_Empty_String_Should_Throw_Exception(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.AddStock(product, amount);
            Assert.Throws<InvalidOperationException>(test, "Product name can't be empty");
        }

        /// <summary>
        /// The CurrentStock_New_Product_Given_Should_Return_Amount.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void CurrentStock_New_Product_Given_Should_Return_Amount(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, amount);
            int stock = warehouse.CurrentStock(product);
            Assert.AreEqual(amount, stock);
        }

        /// <summary>
        /// The CurrentStock_Existing_Product_Given_Should_Return_New_Amount.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("toothpaste", 2)]
        public void CurrentStock_Existing_Product_Given_Should_Return_New_Amount(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 99);
            warehouse.AddStock(product, amount);
            int stock = warehouse.CurrentStock(product);
            Assert.AreEqual(amount + 99, stock);
        }

        /// <summary>
        /// The Empty_Name_Given_Should_Throw_Exception.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        [TestCase("")]
        public void Empty_Name_Given_Should_Throw_Exception(string product)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.CurrentStock(product);
            Assert.Throws<InvalidOperationException>(test, "Product name can't be empty");
        }

        /// <summary>
        /// The Hasproduct_Given_Product_Doesnt_Exist_Should_Return_False.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        [TestCase("toothpaste")]
        [TestCase("shoes")]
        public void Hasproduct_Given_Product_Doesnt_Exist_Should_Return_False(string product)
        {
            var warehouse = new SimpleWarehouse();
            bool exist = warehouse.HasProduct(product);
            Assert.False(exist);
        }

        /// <summary>
        /// The Hasproduct_Given_Product_Exists_Should_Return_True.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        [TestCase("toothpaste")]
        [TestCase("shoes")]
        public void Hasproduct_Given_Product_Exists_Should_Return_True(string product)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 5);
            bool exist = warehouse.HasProduct(product);
            Assert.True(exist);
        }

        /// <summary>
        /// The Hasproduct_Empty_Name_Given_Should_Throw_Exception.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        [TestCase("")]
        public void Hasproduct_Empty_Name_Given_Should_Throw_Exception(string product)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.HasProduct(product);
            Assert.Throws<InvalidOperationException>(test, "Product name can't be empty");
        }

        /// <summary>
        /// The TakeStock_Empty_Name_Given_Should_Throw_Exception.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        [TestCase("")]
        public void TakeStock_Empty_Name_Given_Should_Throw_Exception(string product)
        {
            var warehouse = new SimpleWarehouse();

            TestDelegate test = () => warehouse.TakeStock(product, 5);
            Assert.Throws<InvalidOperationException>(test, "Product name can't be empty");
        }

        /// <summary>
        /// The TakeStock_Amount_Less_Than_One_Should_Throw_Exception.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("toothpaste", -20)]
        [TestCase("shoes", 0)]
        public void TakeStock_Amount_Less_Than_One_Should_Throw_Exception(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            TestDelegate test = () => warehouse.TakeStock(product, amount);
            Assert.Throws<InvalidOperationException>(test, "The amount can't be less than 1");
        }

        /// <summary>
        /// The TakeStock_Amount_Is_Bigger_Than_Stock_Should_Throw_Exception.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("toothpaste", 20)]
        [TestCase("shoes", 20)]
        public void TakeStock_Amount_Is_Bigger_Than_Stock_Should_Throw_Exception(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 10);
            TestDelegate test = () => warehouse.TakeStock(product, amount);
            Assert.Throws<InsufficientStockException>(test, $"The amount exceedes the stock of this product: {product}");
        }

        /// <summary>
        /// The TakeStock_Given_Product_Doesnt_Exist_Should_Throw_Exception.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        [TestCase("knife")]
        [TestCase("ball")]
        public void TakeStock_Given_Product_Doesnt_Exist_Should_Throw_Exception(string product)
        {
            var warehouse = new SimpleWarehouse();
            TestDelegate test = () => warehouse.TakeStock(product, 5);
            Assert.Throws<NoSuchProductException>(test, $"There is no such product as: {product} in the stock ");
        }

        /// <summary>
        /// The TakeStock_Given_Product_Exists_Should_Take_The_Amount_Correctly.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("toothpaste", 10)]
        [TestCase("shoes", 10)]
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
