using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public class Save
    {
        [JsonProperty("image_identifier")]
        public string ImageIdentifier { get; set; }
        [JsonProperty("quality")]
        public int Quality { get; set; }
        [JsonProperty("s3_destination")]
        public S3Destination S3Destination { get; set; }

        public Save()
        {
            Quality = 75;
        }
    }
}