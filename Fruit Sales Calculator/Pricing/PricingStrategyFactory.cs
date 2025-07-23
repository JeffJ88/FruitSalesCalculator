using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fruit_Sales_Calculator.Strategies;

namespace Fruit_Sales_Calculator.Pricing
{
    public class PricingStrategyFactory
    {
        public IPricingStrategy CreatePricingStrategy(IPriceProvider priceProvider, PricingStrategyType strategyType, decimal? discountRate = null)
        {
            return strategyType switch
            {
                PricingStrategyType.Weight => new WeightPricingStrategy(priceProvider),

                PricingStrategyType.Unit => new UnitPricingStrategy(priceProvider),
                PricingStrategyType.WeightDiscount when discountRate.HasValue => new WeightDiscountPricingStrategy(priceProvider, discountRate.Value),
                _ => throw new ArgumentException($"Unknown pricing strategy type: {strategyType}")
            };
        }

    }
}
