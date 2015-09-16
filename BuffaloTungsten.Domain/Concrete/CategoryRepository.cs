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
    public class CategoryRepository : ICategoryRepository
    {
        private BuffaloTungstenDB _context = new BuffaloTungstenDB();

        IQueryable<Category> ICategoryRepository.Categories
        {
            get { return _context.Categories; }
        }
    }
}
