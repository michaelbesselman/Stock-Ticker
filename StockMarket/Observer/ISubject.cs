using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Observer
{
    public interface ISubject
    {
        void RegisterObserver(IObserve o);
        void RemoveObserver(IObserve o);
    }
}
