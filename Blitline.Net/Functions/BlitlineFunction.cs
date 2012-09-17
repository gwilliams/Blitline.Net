using System.Collections.Generic;
using System.Collections.ObjectModel;
using Blitline.Net.Request;
using Newtonsoft.Json;

namespace Blitline.Net.Functions
{
    public abstract class BlitlineFunction
    {
        [JsonProperty("name")]
        public abstract string Name { get; }
        [JsonProperty("params")]
        public abstract object @Params { get; protected set; }
        [JsonProperty("save")]
        public Save Save { get; set; }
        [JsonProperty("functions")]
        public ICollection<BlitlineFunction> Functions { get; set; }

        protected BlitlineFunction()
        {
            Functions = new Collection<BlitlineFunction>();
        }

        public void AddFunction(BlitlineFunction function)
        {
            Functions.Add(function);
        }
    }
}