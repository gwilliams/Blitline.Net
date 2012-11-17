using Blitline.Net.Request;
using Newtonsoft.Json;

namespace Blitline.Net.Functions
{
    public abstract class BlitlineFunction : Function
    {
        [JsonProperty("name")]
        public abstract string Name { get; }
        [JsonProperty("params")]
        public abstract object @Params { get; protected set; }
        [JsonProperty("save")]
        public Save Save { get; set; }
        
        public void AddFunction(BlitlineFunction function)
        {
            Functions.Add(function);
        }
    }
}