using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RStocks.Model.Repositories;

namespace RStocks.Model.Factories
{
    public interface IRepositoryFactory
    {
        CategoryRepository GetCategoryRepository();
    }
}
