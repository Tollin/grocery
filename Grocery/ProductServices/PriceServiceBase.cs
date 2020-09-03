namespace Grocery.ProductServices
{
    using System;

    /// <summary>
    /// Defines the <see cref="PriceServiceBase" />.
    /// </summary>
    public abstract class PriceServiceBase : IProductPriceService
    {
        /// <summary>
        /// Gets or sets the UnitPrice.
        /// </summary>
        protected virtual decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the ProductQuantity.
        /// </summary>
        protected virtual int ProductQuantity { get; set; }

        /// <summary>
        /// Gets or sets the Promotion.
        /// </summary>
        protected virtual Tuple<int, decimal> Promotion { get; set; }

        /// <summary>
        /// Gets the ProductCode.
        /// </summary>
        public abstract string ProductCode { get; }

        /// <summary>
        /// The ScanProduct.
        /// </summary>
        public void ScanProduct()
        {
            ProductQuantity += 1;
        }

        /// <summary>
        /// The CaculateMoney.
        /// </summary>
        /// <returns>The <see cref="decimal"/>.</returns>
        public decimal CaculateMoney()
        {
            var total = 0m;
            while (Promotion != null && ProductQuantity >= Promotion.Item1)
            {
                ProductQuantity -= Promotion.Item1;
                total += Promotion.Item2;
            }

            total += ProductQuantity * UnitPrice;

            return total;
        }
    }
}
