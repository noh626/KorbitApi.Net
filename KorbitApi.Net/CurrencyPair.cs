using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net
{
   
   
    public class CurrencyPair
    {
        private const char SeparatorCharacter = '_';
        public string BaseCurrency { get; private set; }
        public string QuoteCurrency { get; private set; }

        public CurrencyPair(string baseCurrency, string quoteCurrency)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
        }

        public static CurrencyPair Parse(string currencyPair)
        {
            var valueSplit = currencyPair.Split(SeparatorCharacter);
            return new CurrencyPair(valueSplit[0], valueSplit[1]);
        }
        public override string ToString()
        {
            return BaseCurrency + SeparatorCharacter + QuoteCurrency;
        }
    }
}
