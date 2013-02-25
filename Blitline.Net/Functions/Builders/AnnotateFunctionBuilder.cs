using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class AnnotateFunctionBuilder : FunctionBuilder<AnnotateFunction>
    {
        public AnnotateFunctionBuilder WithText(string text)
        {
            BuildImp.Text = text;
            return this;
        }
        
        public AnnotateFunctionBuilder WithPosition(int x, int y)
        {
            BuildImp.X = x;
            BuildImp.Y = y;
            return this;
        }

        public AnnotateFunctionBuilder WithColour(string colour)
        {
            BuildImp.Colour = colour;
            return this;
        }

        public AnnotateFunctionBuilder WithFontFamilty(string fontFamily)
        {
            BuildImp.FontFamily = fontFamily;
            return this;
        }

        public AnnotateFunctionBuilder WithPointSize(int pointSize)
        {
            BuildImp.PointSize = pointSize;
            return this;
        }

        public AnnotateFunctionBuilder WithStroke(string stroke)
        {
            BuildImp.Stroke = stroke;
            return this;
        }

        public AnnotateFunctionBuilder WithGravity(Gravity gravity)
        {
            BuildImp.Gravity = gravity;
            return this;
        }
    }
}
