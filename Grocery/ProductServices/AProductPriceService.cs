namespace Grocery.ProductServices
{
    using System;

    /// <summary>
    /// Defines the <see cref="AProductPriceService" />.
    /// </summary>
    internal sealed class AProductPriceService : PriceServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AProductPriceService"/> class.
        /// </summary>
        public AProductPriceService()
        {
            UnitPrice = 1.25m;

            Promotion = new Tuple<int, decimal>(3, 3m);
        }

        /// <summary>
        /// Gets the ProductCode.
        /// </summary>
        public override string ProductCode => "A";
    }
}
