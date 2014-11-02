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
        const string RootUrl = "http://api.blitline.com/job";
        
        public BlitlineResponse ProcessImages(BlitlineRequest blitlineRequest)
        {
            return ProcessImagesAsync(new[]{blitlineRequest}).Result;
        }

        public BlitlineBatchResponse ProcessImages(IEnumerable<BlitlineRequest> blitlineRequests)
        {
            return ProcessImagesAsync(blitlineRequests).Result;
        }

        public async Task<BlitlineResponse> ProcessImagesAsync(BlitlineRequest blitlineRequest)
        {
            var r = await ProcessImagesAsync(new[] {blitlineRequest});
            return (BlitlineResponse) r;
        }

        public async Task<BlitlineBatchResponse> ProcessImagesAsync(IEnumerable<BlitlineRequest> blitlineRequests)
        {
            var payload = JsonConvert.SerializeObject(blitlineRequests.ToArray());

            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.PostAsync(RootUrl, new FormUrlEncodedContent(new Dictionary<string, string> { { "json", payload } }));
                var o = result.Content.ReadAsStringAsync().Result;

                var response = await JsonConvert.DeserializeObjectAsync<BlitlineBatchResponse>(o);

                var correctS3BucketList = FixS3Urls(blitlineRequests);
                if (correctS3BucketList.Any()) response.FixS3Urls(correctS3BucketList);

                return response;    
            }
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
