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
            get { return _context.Contacts; }
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
