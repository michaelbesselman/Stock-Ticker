using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockMarket.Observer;

namespace StockMarket
{
    public class TickerTape: IObserve
    {
        private double _stockPrice;
        private string _stockName;
        private DateTime _dateTime;
        private readonly StockTicker _stockTicker;

        public TickerTape(StockTicker stockTicker)
        {
            _stockTicker = stockTicker;
            _stockTicker.RegisterObserver(this);
        }

        ~TickerTape()
        {
            Release();
        }

        public void Release()
        {
            _stockTicker.RemoveObserver(this);
        }

        public void SendStockPrice(string p1, double p2, DateTime time)
        {
            _stockPrice = p2;
            _stockName = p1;
            _dateTime = time;
            Display();
        }

        public void Display()
        {
            Console.WriteLine(String.Format("Company: {0}, Price : ${1:0.00} @ {2}", _stockName, _stockPrice, _dateTime));
        }
    }
}
