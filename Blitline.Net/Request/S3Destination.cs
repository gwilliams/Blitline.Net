using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public class S3Destination
    {
        [JsonProperty("bucket")]
        public string Bucket { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}