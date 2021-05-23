//----------------------------------------------------------------------
// <copyright file=".cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace WarehouseTests
{
    using Moq;
    using NUnit.Framework;
    using WareHouse;
    using WareHouse.Exceptions;

    /// <summary>
    /// Defines the <see cref="OrderTests" />.
    /// </summary>
    internal class OrderTests
    {
        /// <summary>
        /// The Setup.
        /// </summary>
        [SetUp]
        public static void Setup()
        {
        }

        /// <summary>
        /// The Simple_Order_Created_Cannot_Be_Fulfilled_Should_Return_False.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
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

        /// <summary>
        /// The Simple_Order_Created_Can_Be_Fulfilled_Should_Return_True.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
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

        /// <summary>
        /// The Fill_Order_CanBeFilled_Should_Take_The_Product_Correctly.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
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

        /// <summary>
        /// The Fill_Order_CanBeFilled_Should_Take_The_Product_Correctly.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void Fill_Order_Already_Called_Should_Throw_Exception(string product, int amount)
        {
            var warehouse = new SimpleWarehouse();
            warehouse.AddStock(product, 200);

            var order = new Order(product, amount);
            order.CanFillOrder(warehouse);
            order.Fill(warehouse);

            TestDelegate test = () => order.Fill(warehouse);
            Assert.Throws<OrderAlreadyFilledException>(test, "Order already filled.");

            
        }

        /// <summary>
        /// The IsFilled_Called_Before_Fill_Should_Return_False.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
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

        /// <summary>
        /// The IsFilled_Called_After_Fill_Should_Return_True.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
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

        /// <summary>
        /// The Order_Class_Calls_IWareHouse_HasProduct_And_CurrentStock_One_Time.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void Order_Class_Calls_IWareHouse_HasProduct_And_CurrentStock_One_Time(string product, int amount)
        {
            var order = new Order(product, amount);

            var mock = new Mock<IWarehouse>();

            mock.Setup(cal => cal.HasProduct(product)).Returns(true);
            mock.Setup(cal => cal.CurrentStock(product)).Returns(200);

            IWarehouse warehouse = mock.Object;

            bool canFilled = order.CanFillOrder(warehouse);

            Assert.IsTrue(canFilled);

            mock.Verify(cal => cal.HasProduct(product), Times.Once);
            mock.Verify(cal => cal.CurrentStock(product), Times.Once);
        }

        /// <summary>
        /// The Order_Class_Calls_IWareHouse_TakeStock_One_Time.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        [TestCase("toothpaste", 2)]
        [TestCase("running shoes", 99)]
        [TestCase("shirt", 7)]
        public void Order_Class_Calls_IWareHouse_TakeStock_One_Time(string product, int amount)
        {
            var order = new Order(product, amount);

            var mock = new Mock<IWarehouse>();

            mock.Setup(cal => cal.TakeStock(product, amount));

            IWarehouse warehouse = mock.Object;
            order.CanFillOrder(warehouse);
            order.Fill(warehouse);

            mock.Verify(cal => cal.TakeStock(product, amount), Times.Once);
            mock.Verify(cal => cal.HasProduct(product), Times.Once);
        }
    }
}
