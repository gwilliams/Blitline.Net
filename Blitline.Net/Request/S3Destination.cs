using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Blitline.Net.Request
{
    public class S3Destination
    {
        [JsonProperty("bucket")]
        public string Bucket { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        //[JsonProperty("headers")]
        //public ICollection<KeyValuePair<string,string>> Headers { get; protected set; }

        //public void AddHeader(string key, string value)
        //{
        //    if(Headers == null) Headers = new Collection<KeyValuePair<string, string>>();

        //    Headers.Add(new KeyValuePair<string, string>(key, value));
        //}
    }
}