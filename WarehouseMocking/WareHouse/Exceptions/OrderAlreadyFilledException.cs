using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Exceptions
{
    class OrderAlreadyFilledException : Exception 
    {
        public OrderAlreadyFilledException(string message)
        : base(message)
        {
        }
    }
}
