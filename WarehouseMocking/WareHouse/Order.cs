//----------------------------------------------------------------------
// <copyright file=".cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("WarehouseTests")]
namespace WareHouse
{
    using System;

    /// <summary>
    /// Defines the <see cref="Order" />.
    /// </summary>
    internal class Order
    {
        /// <summary>
        /// Defines the product.
        /// </summary>
        private string product;

        /// <summary>
        /// Defines the amount.
        /// </summary>
        private int amount;

        /// <summary>
        /// Defines the isFilledCalled.
        /// </summary>
        private bool isFilledCalled;

        /// <summary>
        /// Defines the isCanFillOrderCalled.
        /// </summary>
        private bool isCanFillOrderCalled;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        public Order(string product, int amount)
        {
            if (string.IsNullOrEmpty(product))
                throw new InvalidOperationException("Product name can't be empty");

            if (amount < 1)
                throw new InvalidOperationException("The amount of the product can't be smaller than 1.");

            this.product = product;
            this.amount = amount;
            this.isFilledCalled = false;
            this.isCanFillOrderCalled = false;
        }

        /// <summary>
        /// The isFilled.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        internal bool isFilled()
        {
            return this.isFilledCalled;
        }

        /// <summary>
        /// The CanFillOrder.
        /// </summary>
        /// <param name="warehouse">The warehouse<see cref="IWarehouse"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        internal bool CanFillOrder(IWarehouse warehouse)
        {
            bool hasProduct = warehouse.HasProduct(product);
            int stock = warehouse.CurrentStock(product);
            this.isCanFillOrderCalled = true;
            return hasProduct && stock > this.amount;
        }

        /// <summary>
        /// The Fill.
        /// </summary>
        /// <param name="warehouse">The warehouse<see cref="IWarehouse"/>.</param>
        internal void Fill(IWarehouse warehouse)
        {
            if (this.isCanFillOrderCalled)
            {
                try
                {
                    warehouse.TakeStock(this.product, this.amount);
                }
                catch (Exception)
                {
                    throw;
                }

                this.isFilledCalled = true;
            }
        }
    }
}
