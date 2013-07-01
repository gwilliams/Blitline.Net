using System;
using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public class AzureDestination
    {
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("shared_access_signature")]
        public string SharedAccessSignature { get; set; }

        public void Validate()
        {
            if(string.IsNullOrEmpty(AccountName)) throw new ArgumentNullException("AccountName", "AccountName is required");
            if (string.IsNullOrEmpty(SharedAccessSignature)) throw new ArgumentNullException("SharedAccessSignature", "SharedAccessSignature is required");
        }
    }
}