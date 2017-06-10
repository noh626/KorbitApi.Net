using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KorbitApi.Net.MarketTools
{
    public class Constants : IConstants
    {
        [JsonProperty("krwWithdrwalFee")]
        public double krwWithdrwalFee { get; private set; }

        [JsonProperty("maxKrwWithdrawal")]
        public double maxKrwWithdrawal { get; private set; }

        [JsonProperty("minKrwWithdrawal")]
        public double minKrwWithdrawal { get; private set; }

        [JsonProperty("btcTickSize")]
        public double btcTickSize { get; private set; }

        [JsonProperty("btcWithdrawalFee")]
        public double btcWithdrawalFee { get; private set; }

        [JsonProperty("maxBtcOrder")]
        public double maxBtcOrder { get; private set; }

        [JsonProperty("maxBtcPrice")]
        public double maxBtcPrice { get; private set; }

        [JsonProperty("minBtcOrder")]
        public double minBtcOrder { get; private set; }

        [JsonProperty("minBtcPrice")]
        public double minBtcPrice { get; private set; }

        [JsonProperty("maxBtcWithdrawal")]
        public double maxBtcWithdrawal { get; private set; }

        [JsonProperty("minBtcWithdrawal")]
        public double minBtcWithdrawal { get; private set; }

        [JsonProperty("etcTickSize")]
        public double etcTickSize { get; private set; }

        [JsonProperty("maxEtcOrder")]
        public double maxEtcOrder { get; private set; }

        [JsonProperty("minEtcOrder")]
        public double minEtcOrder { get; private set; }

        [JsonProperty("maxEtcPrice")]
        public double maxEtcPrice { get; private set; }

        [JsonProperty("minEtcPrice")]
        public double minEtcPrice { get; private set; }
        [JsonProperty("ethTickSize")]
        public double ethTickSize { get; private set; }

        [JsonProperty("maxEthOrder")]
        public double maxEthOrder { get; private set; }

        [JsonProperty("maxEthPrice")]
        public double maxEthPrice { get; private set; }

        [JsonProperty("minEthOrder")]
        public double minEthOrder { get; private set; }

        [JsonProperty("minEthPrice")]
        public double minEthPrice { get; private set; }

        [JsonProperty("minTradableLevel")]
        public double minTradableLevel { get; private set; }
    }
}
