using System.Collections.Generic;
using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public class MultiPageSourceType
    {
        [JsonProperty("name")]
        public string Name { get { return "multi_page"; } }
        [JsonProperty("pages")]
        public IList<int> Pages { get; set; }
    }
}