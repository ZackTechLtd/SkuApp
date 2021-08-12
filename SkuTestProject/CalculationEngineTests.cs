using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkuApp;
using SkuApp.Models;
using SkuApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SkuTestProject
{
    [TestClass]
    public class CalculationEngineTests
    {
        private readonly Mock<ISkuRepository> _mockRepository;
        public CalculationEngineTests()
        {
            List<SkuModel> skuModels = new List<SkuModel>
            {
                new SkuModel { Id = "A", UnitPrice = 50.0M },
                new SkuModel { Id = "B", UnitPrice = 30.0M },
                new SkuModel { Id = "C", UnitPrice = 20.0M },
                new SkuModel { Id = "D", UnitPrice = 15.0M },
            };
            _mockRepository = new Mock<ISkuRepository>();

            _mockRepository.Setup(x => x.All()).Returns(skuModels);
            _mockRepository.Setup(x => x.GetById(
                It.IsAny<string>())).Returns((string i) => skuModels.Where(
                x => x.Id == i).Single());
        }

        [TestMethod]
        public void TestScenarioA_Expect100()
        {
            List<string> products = new List<string>
            {
                "A","B","C"
            };

            CalculationEngine calculationEngine = new CalculationEngine(_mockRepository.Object);

            var result = calculationEngine.GetTotalPrice(products);

            Assert.AreEqual(100.0M, result);
        }

        [TestMethod]
        public void TestScenarioB_Expect370()
        {
            List<string> products = new List<string>
            {
                "A","A","A","A","A",
                "B","B","B","B","B",
                "C"
            };

            CalculationEngine calculationEngine = new CalculationEngine(_mockRepository.Object);

            var result = calculationEngine.GetTotalPrice(products);

            Assert.AreEqual(370.0M, result);
        }

        [TestMethod]
        public void TestScenarioC_Expect285()
        {
            List<string> products = new List<string>
            {
                "A","A","A",
                "B","B","B","B","B",
                "C","D"
            };

            CalculationEngine calculationEngine = new CalculationEngine(_mockRepository.Object);

            var result = calculationEngine.GetTotalPrice(products);

            Assert.AreEqual(285.0M, result);
        }
    }
}
