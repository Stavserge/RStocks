using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RStocks.Model.Models;
using RStocks.XMLStorage;
using RStocks.XMLStorage.Repositories;

namespace RStocks.Tests.Repositories
{
    [TestFixture]
    public class XmlCategoryRepositoryTests
    {
        protected XmlCategoryRepository CategoryRepository;
        protected XmlRepositoryFactory RepositoryFactory;

        [SetUp]
        public void Setup()
        {
            var rootPath = @"M:\temp";
            RepositoryFactory = new XmlRepositoryFactory(rootPath);
            CategoryRepository = new XmlCategoryRepository(RepositoryFactory, rootPath);
        }

        [Test]
        public void TestCanGetRootCategories()
        {
             CategoryRepository.GetCategories(null).ForEach(x=>Console.WriteLine(x.CategoryName));
        }

        [Test]
        public void TestCanAddNewCategory()
        {
            CategoryRepository.AddCategory(new CategoryModel() { CategoryName = "Some new category" + DateTime.Now});
            CategoryRepository.GetCategories(null).ForEach(x => Console.WriteLine(x.CategoryName));
        }

        [Test]
        public void TestCanUpdateCategory()
        {
            var oldCat = CategoryRepository.GetCategory(1);
            if (oldCat != null)
            {
                oldCat.CategoryName = "Updated category " + DateTime.Now;
                CategoryRepository.UpdateCategory(oldCat);
                Console.WriteLine(CategoryRepository.GetCategory(1).CategoryName);
            }
        }
    }
}
