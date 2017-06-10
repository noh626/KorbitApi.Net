using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net.MarketTools
{
    public interface IFilledOrders
    {
        double timeStamp { get; }
        double transactionId { get; }
        double price { get; }
        double amount { get; }

    }
}
