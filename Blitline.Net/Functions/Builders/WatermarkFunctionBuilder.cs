using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class WatermarkFunctionBuilder : FunctionBuilder<WatermarkFunction>
    {
        public WatermarkFunctionBuilder WithText(string text)
        {
            BuildImp.Text = text;
            return this;
        }

        public WatermarkFunctionBuilder WithGravity(Gravity gravity)
        {
            BuildImp.Gravity = gravity;
            return this;
        }

        public WatermarkFunctionBuilder WithPointSize(int pointSize)
        {
            BuildImp.PointSize = pointSize;
            return this;
        }

        public WatermarkFunctionBuilder WithFontFamily(string fontFamily)
        {
            BuildImp.FontFamily = fontFamily;
            return this;
        }

        public WatermarkFunctionBuilder WithOpacity(decimal opacity)
        {
            BuildImp.Opacity = opacity;
            return this;
        }
    }
}
