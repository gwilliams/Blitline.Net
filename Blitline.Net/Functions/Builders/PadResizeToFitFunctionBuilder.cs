using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class PadResizeToFitFunctionBuilder : FunctionBuilder<PadResizeToFitFunction>
    {
        public PadResizeToFitFunctionBuilder WithWidth(int width)
        {
            BuildImp.Width = width;
            return this;
        }

        public PadResizeToFitFunctionBuilder WithHeight(int height)
        {
            BuildImp.Height = height;
            return this;
        }

        public PadResizeToFitFunctionBuilder WithColour(string colour)
        {
            BuildImp.Colour = colour;
            return this;
        }

        public PadResizeToFitFunctionBuilder WithGravity(Gravity gravity)
        {
            BuildImp.Gravity = gravity;
            return this;
        }
    }
}
