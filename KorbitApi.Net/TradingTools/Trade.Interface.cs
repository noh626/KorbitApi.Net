using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net.TradingTools
{
    public interface ITrade
    {
        Task<KeyValuePair<ulong, bool>> PostOrderAsync(CurrencyPair currencyPair, OrderType type, PriceType priceType, double coinAmount, double fiatAmount, double price);
    }
}
