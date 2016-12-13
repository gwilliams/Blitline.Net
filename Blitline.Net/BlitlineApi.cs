using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Blitline.Net
{
    public class BlitlineApi : IBlitlineApi
    {
        const string RootUrl = "://api.blitline.com/job";
        
        public BlitlineResponse ProcessImages(BlitlineRequest blitlineRequest)
        {
            return ProcessImagesAsync(blitlineRequest).Result;
        }

        public BlitlineBatchResponse ProcessImages(IEnumerable<BlitlineRequest> blitlineRequests)
        {
            return ProcessImagesAsync(blitlineRequests).Result;
        }

        public async Task<BlitlineResponse> ProcessImagesAsync(BlitlineRequest blitlineRequest)
        {
            var r = await ProcessImagesAsync(new[] {blitlineRequest});
            return new BlitlineResponse
                {
                    Results = r.Results.First()
                };
        }

        public async Task<BlitlineBatchResponse> ProcessImagesAsync(IEnumerable<BlitlineRequest> blitlineRequests)
        {
            var requests = blitlineRequests.ToList();
            var payload = JsonConvert.SerializeObject(requests.ToArray());

            var correctS3BucketList = FixS3Urls(requests);

            var urlPrefix = requests.Any(x => x.UseHttps) ? "https" : "http";
            var url = string.Format("{0}{1}", urlPrefix, RootUrl);
            var postResult = await (new HttpClient()).PostAsync(url, new FormUrlEncodedContent(new Dictionary<string, string> { { "json", payload } }));

            var o = await postResult.Content.ReadAsStringAsync();

            var response = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<BlitlineBatchResponse>(o));

            if (correctS3BucketList.Any()) response.FixS3Urls(correctS3BucketList);

            return response;
        }

        private Dictionary<string, string> FixS3Urls(IEnumerable<BlitlineRequest> blitlineRequests)
        {
            var imageKeyBucketList = new Dictionary<string, string>();

            if (blitlineRequests.Any(r => r.FixS3ImageUrl))
            {
                imageKeyBucketList = blitlineRequests.SelectMany(f => f.Functions).Select(f =>
                {
                    if (f.Save != null && f.Save.S3Destination != null)
                    {
                        return new { Image = f.Save.S3Destination.Key, f.Save.S3Destination.Bucket };
                    }
                    return null;
                }).ToDictionary(k => k.Image, v => v.Bucket);
            }

            return imageKeyBucketList;
        }
    }
}
