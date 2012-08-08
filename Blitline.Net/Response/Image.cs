using Newtonsoft.Json;

namespace Blitline.Net
{
    public class Image
    {
        [JsonProperty("image_identifier")]
        public string ImageIdentifier { get; set; }
        [JsonProperty("s3_url")]
        public string S3Url { get; set; }
    }
}