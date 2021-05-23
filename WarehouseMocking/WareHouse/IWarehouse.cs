//----------------------------------------------------------------------
// <copyright file=".cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace WareHouse
{
    /// <summary>
    /// Defines the <see cref="IWarehouse" />.
    /// </summary>
    public interface IWarehouse
    {
        /// <summary>
        /// The HasProduct.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool HasProduct(string product);

        /// <summary>
        /// The CurrentStock.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        int CurrentStock(string product);

        /// <summary>
        /// The AddStock.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        void AddStock(string product, int amount);

        /// <summary>
        /// The TakeStock.
        /// </summary>
        /// <param name="product">The product<see cref="string"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        void TakeStock(string product, int amount);
    }
}
