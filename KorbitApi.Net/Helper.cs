using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Numerics;
using System.Globalization;
using Newtonsoft.Json;

namespace KorbitApi.Net
{
    public static class Helper
    {
        internal const string ApiURLBase = "https://api.korbit.co.kr/v1/";
        internal const string ApiURLHttpsRelativePublic = "";
        internal static readonly DateTime DateTimeUnixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        internal static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;
        private static BigInteger CurrentHttpPostNonce { get; set; }
        internal static string GetResponseString(this HttpWebRequest request)
        {
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (stream == null) throw new NullReferenceException("The HttpWebRequest's response stream cannot be empty.");

                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        internal static T DeserializeObject<T>(this JsonSerializer serializer, string value)
        {
            using (var stringReader = new StringReader(value))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return (T)serializer.Deserialize(jsonTextReader, typeof(T));
                }
            }
        }

        internal static string ToHttpPostString(this Dictionary<string, object> dictionary)
        {
            var output = string.Empty;
            foreach (var entry in dictionary)
            {
                var valueString = entry.Value as string;
                if (valueString == null)
                {
                    output += "&" + entry.Key + "=" + entry.Value;
                }
                else
                {
                    output += "&" + entry.Key + "=" + valueString.Replace(' ', '+');
                }
            }

            return output.Substring(1);
        }

        internal static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            return DateTimeUnixEpochStart.AddSeconds(unixTimeStamp);
        }

        internal static ulong DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            return (ulong)Math.Floor(dateTime.Subtract(DateTimeUnixEpochStart).TotalSeconds);
        }

        internal static DateTime ParseDateTime(string dateTime)
        {
            return DateTime.SpecifyKind(DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", InvariantCulture), DateTimeKind.Utc).ToLocalTime();
        }
        internal static string GetCurrentHttpPostNonce()
        {
            var newHttpPostNonce = new BigInteger(Math.Round(DateTime.UtcNow.Subtract(DateTimeUnixEpochStart).TotalMilliseconds * 1000, MidpointRounding.AwayFromZero));
            if (newHttpPostNonce > CurrentHttpPostNonce)
            {
                CurrentHttpPostNonce = newHttpPostNonce;
            }
            else
            {
                CurrentHttpPostNonce += 1;
            }

            return CurrentHttpPostNonce.ToString(InvariantCulture);
        }
    }
}
