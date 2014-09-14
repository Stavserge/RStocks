using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RStocks.Model.Factories;
using RStocks.Model.Repositories;
using RStocks.XMLStorage.Repositories;

namespace RStocks.XMLStorage
{
    public class XmlRepositoryFactory : IRepositoryFactory
    {
        protected string RootPath;
        
        public XmlRepositoryFactory(string rootPath)
        {
            RootPath = rootPath;
        }

        public CategoryRepository GetCategoryRepository()
        {
            return new XmlCategoryRepository(this, RootPath);
        }
    }
}
