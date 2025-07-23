using Fruit_Sales_Calculator.Models;
using Fruit_Sales_Calculator.Pricing;
using Fruit_Sales_Calculator.Strategies;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        var marketPriceProvider = new MarketPriceProvider();    

        var factory = new PricingStrategyFactory();

        var weightStrategy = factory.CreatePricingStrategy(marketPriceProvider, PricingStrategyType.Weight);
        var unitStrategy = factory.CreatePricingStrategy(marketPriceProvider, PricingStrategyType.Unit);
        var weightDiscountStrategy = factory.CreatePricingStrategy(marketPriceProvider, PricingStrategyType.WeightDiscount, 0.1m);

        marketPriceProvider.UpdatePrice(new Fruit("Apple"));
        marketPriceProvider.UpdatePrice(new Fruit("Banana"));
        marketPriceProvider.UpdatePrice(new Fruit("Orange"));

        int appleQuantity = 1;
        int bananaQuantity = 1;
        int orangeQuantity = 1;
        decimal appleWeight = 2.5m;
        decimal bananaWeight = 2.5m;
        decimal orangeWeight = 2.5m;

        FruitOrder appleOrder = new FruitOrder(new Fruit("Apple"), appleWeight, appleQuantity);
        FruitOrder bananaOrder = new FruitOrder(new Fruit("Banana"), bananaWeight, bananaQuantity);
        FruitOrder orangeOrder = new FruitOrder(new Fruit("Orange"), orangeWeight, orangeQuantity);

        var appleOrderCalculatedPrice = weightStrategy.CalculatePrice(appleOrder);
        var bananaOrderCalculatedPrice = unitStrategy.CalculatePrice(bananaOrder);
        var orangeOrderCalculatedPrice = weightDiscountStrategy.CalculatePrice(orangeOrder);

        Debug.WriteLine($"Price for {appleOrder.WeightInKg} kg of Apple: {appleOrderCalculatedPrice}");
        Debug.WriteLine($"Price for {appleOrder.ItemCount} units of Banana: {bananaOrderCalculatedPrice}");
        Debug.WriteLine($"Price for {orangeOrder.WeightInKg} kg of Orange with discount: {orangeOrderCalculatedPrice}");


    }
}