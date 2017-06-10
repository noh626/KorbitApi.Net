using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net.TradingTools
{
    public class Trade : ITrade
    {
        private KeyValuePair<ulong, bool> PostOrder(CurrencyPair currencyPair, OrderType orderType, PriceType priceType, double coinAmount, double fiatAmount, double price)
        {
            var postData = new Dictionary<string, object> { 
                { "CurrencyPair", currencyPair },
                { "type", orderType },
                { "price", price },
                { "coin_amount", coinAmount}
            };

            
        }
    }
}
