using System.Collections.Generic;

namespace Blitline.Net.Functions
{
    public abstract class BlitlineFunction
    {
        public abstract string name { get; }
        public abstract object @params { get; set; }
        public Save save { get; set; }
        public ICollection<BlitlineFunction> functions { get; set; }

        public void AddFunction(BlitlineFunction function)
        {
            functions.Add(function);
        }
    }
}