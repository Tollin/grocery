using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery
{
    public interface ITerminal
    {
        void SetPrice(string productCode, decimal price);

        void ScanProduct(string productCode);

        decimal CaculateTotal();
    }
}
