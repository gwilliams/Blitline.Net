using System.Collections.Generic;
using Blitline.Net.Response;
using System.Threading.Tasks;

namespace Blitline.Net.Request
{
    public static class BlitlineRequestExtensions
    {
        public static BlitlineResponse Send(this BlitlineRequest request)
        {
            return request.SendAsync().Result;
        }

        public static BlitlineBatchResponse Send(this IEnumerable<BlitlineRequest> requests)
        {
            return requests.SendAsync().Result;
        }

        public static Task<BlitlineResponse> SendAsync(this BlitlineRequest request)
        {
            var api = new BlitlineApi();
            var response = api.ProcessImagesAsync(request);
            return response;
        }
        
        public static async Task<BlitlineBatchResponse> SendAsync(this IEnumerable<BlitlineRequest> requests)
        {
            var api = new BlitlineApi();
            var response = await api.ProcessImagesAsync(requests);
            return response;
        }
    }
}