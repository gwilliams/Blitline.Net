using System.Collections.Generic;
using Newtonsoft.Json;

namespace Blitline.Net.Response
{
    public class Results
    {
        [JsonProperty("images")]
        public IList<Image> Images { get; set; } 
        [JsonProperty("job_id")]
        public string JobId { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}