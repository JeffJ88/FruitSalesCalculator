using Fruit_Sales_Calculator.Models;
using Fruit_Sales_Calculator.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Sales_Calculator.Strategies
{
    public interface IPricingStrategy
    {
        decimal CalculatePrice(FruitOrder order);
    }

    public enum PricingStrategyType
    {
        Weight,
        Unit,
        WeightDiscount
    }

    public class WeightPricingStrategy: IPricingStrategy
    {
        private readonly IPriceProvider _priceProvider;

        public WeightPricingStrategy(IPriceProvider priceProvider)
        {
            _priceProvider = priceProvider ?? throw new ArgumentNullException(nameof(priceProvider), "Price provider cannot be null.");
        }

        public decimal CalculatePrice(FruitOrder order)
        {
            var fruitPricePerKg = _priceProvider.GetPricePerKg(order.Fruit);

            if (order.WeightInKg< 0 || fruitPricePerKg < 0)
            {
                throw new ArgumentException("Weight and price per kg must be non-negative.");
            }
            return order.WeightInKg * fruitPricePerKg;
        }
    }

    public class UnitPricingStrategy: IPricingStrategy
    {
        private readonly IPriceProvider _priceProvider;

        public UnitPricingStrategy(IPriceProvider priceProvider)
        {
            _priceProvider = priceProvider ?? throw new ArgumentNullException(nameof(priceProvider), "Price provider cannot be null.");
        }

        public decimal CalculatePrice(FruitOrder order)
        {
            var fruitPricePerUnit = _priceProvider.GetPricePerUnit(order.Fruit);

            if (order.ItemCount < 0 || fruitPricePerUnit < 0)
            {
                throw new ArgumentException("Item count and price per unit must be non-negative");
            }
            return order.ItemCount * fruitPricePerUnit;
        }
    }

    public class WeightDiscountPricingStrategy: IPricingStrategy
    {
        private readonly IPriceProvider _priceProvider;

        private readonly decimal _discountRate;
        public WeightDiscountPricingStrategy(IPriceProvider priceProvider, decimal discountRate)
        {
            _priceProvider = priceProvider ?? throw new ArgumentNullException(nameof(priceProvider), "Price provider cannot be null.");

            if (discountRate < 0 || discountRate > 1)
            {
                throw new ArgumentException("Discount rate must be between 0 and 1.");
            }
            _discountRate = discountRate;
        }
        public decimal CalculatePrice(FruitOrder order)
        {
            var fruitPricePerKg = _priceProvider.GetPricePerKg(order.Fruit);

            if (order.WeightInKg < 0 || fruitPricePerKg < 0)
            {
                throw new ArgumentException("Weight and price per kg must be non-negative.");
            }
           
            if (order.WeightInKg > 2)
            {
                var price = order.WeightInKg * fruitPricePerKg * (1 - _discountRate);
                return price;
            }
            else
            {
                return order.WeightInKg * fruitPricePerKg; // No discount applied for weights <= 2 kg
            }
        }
    }
}
