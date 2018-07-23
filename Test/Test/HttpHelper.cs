using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Test
{
    public class HttpHelper
    {
        static HttpClient client = new HttpClient();
        public static async Task<T> GetJsonAsync<T>(string strRequestUrl)
        {
            string temp = "";
            try
            {
                temp = await client.GetStringAsync(strRequestUrl);
                if (temp == null || temp == "")
                    return default(T);
                else
                    return await Json.ToObjectAsync<T>(temp);
            }
            catch { return default(T); }
        }

        public static async Task<BitmapImage> GetWebImageAsync(string url)
        {
            try
            {
                Windows.Web.Http.HttpClient http = new Windows.Web.Http.HttpClient();
                IBuffer buffer = await http.GetBufferAsync(new Uri(url));
                BitmapImage img = new BitmapImage();
                using (IRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await stream.WriteAsync(buffer);
                    stream.Seek(0);
                    await img.SetSourceAsync(stream);
                    return img;
                }
            }
            catch
            {
                return null;
            }
        }

        public static void CancelHttpRequestAsync()
        {
            try
            {
                client.CancelPendingRequests();
            }
            catch { }
        }
    }
}
