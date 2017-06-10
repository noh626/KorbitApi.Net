using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net.MarketTools
{
    public class Markets : IMarkets
    {
        private ApiWebClient ApiWebClient { get; set; }

        internal Markets(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
        }

        private IDictionary<CurrencyPair, ILastPrice> GetLastPrice()
        {
            var data = GetData<IDictionary<string, ILastPrice>>("ticker?currency_pair=$btc_krw");
            return data.ToDictionary(
                x => CurrencyPair.Parse(x.Key),
                x => (ILastPrice)x.Value
            );
        }
        private IDictionary<CurrencyPair, IMarketData> GetMarketData()
        {
            var data = GetData<MarketData>("ticker/detailed?currency_pair=btc_krw");
            return new Dictionary<CurrencyPair, IMarketData> { { CurrencyPair.Parse("btc_krw"), data } };
            //return data.ToDictionary(
            //    x => CurrencyPair.Parse(x.Key),
            //    x => (IMarketData)x.Value);
        }

        private IDictionary<string, List<IFilledOrders>> GetFilledOrder()
        {
            var data = GetData<IList<FilledOrders>>("transactions?currency_pair=btc_krw&time=minite");
            return new Dictionary<string, List<IFilledOrders>> {
                { "btc_krw", data.Select(x => (IFilledOrders)x).ToList() }
            };
        }

        private IConstants GetConstants()
        {
            var data = GetData<Constants>("constants");
            return data;
        }

        private T GetData<T>(string command, params object[] parameters)
        {
            return ApiWebClient.GetData<T>(command, parameters);
        }
        public Task<IDictionary<CurrencyPair, ILastPrice>> GetLastPriceAsync()
        {
            return Task.Factory.StartNew(() => GetLastPrice());
        }
        public Task<IDictionary<CurrencyPair, IMarketData>> GetMarketDataAsync()
        {
            return Task.Factory.StartNew(() => GetMarketData());
        }

        public Task<IDictionary<string, List<IFilledOrders>>> GetFilledOrdersAsync()
        {
            return Task.Factory.StartNew(() => GetFilledOrder());
        }

        public Task<IConstants> GetConstantsAsync()
        {
            return Task.Factory.StartNew(() => GetConstants());
        }
    }
}
