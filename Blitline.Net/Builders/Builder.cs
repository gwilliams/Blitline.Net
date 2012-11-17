using System;
using System.Collections.Generic;
using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;
using Blitline.Net.Request;

namespace Blitline.Net.Builders
{
    public abstract class Builder<T> : UberBuilder<T> where T : Function
    {
        protected List<BlitlineFunction> Functions { get; set; }

        protected Builder()
        {
            Functions = new List<BlitlineFunction>();
        }
        
        public override T Build()
        {
            var o = BuildImp();
            o.Functions.AddRange(Functions);
            return o;
        }

        public Builder<T> WithCropFunction(Func<CropFunctionBuilder, CropFunction> build)
        {
            Functions.Add(build(new CropFunctionBuilder()));
            return this;
        }

    }
}