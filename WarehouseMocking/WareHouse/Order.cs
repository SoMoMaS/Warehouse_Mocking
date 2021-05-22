using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("WarehouseTests")]
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
                throw new InvalidOperationException("The amount of the product can't be smaller than 1.");

            this.product = product;
            this.amount = amount;
        }

        internal bool isFilled()
        {
            throw new NotImplementedException();
        }

        internal bool CanFillOrder(IWarehouse warehouse)
        {
            bool hasProduct = warehouse.HasProduct(product);
            int stock = warehouse.CurrentStock(product);

            return hasProduct && stock > this.amount;
        }

        internal void Fill(IWarehouse warehouse)
        {
            try
            {
                warehouse.TakeStock(this.product, this.amount);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
