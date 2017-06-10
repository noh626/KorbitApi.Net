using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net.MarketTools
{
    public interface IMarketData
    {
        double timestamp { get; }
        double priceLast { get; }
        double bid { get; }
        double ask { get; }
        double lowestFor24hours { get; }
        double highestFor24hours { get; }
        double volume { get; }
    }
}
