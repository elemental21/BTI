using BuffaloTungsten.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Concrete
{
    class InventoryRepository : IInventoryRepository
    {
        public IEnumerable<Entities.Inventory> GetInventoryByLot(string lotNumber, string lotType)
        {
            throw new NotImplementedException();
        }
    }
}
