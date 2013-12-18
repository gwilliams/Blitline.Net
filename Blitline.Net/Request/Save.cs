using System;
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
        [JsonProperty("azure_destination")]
        public AzureDestination AzureDestination { get; set; }
        [JsonProperty("ftp_destination")]
        public FtpDestination FtpDestination { get; set; }
        [JsonProperty("extension")]
        [JsonConverter(typeof(ExtensionConverter))]
        public Extension Extension { get; set; }
        [JsonProperty("interlace")]
        public string Interlace { get; set; }
        [JsonProperty("png_quantize")]
        public bool PngQuantize { get; set; }

        public Save()
        {
            Quality = 75;
        }

        public void Validate()
        {
            if(string.IsNullOrEmpty(ImageIdentifier)) throw new ArgumentNullException("ImageIdentifier", "Image identifier is required");

            if(GetCurrentSaveDestinationCounts() > 1) throw new NotSupportedException("Only one save destination is currently supported");

        }

        private int GetCurrentSaveDestinationCounts()
        {
            var count = 0;

            if (S3Destination != null) count++;
            if (AzureDestination != null) count++;
            if (FtpDestination != null) count++;

            return count;
        }
    }
}