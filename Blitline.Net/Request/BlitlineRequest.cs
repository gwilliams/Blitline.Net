using System.Collections.Generic;
using System.Collections.ObjectModel;
using Blitline.Net.Functions;
using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public enum Hash
    {
        [JsonProperty("md5")]
        Md5,
        [JsonProperty("crc32")]
        Crc32,
        [JsonProperty("sha256")]
        Sha256
    }

    public class Function
    {
        [JsonProperty("functions")]
        public List<BlitlineFunction> Functions { get; set; }

        public Function()
        {
            Functions = new List<BlitlineFunction>();
        }
    }

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
    }
}