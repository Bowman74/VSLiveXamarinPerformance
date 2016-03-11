using System;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;

namespace Demo1
{
    public class NetworkTests
    {
        public static async Task<TimeSpan> ManagedNetworkSpeedAsync(bool secure)
        {
            using (var client = new HttpClient())
            {
                return await RunTestAsync(secure, client);
            }
        }

        public static async Task<TimeSpan> NativeNetworkSpeedAsync(bool secure)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                return await RunTestAsync(secure, client);
            }
        }

        public static async Task<TimeSpan> RunTestAsync(bool secure, HttpClient client)
        {
            var start = DateTime.Now;
            for (var i = 0; i <= 99; i++)
            {
                var result = await client.GetStreamAsync(secure ? "https://xamarin.com" : "http://httpbin.org/ip");
                result.Dispose();
            }
            return DateTime.Now - start;
        }
    }
}