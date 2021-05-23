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
    /// Defines the <see cref="NoSuchProductException" />.
    /// </summary>
    internal class NoSuchProductException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoSuchProductException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public NoSuchProductException(string message)
        : base(message)
        {
        }
    }
}
