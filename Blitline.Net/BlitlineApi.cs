using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Newtonsoft.Json;

namespace Blitline.Net
{
    public class BlitlineApi : IBlitlineApi
    {
        const string RootUrl = "http://api.blitline.com/job";
        
        public BlitlineResponse ProcessImages(BlitlineRequest blitlineRequest)
        {
            var payload = JsonConvert.SerializeObject(blitlineRequest);
            
            using (var client = new HttpClient())
            {
                var result = client.PostAsync(RootUrl, new FormUrlEncodedContent(new Dictionary<string, string>{{"json", payload}}));
                var o = result.Result.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<BlitlineResponse>(o);

                var correctS3BucketList = FixS3Urls(new[]{blitlineRequest});
                if (correctS3BucketList.Any()) response.FixS3Urls(correctS3BucketList);

                return response;
            }
        }

        public BlitlineBatchResponse ProcessImages(IEnumerable<BlitlineRequest> blitlineRequests)
        {
            var payload = JsonConvert.SerializeObject(blitlineRequests.ToArray());

            using (var client = new HttpClient())
            {
                var result = client.PostAsync(RootUrl, new FormUrlEncodedContent(new Dictionary<string, string> { { "json", payload } }));
                var o = result.Result.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<BlitlineBatchResponse>(o);

                var correctS3BucketList = FixS3Urls(blitlineRequests);
                if(correctS3BucketList.Any()) response.FixS3Urls(correctS3BucketList);
                
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
