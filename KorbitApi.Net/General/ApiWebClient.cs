using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using KorbitApi.Net.Authentication;

namespace KorbitApi.Net
{
    sealed class ApiWebClient
    {
        public string BaseUrl { get; private set; }

        private Authentication.Authentication _auth;

        private static readonly JsonSerializer jsonSerializer = new JsonSerializer { NullValueHandling = NullValueHandling.Ignore };
        public Authentication.Authentication Authenticator
        {
            private get { return _auth; }
            set
            {
                _auth = value;
            }
        }

        public ApiWebClient(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public T GetData<T>(string command, params object[] parameters)
        {
            var relativeUrl = CreateRelativeUrl(command, parameters);
            var jsonString = QueryString(relativeUrl);
            //var output = JsonConvert.DeserializeObject<T>(jsonString);
            var output = jsonSerializer.DeserializeObject<T>(jsonString);
            return output;
        }

        public T PostData<T>(string command, Dictionary<string, object> postData)
        {
            postData.Add("command", command);
            postData.Add("nonce", Helper.GetCurrentHttpPostNonce());
            var jsonString = PostString(Helper.ApiURLBase, postData.ToHttpPostString());
            var output = jsonSerializer.DeserializeObject<T>(jsonString);
            return output;
        }

        private static string CreateRelativeUrl(string command, object[] parameters)
        {
            var relativeUrl = command;
            if (parameters.Length != 0) {
                relativeUrl += "&" + string.Join("&", parameters);
            }
            return relativeUrl;
        }

        private string QueryString(string relativeUrl)
        {
            var request = CreateHttpWebRequest("GET", relativeUrl);
            return request.GetResponseString() ;
        }

        private string PostString(string relativeUrl, string postData)
        {
            var request = CreateHttpWebRequest("POST", relativeUrl);
            request.ContentType = "application/x-www.form-urlencoded";

            var postBytes = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = postBytes.Length;
            request.Headers["Key"] = "public key";
            //request.Headers["sign"] = 

            using (var requestStream = request.GetRequestStream()) {
                requestStream.Write(postBytes, 0, postBytes.Length);
            }
            return request.GetResponseString();
        }

        private HttpWebRequest CreateHttpWebRequest(string method, string relativeUrl)
        {
            var request = WebRequest.CreateHttp(BaseUrl + relativeUrl);
            request.Method = method;
                //request.UserAgent = 
            request.Timeout = System.Threading.Timeout.Infinite;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip,deflate";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return request;
        }
    }
}
