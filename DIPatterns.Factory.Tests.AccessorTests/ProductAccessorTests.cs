using System.Configuration;
using System.Transactions;
using DIPatterns.Factory.Accessors;
using DIPatterns.Factory.Contracts.DataContracts;
using DIPatterns.Factory.Contracts.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DIPatterns.Factory.Tests.AccessorTests
{
    [TestClass]
    public class ProductAccessorTests
    {
        TransactionScope _testTransactionScope;
        string _connString;

        [TestInitialize]
        public void TestInitialize()
        {
            _testTransactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);
            _connString = ConfigurationManager.ConnectionStrings["DIDB"].ConnectionString;
        }

        [TestMethod]
        public void ProductAccessor_SaveNew()
        {
            Product product = new Product()
            {
                ProductName = "Test",
                Price = "$10.00",
                Brand = "HobbyTown",
                Site = "HobbyTown",
                ProductUrl = @"http://www.url.com",
                ListPrice = "$10.00",
                ProductCode = "MAN12345"
            };
            IAccessorFactory factory = new AccessorFactory();
            IProductAccessor acc = factory.CreateAccessor<IProductAccessor>();

            product = acc.Save(_connString, product);

            Assert.AreNotEqual(0, product.Id);
            Assert.AreEqual("Test", product.ProductName);
            Assert.AreEqual("$10.00", product.Price);
            Assert.AreEqual("HobbyTown", product.Brand);
            Assert.AreEqual("MAN12345", product.ProductCode);
        }

        [TestCleanup]
        void TestCleanup()
        {
            _testTransactionScope.Dispose();
        }

    }
}
