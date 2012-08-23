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
        public string src { get; set; }
        public string postback_url { get; set; }
        public ICollection<BlitlineFunction> functions { get; set; }
        
        public BlitlineRequest(string applicationId, string sourceImage)
        {
            ApplicationId = applicationId;
            src = sourceImage;
            functions = new Collection<BlitlineFunction>();
        }

        public void AddFunction(BlitlineFunction function)
        {
            functions.Add(function);
        }
    }
}