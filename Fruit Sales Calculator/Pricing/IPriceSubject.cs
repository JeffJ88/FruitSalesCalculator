using Fruit_Sales_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Sales_Calculator.Pricing
{
    public interface IPriceSubject
    {
        void AddObserver(IPriceObserver observer);
        void RemoveObserver(IPriceObserver observer);
        void NotifyObserversPriceChange(Fruit fruit);
    }
}
