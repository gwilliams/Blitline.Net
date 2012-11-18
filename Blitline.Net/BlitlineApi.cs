using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
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
                    response = FixS3Urls(response);
                }

                return response;
            }
        }

        private static BlitlineResponse FixS3Urls(BlitlineResponse response)
        {
            const string pattern = @"[^\/]+$";

            foreach (var image in response.Results.Images)
            {
                var url = image.S3Url;
                var imageName = Regex.Match(url, pattern).Value;
                image.S3Url = imageName;
            }

            return response;
        }
    }
}
