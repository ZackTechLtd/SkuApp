using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkuApp.Models;
using SkuApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkuTestProject
{
    [TestClass]
    public class SkuRepositoryTests
    {
        private readonly ISkuRepository _skuRepository;
        public SkuRepositoryTests()
        {
            _skuRepository = new SkuRepository();
        }


        [TestMethod]
        public void WhenGetAll_ExpectMoreAtLeast4Results()
        {
            IEnumerable<SkuModel> result = _skuRepository.All();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<SkuModel>));
            Assert.IsTrue(result.Count() > 3);

        }

        [TestMethod]
        public void WhenGetById_ExpectASkuModel()
        {
            SkuModel result = _skuRepository.GetById("A");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == "A");
        }

        [TestMethod]
        public void WhenGetByIdIsNotInDatabase_ExpectANullResult()
        {
            SkuModel result = _skuRepository.GetById("AAAAA");

            Assert.IsNull(result);
        }
    }
}
