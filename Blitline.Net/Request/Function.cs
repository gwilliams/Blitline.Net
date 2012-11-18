using System.Collections.Generic;
using Blitline.Net.Functions;
using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public class Function
    {
        [JsonProperty("functions")]
        public List<BlitlineFunction> Functions { get; set; }

        public Function()
        {
            Functions = new List<BlitlineFunction>();
        }
    }
}