using BuffaloTungsten.Domain.Abstract;
using BuffaloTungsten.Domain.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace BuffaloTungsten.Domain.Concrete
{
    public class InventoryRepository : IInventoryRepository
    {
        private BuffaloTungstenDB _context = new BuffaloTungstenDB();

        public IEnumerable<Entities.Inventory> GetInventoryByLot(string lotNumber, string lotType)
        {
            throw new NotImplementedException();
        }

        // This probably shouldn't be used anywhere except the UploadInventory action since it makes use of AddOrUpdate which is a seed method
        void IInventoryRepository.AddOrUpdateInventory(IEnumerable<Entities.Inventory> items)
        {
            _context.Inventories.AddOrUpdate(p => p.LotNumber, items.ToArray());
            //foreach (var item in items)
            //{
            //    _context.Inventories.Add(item);
            //}
            _context.SaveChanges();
        }
    }
}
