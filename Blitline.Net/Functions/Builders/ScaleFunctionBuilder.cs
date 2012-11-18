using System;

namespace Blitline.Net.Functions.Builders
{
    public class ScaleFunctionBuilder : FunctionBuilder<ScaleFunction>
    {
        public ScaleFunctionBuilder()
        {
            Function = new ScaleFunction();
        }

        public ScaleFunctionBuilder WithWidth(int width)
        {
            ((ScaleFunction) Function).Width = width;
            return this;
        }

        public ScaleFunctionBuilder WithHeight(int height)
        {
            ((ScaleFunction) Function).Height = height;
            return this;
        }

        public ScaleFunctionBuilder WithScaleFactor(decimal scaleFactor)
        {
            ((ScaleFunction) Function).ScaleFactor = scaleFactor;
            return this;
        }

        protected override ScaleFunction BuildImp()
        {
            return (ScaleFunction) Function;
        }
    }
}
