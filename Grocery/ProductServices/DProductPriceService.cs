using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ProductServices
{
    sealed class DProductPriceService : PriceServiceBase
    {
        public override string ProductCode => "D";

        public DProductPriceService()
        {
            UnitPrice = 0.75m;
        }
    }
}
