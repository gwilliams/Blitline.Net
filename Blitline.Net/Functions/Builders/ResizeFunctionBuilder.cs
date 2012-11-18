namespace Blitline.Net.Functions.Builders
{
    public class ResizeFunctionBuilder : FunctionBuilder<ResizeFunction>
    {
        public ResizeFunctionBuilder()
        {
            Function = new ResizeFunction();    
        }

        public ResizeFunctionBuilder WithWidth(int width)
        {
            ((ResizeFunction) Function).Width = width;
            return this;
        }

        public ResizeFunctionBuilder WithHeight(int height)
        {
            ((ResizeFunction) Function).Height = height;
            return this;
        }

        public ResizeFunctionBuilder WithScaleFactor(decimal scaleFactor)
        {
            ((ResizeFunction) Function).ScaleFactor = scaleFactor;
            return this;
        }

        protected override ResizeFunction BuildImp()
        {
            return (ResizeFunction) Function;
        }
    }
}
