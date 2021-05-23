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
    /// Defines the <see cref="OrderAlreadyFilledException" />.
    /// </summary>
    internal class OrderAlreadyFilledException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAlreadyFilledException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public OrderAlreadyFilledException(string message)
        : base(message)
        {
        }
    }
}
