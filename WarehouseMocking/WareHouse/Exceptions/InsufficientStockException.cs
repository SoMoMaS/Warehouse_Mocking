//----------------------------------------------------------------------
// <copyright file=".cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace WareHouse.Exceptions
{
    using System;

    /// <summary>
    /// Defines the <see cref="InsufficientStockException" />.
    /// </summary>
    internal class InsufficientStockException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientStockException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public InsufficientStockException(string message)
        : base(message)
        {
        }
    }
}
