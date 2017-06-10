using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KorbitApi.Net.MarketTools
{
    public class FilledOrders : IFilledOrders
    {
        [JsonProperty("timestamp")]
        public double timeStamp { get; private set; }

        [JsonProperty("tid")]
        public double transactionId { get; private set; }

        [JsonProperty("price")]
        public double price { get; private set; }

        [JsonProperty("amount")]
        public double amount { get; private set; }
    }
}
