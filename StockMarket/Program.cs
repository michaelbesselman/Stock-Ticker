using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockMarket.Observer;

namespace StockMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var stockTicker = new StockTicker();

            var tickerTape = new TickerTape(stockTicker);

            var derivative = new Derivative(stockTicker, "GOOG");

            Console.ReadKey();
        }
    }
}
