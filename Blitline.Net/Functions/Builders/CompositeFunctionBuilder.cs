using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class CompositeFunctionBuilder : FunctionBuilder<CompositeFunction>
    {
        public CompositeFunctionBuilder()
        {
            Function = new CompositeFunction();
        }

        public CompositeFunctionBuilder WithSource(string source)
        {
            ((CompositeFunction) Function).Source = source;
            return this;
        }

        public CompositeFunctionBuilder AsMask(bool asMask)
        {
            ((CompositeFunction) Function).AsMask = asMask;
            return this;
        }

        public CompositeFunctionBuilder WithPosition(int x, int y)
        {
            ((CompositeFunction) Function).X = x;
            ((CompositeFunction) Function).Y = y;
            return this;
        }

        public CompositeFunctionBuilder WithCompositeOp(CompositeOps compositeOps)
        {
            ((CompositeFunction) Function).CompositeOp = compositeOps;
            return this;
        }

        protected override CompositeFunction BuildImp()
        {
            return (CompositeFunction)Function;
        }
    }
}
