using System.Collections.Generic;
using System.Collections.ObjectModel;
using Blitline.Net.Request;

namespace Blitline.Net.Functions
{
    public abstract class BlitlineFunction
    {
        public abstract string name { get; }
        public abstract object @params { get; set; }
        public Save save { get; set; }
        public ICollection<BlitlineFunction> functions { get; set; }

        protected BlitlineFunction()
        {
            functions = new Collection<BlitlineFunction>();
        }

        public void AddFunction(BlitlineFunction function)
        {
            functions.Add(function);
        }
    }
}