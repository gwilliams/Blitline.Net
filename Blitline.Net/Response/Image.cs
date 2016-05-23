using Newtonsoft.Json;

namespace Blitline.Net.Response
{
    public class Image
    {
        [JsonProperty("image_identifier")]
        public string ImageIdentifier { get; set; }
        [JsonProperty("s3_url")]
        public string S3Url { get; set; }
		[JsonProperty ("azure_url")]
		public string AzureUrl { get; set; }
    }
}