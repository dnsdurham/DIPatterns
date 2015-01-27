using DIPatterns.Factory.Contracts.Interfaces;
using System.Net;
using System.Text;

namespace DIPatterns.Factory.Engines
{
    class WebPageEngine : IWebPageEngine
    {
        public string GetWebPageContents(string url, bool useProxy = true)
        {
            // using a web client instead of HttpWebRequest
            // TODO: look into modifying the user-agent in the request
            // TODO: look into using HttpClient http://www.nuget.org/packages/Microsoft.Net.Http/

            // request the web page
            using (var client = new WebClient())
            {
                if (useProxy)
                {
                    var proxy = new WebProxy("127.0.0.1:8118");
                    client.Proxy = proxy;
                }
                client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

                // Download data.
                byte[] pageData = client.DownloadData(url);
                // convert to string and remove leading "?"'s
                return Encoding.ASCII.GetString(pageData).TrimStart(new[] { '?' });
            }
        }
    }
}
