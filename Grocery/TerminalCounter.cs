using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LightInject;

namespace Grocery
{
    class TerminalCounter : ITerminal
    {
        private IServiceContainer _container;
        public TerminalCounter()
        {
            _container = ServiceDependency.GetInstance().Container;
            productPriceServices = new Dictionary<string, IProductPriceService>();
            tempPriceDict = new Dictionary<string, decimal>();
            totalQuantities = new Dictionary<string, decimal>();
        }

        private IDictionary<string, IProductPriceService> productPriceServices;
        private IDictionary<string, decimal> tempPriceDict;
        private IDictionary<string, decimal> totalQuantities;

        public void SetPrice(string productCode, decimal price)
        {
            if (string.IsNullOrEmpty(productCode))
            {
                return;
            }

            if (tempPriceDict.ContainsKey(productCode))
            {
                tempPriceDict[productCode] = price;
            }
            else
            {
                tempPriceDict.Add(productCode, price);
            }
        }

        public void ScanProduct(string productCode)
        {
            if (string.IsNullOrEmpty(productCode))
            {
                return;
            }
            if (tempPriceDict.ContainsKey(productCode))
            {
                if (totalQuantities.ContainsKey(productCode))
                {
                    totalQuantities[productCode] += tempPriceDict[productCode];
                }
                else
                {
                    totalQuantities.Add(productCode, tempPriceDict[productCode]);
                }
                return;
            }

            if (!productPriceServices.ContainsKey(productCode))
            {
                try
                {
                    var service = _container.GetInstance<IProductPriceService>(productCode);
                    productPriceServices.Add(productCode, service);
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"productcode:{productCode} doesn't exit in system");
                }

            }

            productPriceServices[productCode].ScanProduct();
        }

        public decimal CaculateTotal()
        {
            return totalQuantities.Sum(_ => _.Value) + productPriceServices.Sum(_ => _.Value.CaculateMoney());
        }
    }
}
