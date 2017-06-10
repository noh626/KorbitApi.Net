using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net.MarketTools
{
    public interface IConstants
    {
        double krwWithdrwalFee { get; }
        double maxKrwWithdrawal { get; }
        double minKrwWithdrawal { get; }
        double btcTickSize { get; }
        double btcWithdrawalFee { get; }
        double maxBtcOrder { get; }
        double maxBtcPrice { get; }
        double minBtcOrder { get; }
        double minBtcPrice { get; }
        double maxBtcWithdrawal { get; }
        double minBtcWithdrawal { get; }
        double etcTickSize { get; }
        double maxEtcOrder { get; }
        double minEtcOrder { get; }
        double maxEtcPrice { get; }
        double minEtcPrice { get; }
        double ethTickSize { get; }
        double maxEthOrder { get; }
        double maxEthPrice { get; }
        double minEthOrder { get; }
        double minEthPrice { get; }
        double minTradableLevel {get;}
    }
}
