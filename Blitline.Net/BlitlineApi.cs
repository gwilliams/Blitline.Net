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
            var uri = new Uri(RootUrl);

            var request = new HttpRequestMessage(HttpMethod.Post, uri)
                {
                    //Content = new StringContent(JsonConvert.SerializeObject(payload))
                };
            
//            var result = _client.SendAsync(request);
            var result = _client.PostAsync(RootUrl, new StringContent(JsonConvert.SerializeObject("\"json\":\"" + JsonConvert.SerializeObject(blitlineRequest) + "\"")));

            return JsonConvert.DeserializeObject<BlitlineResponse>(result.Result.Content.ReadAsStringAsync().Result);
        }
    }
}
