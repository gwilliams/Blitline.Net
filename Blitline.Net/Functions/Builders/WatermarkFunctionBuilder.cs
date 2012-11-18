using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class WatermarkFunctionBuilder : FunctionBuilder<WatermarkFunction>
    {
        public WatermarkFunctionBuilder()
        {
            Function = new WatermarkFunction();
        }

        public WatermarkFunctionBuilder WithText(string text)
        {
            ((WatermarkFunction) Function).Text = text;
            return this;
        }

        public WatermarkFunctionBuilder WithGravity(Gravity gravity)
        {
            ((WatermarkFunction) Function).Gravity = gravity;
            return this;
        }

        public WatermarkFunctionBuilder WithPointSize(int pointSize)
        {
            ((WatermarkFunction) Function).PointSize = pointSize;
            return this;
        }

        public WatermarkFunctionBuilder WithFontFamily(string fontFamily)
        {
            ((WatermarkFunction) Function).FontFamily = fontFamily;
            return this;
        }

        public WatermarkFunctionBuilder WithOpacity(decimal opacity)
        {
            ((WatermarkFunction) Function).Opacity = opacity;
            return this;
        }

        protected override WatermarkFunction BuildImp()
        {
            return (WatermarkFunction) Function;
        }
    }
}
