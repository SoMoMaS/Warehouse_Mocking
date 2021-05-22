using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse
{
    class Order
    {
        private string product;
        private int amount;
        public Order(string product, int amount)
        {
            if (string.IsNullOrEmpty(product))
                throw new InvalidOperationException("Product name can't be empty");

            if (amount < 1)
                throw new InvalidOperationException("Amount can't be smaller than 1.");

            this.product = product;
            this.amount = amount;
        }

        internal bool isFilled()
        {
            throw new NotImplementedException();
        }

        internal bool CanFillOrder(IWarehouse warehouse)
        {
            throw new NotImplementedException();
        }

        internal void Fill(IWarehouse warehouse)
        {
            throw new NotImplementedException();
        }
    }
}
