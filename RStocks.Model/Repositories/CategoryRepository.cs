using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RStocks.Model.Models;

namespace RStocks.Model.Repositories
{
    public abstract class CategoryRepository
    {
        public abstract List<CategoryModel> GetCategories(int? paretnCategoryId);
    }
}
