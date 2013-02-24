using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class CompositeFunctionBuilder : FunctionBuilder<CompositeFunction>
    {
        public CompositeFunctionBuilder WithSource(string source)
        {
            BuildImp.Source = source;
            return this;
        }

        public CompositeFunctionBuilder AsMask(bool asMask)
        {
            BuildImp.AsMask = asMask;
            return this;
        }

        public CompositeFunctionBuilder WithPosition(int x, int y)
        {
            BuildImp.X = x;
            BuildImp.Y = y;
            return this;
        }

        public CompositeFunctionBuilder WithCompositeOp(CompositeOps compositeOps)
        {
            BuildImp.CompositeOp = compositeOps;
            return this;
        }
    }
}
