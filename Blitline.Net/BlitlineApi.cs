using System;
using System.Threading.Tasks;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Newtonsoft.Json;
using RestSharp;

namespace Blitline.Net
{
    public class BlitlineApi : IBlitlineApi
    {
        readonly IRestClient _client;
        const string RootUrl = "http://api.blitline.com/job";

        public BlitlineApi(IRestClient client)
        {
            _client = client;
        }

        public BlitlineResponse ProcessImages(BlitlineRequest blitlineRequest)
        {
            _client.BaseUrl = RootUrl;

            var request = new RestRequest(Method.POST) {RequestFormat = DataFormat.Json};
            var payload = new
                              {
                                  json = blitlineRequest
                              };
            
            request.AddBody(payload);

            var response = _client.Execute(request);//Async(request, restResponse => {});


            //return Task.Factory.FromAsync<BlitlineResponse>(_client.ExecuteAsync(request, r => { }), callback)
            
            //_client.ExecuteAsync(request, r => callback(JsonConvert.DeserializeObject<BlitlineResponse>(r.Content)));
            

            return JsonConvert.DeserializeObject<BlitlineResponse>(response.Content);
        }
    }
}
