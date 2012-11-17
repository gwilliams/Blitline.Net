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

        public Builder<T> WithAnnotateFunction(Func<AnnotateFunctionBuilder, AnnotateFunction> build)
        {
            Functions.Add(build(new AnnotateFunctionBuilder()));
            return this;
        }

        public Builder<T> WithAppendFunction(Func<AppendFunctionBuilder, AppendFunction> build)
        {
            Functions.Add(build(new AppendFunctionBuilder()));
            return this;
        }

        public Builder<T> WithBlurFunction(Func<BlurFunctionBuilder, BlurFunction> build)
        {
            Functions.Add(build(new BlurFunctionBuilder()));
            return this;
        }

        public Builder<T> WithCompositeFunction(Func<CompositeFunctionBuilder, CompositeFunction> build)
        {
            Functions.Add(build(new CompositeFunctionBuilder()));
            return this;
        }

        public Builder<T> WithCropFunction(Func<CropFunctionBuilder, CropFunction> build)
        {
            Functions.Add(build(new CropFunctionBuilder()));
            return this;
        }

    }
}