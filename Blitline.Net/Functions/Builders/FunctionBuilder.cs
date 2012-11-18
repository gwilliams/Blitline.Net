using System;
using Blitline.Net.Builders;
using Blitline.Net.Request;
using Blitline.Net.Request.Builders;

namespace Blitline.Net.Functions.Builders
{
    public abstract class FunctionBuilder<T> : Builder<T>
        where T : BlitlineFunction
    {
        protected BlitlineFunction Function;

        public FunctionBuilder<T> SaveAs(Func<SaveBuilder, Save> build)
        {
            Function.Save = build(new SaveBuilder());
            return this;
        }

        public override T Build()
        {
            var o = base.Build();
            o.Validate();
            return o;
        }
    }
}