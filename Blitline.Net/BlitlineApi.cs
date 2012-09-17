using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Newtonsoft.Json;

namespace Blitline.Net
{
    public class BlitlineApi : IBlitlineApi
    {
        readonly HttpClient _client;
        const string RootUrl = "http://api.blitline.com/job";

        public BlitlineApi(HttpClient client)
        {
            _client = client;
        }

        public BlitlineResponse ProcessImages(BlitlineRequest blitlineRequest)
        {
            var payload = JsonConvert.SerializeObject(blitlineRequest);
            var req = string.Format("'json':'{0}'", payload);

            using(var client = new HttpClient())
            {
                var result = client.PostAsync(RootUrl, new StringContent(req));
                var o = result.Result.Content.ReadAsStringAsync().Result;
            }

            return null;
        }
    }
}
