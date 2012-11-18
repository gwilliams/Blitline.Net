using Blitline.Net.Functions;
using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public class BlitlineRequest : Function
    {
        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }
        [JsonProperty("hash")]
        public Hash? Hash { get; set; }
        [JsonProperty("suppress_auto_orient")]
        public bool SuppressAutoOrient { get; set; }
        [JsonProperty("src")]
        public string SourceImage { get; set; }
        [JsonProperty("postback_url")]
        public string PostbackUrl { get; set; }
        [JsonProperty("wait_for_s3")]
        public bool WaitForS3 { get; set; }
        
        public void AddFunction(BlitlineFunction function)
        {
            Functions.Add(function);
        }

        public BlitlineRequest()
        {
            
        }

        public BlitlineRequest(string applicationId, string sourceUrl)
        {
            ApplicationId = applicationId;
            SourceImage = sourceUrl;
        }
    }
}