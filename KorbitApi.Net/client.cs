using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KorbitApi.Net.Authentication;
using KorbitApi.Net.MarketTools;

namespace KorbitApi.Net
{
    public class client
    {
        public IAuthentication authenticator { get; private set; }
        public IMarkets Markets { get; private set; }

        public client (string email, string password)
        {
            var apiWebClient = new ApiWebClient(Helper.ApiURLBase);
            authenticator = new Authentication.Authentication(apiWebClient, email, password);
            Markets = new Markets(apiWebClient);
        }
    }
}
