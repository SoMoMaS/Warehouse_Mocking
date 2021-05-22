using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Exceptions
{
    class NoSuchProductException : Exception
    {
        public NoSuchProductException(string message)
        : base(message)
        {
        }
    }
}
