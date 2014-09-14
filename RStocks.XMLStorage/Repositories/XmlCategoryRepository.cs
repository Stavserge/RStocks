using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RStocks.Model.Factories;
using RStocks.Model.Models;
using RStocks.Model.Repositories;
using RStocks.XMLStorage.Common;

namespace RStocks.XMLStorage.Repositories
{
    public class XmlCategoryRepository : CategoryRepository
    {
        protected IRepositoryFactory RepositoryFactory;
        protected string fullFileName;
        private readonly string _fileName = "categories.xml";

        private List<CategoryModel> _allCategories;
        private void FlushToDisk()
        {
            GC.Collect();
            XmlFileStorage.SaveContainerToFile(_allCategories, fullFileName);
        }

        public XmlCategoryRepository(IRepositoryFactory repositoryFactory, string rootPath)
        {
            RepositoryFactory = repositoryFactory;
            fullFileName = rootPath + "\\" + _fileName;
            try
            {
                _allCategories = XmlFileStorage.GetContainerFromFile<List<CategoryModel>>(fullFileName);
            }
            catch (FileNotFoundException filenotfound)
            {
                _allCategories =  new List<CategoryModel>();
            }
        }
        
       
        public override List<CategoryModel> GetCategories(int? paretnCategoryId)
        {
            GC.Collect();
            return _allCategories.Where(x=>x.ParentId == paretnCategoryId).ToList();
        }

        public override void AddCategory(CategoryModel cat)
        {            
            var nextId = _allCategories.Max(x => x.Id);
            if (cat.Id == 0)
                cat.Id = nextId + 1;
            _allCategories.Add(cat);
            FlushToDisk();
        }

        public override void UpdateCategory(CategoryModel cat)
        {
            var oldCat = _allCategories.FirstOrDefault(x => x.Id == cat.Id);
            if (oldCat == null)
            {
                AddCategory(cat);
                return;
            }
            oldCat = cat;
            FlushToDisk();
        }

        public override CategoryModel GetCategory(int id)
        {
            return _allCategories.FirstOrDefault(x => x.Id == id);
        }
    }
}
