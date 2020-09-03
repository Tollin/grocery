using System;
using Grocery;
using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryTest
{
    [TestClass]
    public class TerminalCounterTest
    {
        private IServiceContainer container;
        [TestInitialize]
        public void InitalTest()
        {
            var _container = new ServiceContainer();
            var instance = ServiceDependency.GetInstance(_container);
            instance.RegisterServices();
            container = instance.Container;

        }

        [TestMethod]
        public void SingalTest_Empty()
        {
            var products = "";
            var terminal = container.GetInstance<ITerminal>();
            terminal.ScanProduct(products);
            var money = terminal.CaculateTotal();
            Assert.AreEqual<decimal>(0m, money);

            products = null;
            terminal = container.GetInstance<ITerminal>();
            terminal.ScanProduct(products);
            money = terminal.CaculateTotal();
            Assert.AreEqual<decimal>(0m, money);
        }
        
        [TestMethod]
        public void SingalTest_A()
        {
            var products = "A";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(1.25m, money);
        }

        [TestMethod]
        public void SingalTest_AA()
        {
            var products = "AA";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(2.5m, money);
        }

        [TestMethod]
        public void SingalTest_AAA()
        {
            var products = "AAA";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(3m, money);
        }

        [TestMethod]
        public void SingalTest_AAAA()
        {
            var products = "AAAA";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(4.25m, money);
        }

        [TestMethod]
        public void SingalTest_7A()
        {
            var products = "AAAAAAA";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(7.25m, money);
        }

        [TestMethod]
        public void SingalTest_B()
        {
            var products = "B";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(4.25m, money);
        }

        [TestMethod]
        public void SingalTest_BB()
        {
            var products = "BB";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(8.5m, money);
        }

        [TestMethod]
        public void SingalTest_AAAB()
        {
            var products = "AAAB";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(7.25m, money);
        }

        [TestMethod]
        public void SingalTest_AAAAAAABBB()
        {
            var products = "AAAAAAABBB";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(20m, money);
        }

        [TestMethod]
        public void SingalTest_AAABBBCCCCCCDD()
        {
            var products = "AAABBBCCCCCCDD";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(22.25M, money);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void SingalTest_T()
        {
            var products = "T";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(22.25M, money);
        }

        [TestMethod]
        public void SingalTest_Preset_T()
        {
            var products = "T";
            var terminal = container.GetInstance<ITerminal>();
            terminal.SetPrice(products, 3m);
            terminal.ScanProduct(products);
            var money = terminal.CaculateTotal();
            Assert.AreEqual<decimal>(3m, money);
        }

        [TestMethod]
        public void SingalTest_Preset_Empty()
        {
            var products = "DCCCCCC";
            var terminal = container.GetInstance<ITerminal>();
            terminal.SetPrice("", 3m);
            foreach (var product in products)
            {
                terminal.ScanProduct(product.ToString());
            }
            var money = terminal.CaculateTotal();
            Assert.AreEqual<decimal>(5.75m, money);
        }

        #region  preserved tests
        [TestMethod]
        public void SingalTest_ABCDABA()
        {
            var products = "ABCDABA";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(13.25M, money);
        }

        [TestMethod]
        public void SingalTest_CCCCCCC()
        {
            var products = "CCCCCCC";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(6M, money);
        }

        [TestMethod]
        public void SingalTest_ABCD()
        {
            var products = "ABCD";
            var money = ScanProducts(products);
            Assert.AreEqual<decimal>(7.25m, money);
        }
        #endregion

        private decimal ScanProducts(string products)
        {
            var terminal = container.GetInstance<ITerminal>();
            foreach (var product in products)
            {
                terminal.ScanProduct(product.ToString());
            }

            return terminal.CaculateTotal();
        }
    }
}
