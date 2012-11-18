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

                if (blitlineRequest.FixS3ImageUrl)
                {
                    var imageKeyBucketList = blitlineRequest.Functions.Select(f =>
                        {
                            if (f.Save != null && f.Save.S3Destination != null)
                            {
                                return new {Image = f.Save.S3Destination.Key, f.Save.S3Destination.Bucket};
                            }
                            return null;
                        }).ToDictionary(k => k.Image, v => v.Bucket);

                    response.FixS3Urls(imageKeyBucketList);
                }

                return response;
            }
        }
    }
}
