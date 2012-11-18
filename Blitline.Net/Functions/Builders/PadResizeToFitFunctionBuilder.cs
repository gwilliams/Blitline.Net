using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class PadResizeToFitFunctionBuilder : FunctionBuilder<PadResizeToFitFunction>
    {
        public PadResizeToFitFunctionBuilder()
        {
            Function = new PadResizeToFitFunction();    
        }

        public PadResizeToFitFunctionBuilder WithWidth(int width)
        {
            ((PadResizeToFitFunction) Function).Width = width;
            return this;
        }

        public PadResizeToFitFunctionBuilder WithHeight(int height)
        {
            ((PadResizeToFitFunction) Function).Height = height;
            return this;
        }

        public PadResizeToFitFunctionBuilder WithColour(string colour)
        {
            ((PadResizeToFitFunction) Function).Colour = colour;
            return this;
        }

        public PadResizeToFitFunctionBuilder WithGravity(Gravity gravity)
        {
            ((PadResizeToFitFunction) Function).Gravity = gravity;
            return this;
        }

        protected override PadResizeToFitFunction BuildImp()
        {
            return (PadResizeToFitFunction) Function;
        }
    }
}
