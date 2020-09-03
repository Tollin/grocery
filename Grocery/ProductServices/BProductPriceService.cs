namespace Grocery.ProductServices
{
    /// <summary>
    /// Defines the <see cref="BProductPriceService" />.
    /// </summary>
    internal sealed class BProductPriceService : PriceServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BProductPriceService"/> class.
        /// </summary>
        public BProductPriceService()
        {
            UnitPrice = 4.25m;
        }

        /// <summary>
        /// Gets the ProductCode.
        /// </summary>
        public override string ProductCode => "B";
    }
}
