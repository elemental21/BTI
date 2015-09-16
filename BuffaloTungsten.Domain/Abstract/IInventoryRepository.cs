using BuffaloTungsten.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Abstract
{
    interface IInventoryRepository
    {
        IEnumerable<Inventory> GetInventoryByLot(string lotNumber, string lotType);

        void AddOrUpdateInventory(IEnumerable<Inventory> items);
    }
}
