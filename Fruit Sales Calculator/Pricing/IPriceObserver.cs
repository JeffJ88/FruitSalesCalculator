using Fruit_Sales_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Sales_Calculator.Pricing
{
    public interface IPriceObserver
    {
        void OnPriceUpdated(Fruit fruit, decimal pricePerKg, decimal pricePerUnit);
    }
}
