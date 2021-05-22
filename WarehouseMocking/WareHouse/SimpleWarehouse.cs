using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse
{
    class SimpleWarehouse : IWarehouse
    {
        public void AddStock(string product, int amount)
        {
            throw new NotImplementedException();
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
