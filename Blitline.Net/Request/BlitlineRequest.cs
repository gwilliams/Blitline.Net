using System.Collections.Generic;
using System.Collections.ObjectModel;
using Blitline.Net.Functions;
using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public enum Hash
    {
        md5,
        crc32,
        sha256
    }

    public enum SourceType
    {
        Screenshot,
        Multipage
    }

    public class BlitlineRequest
    {
        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }
        [JsonProperty("hash")]
        public Hash? Hash { get; set; }
        [JsonProperty("suppress_auto_orient")]
        public bool SuppressAutoOrient { get; set; }
        [JsonProperty("src_type")]
        public SourceType? SourceType { get; set; }
        [JsonProperty("src")]
        public string SourceImage { get; set; }
        [JsonProperty("postback_url")]
        public string PostbackUrl { get; set; }
        [JsonProperty("wait_for_s3")]
        public bool WaitForS3 { get; set; }
        [JsonProperty("functions")]
        public ICollection<BlitlineFunction> Functions { get; set; }
        
        public BlitlineRequest(string applicationId, string sourceImage)
        {
            ApplicationId = applicationId;
            SourceImage = sourceImage;
            Functions = new Collection<BlitlineFunction>();
        }

        public void AddFunction(BlitlineFunction function)
        {
            Functions.Add(function);
        }
    }
}