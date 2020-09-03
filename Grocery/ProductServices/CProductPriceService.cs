namespace Grocery.ProductServices
{
    using System;

    /// <summary>
    /// Defines the <see cref="CProductPriceService" />.
    /// </summary>
    internal sealed class CProductPriceService : PriceServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CProductPriceService"/> class.
        /// </summary>
        public CProductPriceService()
        {
            UnitPrice = 1m;
            Promotion = new Tuple<int, decimal>(6, 5m);
        }

        /// <summary>
        /// Gets the ProductCode.
        /// </summary>
        public override string ProductCode => "C";
    }
}
