using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fruit_Sales_Calculator.Models;

namespace Fruit_Sales_Calculator.Pricing
{
    public class MarketPriceProvider : IPriceProvider, IPriceSubject
    {
        private readonly Dictionary<string, decimal> _pricePerKg = new();
        private readonly Dictionary<string, decimal> _pricePerItem = new();
        private readonly List<IPriceObserver> _observers = new List<IPriceObserver>();

        //simulates getting random price per kg data from market
        public decimal SetRandomPricePerKg()
        {
            var rand = new Random();
            var randomDecimal = new decimal(rand.NextDouble() * (10 - 0.1) + 0.1); 

            return randomDecimal;
        }

        //simulates getting random price per unit data from market
        public decimal SetRandomPricePerUnit()
        {
            var rand = new Random();
            var randomDecimal = new decimal(rand.NextDouble() * (10 - 0.1) + 0.1);

            return randomDecimal;
        }
        public void UpdatePrice(Fruit fruit)
        {
            _pricePerKg[fruit.Name] = SetRandomPricePerKg();
            _pricePerItem[fruit.Name] = SetRandomPricePerUnit();
            NotifyObserversPriceChange(fruit);
        }

        public void UpdatePrice(Fruit fruit, decimal pricePerKg, decimal pricePerItem)
        {
            _pricePerKg[fruit.Name] = pricePerKg;
            _pricePerItem[fruit.Name] = pricePerItem;
            NotifyObserversPriceChange(fruit);
        }

        public decimal GetPricePerKg(Fruit fruit)
        {
            if (_pricePerKg.TryGetValue(fruit.Name, out var price))
            {
                return price;
            }
            throw new KeyNotFoundException($"Price for {fruit.Name} not found.");
        }

        public decimal GetPricePerUnit(Fruit fruit)
        {
            if (_pricePerItem.TryGetValue(fruit.Name, out var price))
            {
                return price;
            }
            throw new KeyNotFoundException($"Price for {fruit.Name} not found.");
        }

        public void AddObserver(IPriceObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver (IPriceObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObserversPriceChange(Fruit fruit)
        {
            foreach (var observer in _observers)
            {
                observer.OnPriceUpdated(fruit, _pricePerKg[fruit.Name], _pricePerKg[fruit.Name]);
            }
        }
    }
}
