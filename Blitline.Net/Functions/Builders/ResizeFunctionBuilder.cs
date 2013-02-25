using System;

namespace Blitline.Net.Functions.Builders
{
    public class ResizeFunctionBuilder : FunctionBuilder<ResizeFunction>
    {
        public ResizeFunctionBuilder WithWidth(int width)
        {
            BuildImp.Width = width;
            return this;
        }

        public ResizeFunctionBuilder WithHeight(int height)
        {
            BuildImp.Height = height;
            return this;
        }

        public ResizeFunctionBuilder WithScaleFactor(decimal scaleFactor)
        {
            BuildImp.ScaleFactor = scaleFactor;
            return this;
        }
    }
}
