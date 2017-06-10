using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net.MarketTools
{
    public interface IMarkets
    {
        /// <summary>
        /// Gets a last prices of the markets
        /// </summary>
        /// <returns></returns>
        Task<IDictionary<CurrencyPair, ILastPrice>> GetLastPriceAsync();

        Task<IDictionary<CurrencyPair, IMarketData>> GetMarketDataAsync();

        Task<IDictionary<string, List<IFilledOrders>>> GetFilledOrdersAsync();

        Task<IConstants> GetConstantsAsync();
    }
}
