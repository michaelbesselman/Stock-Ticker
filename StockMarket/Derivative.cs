using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockMarket.Observer;

namespace StockMarket
{
    public class Derivative : IObserve
    {
        private readonly String _stockName ;
        private double _previousPrice;
        private DateTime _previousDateTime;
        private double _currentPrice;
        private DateTime _currentDateTime;
        private readonly StockTicker _stockTicker;
        private double _derivative;

        public Derivative(StockTicker stockTicker, String stockName)
        {
            _stockName = stockName;
            _stockTicker = stockTicker;
            _stockTicker.RegisterObserver(this);
        }

        ~Derivative()
        {
            Release();
        }
        public void Release()
        {
            _stockTicker.RemoveObserver(this);
        }

        public void SendStockPrice(string p1, double p2, DateTime time)
        {
            if(!String.Equals(p1, _stockName, StringComparison.CurrentCultureIgnoreCase)) return;
            _previousPrice = _currentPrice;
            _previousDateTime = _currentDateTime;
            _currentPrice = p2;
            _currentDateTime = time;

            _derivative = (_currentPrice - _previousPrice) / (_currentDateTime - _previousDateTime).Seconds;
            Display();
        }

        public void Display()
        {
            Console.WriteLine(String.Format("Company: {0}, derivative : ${1:0.00}/sec @ {2}", _stockName, _derivative, _currentDateTime));
        }
    }
}
