using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorbitApi.Net.Authentication
{
    public interface IAuthentication
    {
        string tokenType { get; }
        string accessToken { get; }
        double expiresIn { get; }
        string refreshToken { get; }

    }
}
