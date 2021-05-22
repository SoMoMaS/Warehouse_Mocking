﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Exceptions
{
    class InsufficientStockException : Exception
    {
        public InsufficientStockException(string message)
        : base(message)
        {
        }
    }
}
