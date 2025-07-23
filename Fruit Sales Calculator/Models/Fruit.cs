using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Sales_Calculator.Models
{
    public class Fruit
    {
        public string Name { get; }

        public Fruit(string name)
        {
            Name = name;
        }
    }

    public class FruitOrder
    {
        public Fruit Fruit { get; }
        public decimal WeightInKg { get; }
        public int ItemCount { get; }

        public FruitOrder(Fruit fruit, decimal weightInKg, int itemCount)
        {
            Fruit = fruit;
            WeightInKg = weightInKg;
            ItemCount = itemCount;
        }
    }
}
