using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class AnnotateFunctionBuilder : FunctionBuilder<AnnotateFunction>
    {
        public AnnotateFunctionBuilder()
        {
            Function = new AnnotateFunction();
        }

        public AnnotateFunctionBuilder WithText(string text)
        {
            ((AnnotateFunction) Function).Text = text;
            return this;
        }

        public AnnotateFunctionBuilder WithX(int x)
        {
            ((AnnotateFunction) Function).X = x;
            return this;
        }

        public AnnotateFunctionBuilder WithY(int y)
        {
            ((AnnotateFunction) Function).Y = y;
            return this;
        }

        public AnnotateFunctionBuilder WithColour(string colour)
        {
            ((AnnotateFunction)Function).Colour = colour;
            return this;
        }

        public AnnotateFunctionBuilder WithFontFamilty(string fontFamily)
        {
            ((AnnotateFunction) Function).FontFamily = fontFamily;
            return this;
        }

        public AnnotateFunctionBuilder WithPointSize(int pointSize)
        {
            ((AnnotateFunction) Function).PointSize = pointSize;
            return this;
        }

        public AnnotateFunctionBuilder WithStroke(string stroke)
        {
            ((AnnotateFunction) Function).Stroke = stroke;
            return this;
        }

        public AnnotateFunctionBuilder WithGravity(Gravity gravity)
        {
            ((AnnotateFunction) Function).Gravity = gravity;
            return this;
        }

        protected override AnnotateFunction BuildImp()
        {
            return (AnnotateFunction)Function;
        }
    }
}
