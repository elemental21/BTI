using BuffaloTungsten.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuffaloTungsten.Domain.Abstract
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }

        void AddCustomer(Customer customer);

        void Save();
    }
}
