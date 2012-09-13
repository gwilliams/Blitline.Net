using System.Collections.Generic;
using System.Collections.ObjectModel;
using Blitline.Net.Functions;
using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public class BlitlineRequest
    {
        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }
        [JsonProperty("src")]
        public string SourceImage { get; set; }
        [JsonProperty("postback_url")]
        public string PostbackUrl { get; set; }
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