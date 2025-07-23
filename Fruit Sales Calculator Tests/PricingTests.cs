using Fruit_Sales_Calculator.Models;
using Fruit_Sales_Calculator.Pricing;
using Fruit_Sales_Calculator.Strategies;

namespace Fruit_Sales_Calculator_Tests
{
    public class PricingTests
    {
        [Fact]
        public void WeightPricingStrategy_ReturnsCorrectPrice()
        {
            var fruit = new Fruit("Apple");
            var order = new FruitOrder(fruit, 3.0m, 1);

            var factory = new PricingStrategyFactory();
            var priceProvider = new MarketPriceProvider();

            var strategy = factory.CreatePricingStrategy(priceProvider, PricingStrategyType.Weight);
            priceProvider.UpdatePrice(fruit, 2.0m, 1.5m);

            var price = strategy.CalculatePrice(order);

            Assert.Equal(6.0m, price);
        }

        [Fact]
        public void WeightPricingStrategy_ThrowsOnNegativeWeight()
        {
            var fruit = new Fruit("Apple");
            var order = new FruitOrder(fruit, -1.0m, 1);
            var factory = new PricingStrategyFactory();
            var priceProvider = new MarketPriceProvider();

            var strategy = factory.CreatePricingStrategy(priceProvider, PricingStrategyType.Weight);
            priceProvider.UpdatePrice(fruit);

            Assert.Throws<ArgumentException>(() => strategy.CalculatePrice(order));
        }

        [Fact]
        public void UnitPricingStrategy_ReturnsCorrectPrice()
        {
            var fruit = new Fruit("Apple");
            var order = new FruitOrder(fruit, 4.0m, 2);
            var factory = new PricingStrategyFactory();
            var priceProvider = new MarketPriceProvider();

            var strategy = factory.CreatePricingStrategy(priceProvider, PricingStrategyType.Unit);
            priceProvider.UpdatePrice(fruit, 2.0m, 1.5m);


            var price = strategy.CalculatePrice(order);

            Assert.Equal(3.0m, price);
        }
    }
}