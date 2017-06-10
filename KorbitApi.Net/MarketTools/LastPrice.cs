using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KorbitApi.Net.MarketTools
{
    public class LastPrice : ILastPrice
    {
        [JsonProperty("timestamp")]
        public double timestamp { get; internal set; }

        [JsonProperty("last")]
        public double lastprice { get; internal set; }
    }
}
