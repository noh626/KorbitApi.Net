using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KorbitApi.Net.MarketTools
{
    public class MarketData : IMarketData
    {
        [JsonProperty("timestamp")]
        public double timestamp { get; internal set; }
        
        [JsonProperty("last")]
        public double priceLast { get; internal set; }
        
        [JsonProperty("bid")]
        public double bid { get; internal set; }

        [JsonProperty("ask")]
        public double ask { get; internal set; }

        [JsonProperty("low")]
        public double lowestFor24hours { get; internal set; }

        [JsonProperty("high")]
        public double highestFor24hours { get; internal set; }

        [JsonProperty("volume")]
        public double volume { get; internal set;}
    }
}
