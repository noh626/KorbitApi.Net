using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net.MarketTools
{
    public interface ILastPrice
    {
        double timestamp { get; }
        double lastprice { get; }

    }
}
