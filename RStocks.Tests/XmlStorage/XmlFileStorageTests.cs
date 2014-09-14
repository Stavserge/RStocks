using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RStocks.Model.Models;
using RStocks.XMLStorage.Common;

namespace RStocks.Tests.XmlStorage
{
    [TestFixture]
    public class XmlFileStorageTests
    {
        [Test]
        public void TestCanSaveFile()
        {
            var categories = new List<CategoryModel>();
            categories.Add(new CategoryModel() { Id = 1, CategoryName = "Cat1"});
            XmlFileStorage.SaveContainerToFile(categories, @"M:\temp\categories.xml");
        }

        [Test]
        public void TestCanReadFile()
        {
            var cm = XmlFileStorage.GetContainerFromFile<List<CategoryModel>>(@"M:\temp\categories.xml");
            cm.ForEach(x=>Console.WriteLine(x.CategoryName));
            cm = XmlFileStorage.GetContainerFromFile<List<CategoryModel>>(@"M:\temp\categories.xml");
            cm.ForEach(x => Console.WriteLine(x.CategoryName));
        }

        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestCanReadApsentFile()
        {
            var cm = XmlFileStorage.GetContainerFromFile<List<CategoryModel>>(@"M:\temp\categories1.xml");
            cm.ForEach(x => Console.WriteLine(x.CategoryName));
        }
    }
}
