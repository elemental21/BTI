using BuffaloTungsten.Domain.Abstract;
using BuffaloTungsten.Domain.DataContexts;
using BuffaloTungsten.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private BuffaloTungstenDB _context = new BuffaloTungstenDB();

        public IQueryable<Contact> Customers
        {
            get { return _context.Customers; }
        }

        public void AddCustomer(Contact customer)
        {
            _context.Customers.Add(customer);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
