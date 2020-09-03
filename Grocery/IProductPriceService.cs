using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery
{
    interface IProductPriceService
    {
        public static string ProductCode { get; }

        void ScanProduct();

        decimal CaculateMoney();
    }
}
