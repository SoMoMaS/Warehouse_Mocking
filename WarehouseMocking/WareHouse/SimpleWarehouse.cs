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
        internal Dictionary<string, int> stock;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleWarehouse"/> class.
        /// </summary>
        public SimpleWarehouse() => this.stock = new Dictionary<string, int>();

        /// <summary>
        /// The AddStock.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        /// <exception cref="System.InvalidOperationException">Throws Invalid operation exception if the product
        /// name is empty or null.</exception>
        /// <exception cref="System.InvalidOperationException">Throws Invalid operation exception if the amount 
        /// of the product is less than 1.</exception>
        public void AddStock(string product, int amount)
        {
            if (string.IsNullOrEmpty(product))
                throw new InvalidOperationException("Product name can't be empty");

            if (amount < 1)
                throw new InvalidOperationException("The amount can't be less than 1");

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
        /// <exception cref="System.InvalidOperationException">Throws Invalid operation exception if the product
        /// name is empty or null.</exception>
        /// <exception cref="NoSuchProductException">Throws if the product doesn't exist in the stock.</exception>
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
        /// <exception cref="System.InvalidOperationException">Throws Invalid operation exception if the product
        /// name is empty or null.</exception>
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
        /// <exception cref="System.InvalidOperationException">Throws Invalid operation exception if the product
        /// name is empty or null.</exception>
        /// <exception cref="System.InvalidOperationException">Throws Invalid operation exception if the amount 
        /// of the product is less than 1.</exception>
        /// <exception cref="InsufficientStockException">Throws exception if the amount is bigger than the stock of the 
        /// given product. </exception>
        /// <exception cref="NoSuchProductException">Throws if the product doesn't exist in the stock.</exception>
        public void TakeStock(string product, int amount)
        {
            if (string.IsNullOrEmpty(product))
                throw new InvalidOperationException("Product name can't be empty");

            if (amount < 1)
                throw new InvalidOperationException("The amount can't be less than 1");

            if (this.HasProduct(product))
            {
                this.stock.TryGetValue(product, out int value);

                if (value < amount)
                    throw new InsufficientStockException($"The amount exceedes the stock of this product: {product}");
                else
                    this.stock[product] = value - amount;

            }
            else
                throw new NoSuchProductException($"There is no such product as: {product} in the stock ");
        }
    }
}
