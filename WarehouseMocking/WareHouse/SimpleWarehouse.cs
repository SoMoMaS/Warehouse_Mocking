//----------------------------------------------------------------------
// <copyright file=".cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace WareHouse
{
    using System;
    using System.Collections.Generic;
    using WareHouse.Exceptions;

    /// <summary>
    /// Defines the <see cref="SimpleWarehouse" />.
    /// </summary>
    internal class SimpleWarehouse : IWarehouse
    {
        /// <summary>
        /// Defines the stock.
        /// </summary>
        private Dictionary<string, int> stock;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleWarehouse"/> class.
        /// </summary>
        public SimpleWarehouse() => this.stock = new Dictionary<string, int>();

        /// <summary>
        /// The AddStock.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        public void AddStock(string product, int amount)
        {
            if (string.IsNullOrEmpty(product))
                throw new InvalidOperationException("Product name can't be empty");


            bool exist = this.stock.TryGetValue(product, out int value);

            if (exist)
                this.stock[product] = value + amount;
            else
                this.stock.Add(product, amount);
        }

        /// <summary>
        /// The CurrentStock.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int CurrentStock(string product)
        {
            if (string.IsNullOrEmpty(product))
                throw new InvalidOperationException("Product name can't be empty");

            if (this.HasProduct(product))
                return this.stock[product];
            else
                throw new NoSuchProductException($"There is no such product as: {product} in the stock ");
        }

        /// <summary>
        /// The HasProduct.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool HasProduct(string product)
        {
            if (string.IsNullOrEmpty(product))
                throw new InvalidOperationException("Product name can't be empty");

            return this.stock.ContainsKey(product);
        }

        /// <summary>
        /// The TakeStock.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        public void TakeStock(string product, int amount)
        {
            if (string.IsNullOrEmpty(product))
                throw new InvalidOperationException("Product name can't be empty");

            if (this.HasProduct(product))
            {
                this.stock.TryGetValue(product, out int value);

                if (value < amount)
                    throw new InsufficientStockException($"The amount exceedes the stock of this product: {product}, amount wanted: {amount}, stock: {value}");
                else
                    this.stock[product] = value - amount;

            }
            else
                throw new NoSuchProductException($"There is no such product as: {product} in the stock ");
        }
    }
}
