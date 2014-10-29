using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockMarket.Observer
{
    public class StockTicker : ISubject
    {
        private readonly List<IObserve> _observes;
        private string _stockName;
        private double _stockPrice;
        private DateTime _dateTime;

        public StockTicker()
        {
            _observes = new List<IObserve>();
            var thread = new Thread(KickPrice);
            thread.Start();
        }

        public void RegisterObserver(IObserve o)
        {
            _observes.Add(o);
        }

        public void RemoveObserver(IObserve o)
        {
            _observes.Remove(o);
        }

        private void NotifyObservers()
        {
            foreach (var observe in _observes)
            {
                observe.SendStockPrice(_stockName, _stockPrice, _dateTime);
            }
        }

        private void SetStockPrice(string stockName, double price, DateTime time)
        {
            this._dateTime = time;
            this._stockName = stockName;
            this._stockPrice = price;
            NotifyObservers();
        }

        private void KickPrice()
        {
            var rnd = new Random();
            var price = 22.23 * rnd.NextDouble() + 100;

            var stockName = "";
            switch (rnd.Next(4))
            {
                case 0:
                    stockName = "GOOG";
                    break;
                case 1:
                    stockName = "MSFT";
                    break;
                case 2:
                    stockName = "YHOO";
                    break;
                case 3:
                    stockName = "FB";
                    break;
                default:
                    stockName = "NASDEQ";
                    break;
            }
            SetStockPrice(stockName, price, DateTime.Now);

            Thread.Sleep(1000 * (rnd.Next(4) + 1));
            KickPrice();
        }
    }
}
