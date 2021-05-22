using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse
{
    class SimpleWarehouse : IWarehouse
    {
        private Dictionary<string, int> stock;

        public SimpleWarehouse() => this.stock = new Dictionary<string, int>();

        public void AddStock(string product, int amount)
        {
            bool exist = this.stock.TryGetValue(product, out int value);

            if (exist)
                this.stock[product] = value + amount;
            else
                this.stock.Add(product, amount);

        }

        public int CurrentStock(string product)
        {
            throw new NotImplementedException();
        }

        public bool HasProduct(string product)
        {
            throw new NotImplementedException();
        }

        public void TakeStock(string product, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
