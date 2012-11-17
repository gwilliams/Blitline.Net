using System;
using Blitline.Net.Builders;
using Blitline.Net.Request;
using Blitline.Net.Request.Builders;

namespace Blitline.Net.Functions.Builders
{
    public abstract class FunctionBuilder<T> : Builder<T>
        where T : Function
    {
        protected BlitlineFunction Function;

        public FunctionBuilder<T> SaveAs(Func<SaveBuilder, Save> build)
        {
            Function.Save = build(new SaveBuilder());
            return this;
        }
    }
}