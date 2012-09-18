using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    public class WatermarkFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "watermark"; }
        }

        public override object Params { get; protected set; }

        public WatermarkFunction(string text, Gravity gravity = Gravity.CenterGrativty, int pointSize = 94, string fontFamilty = "Helvetica", decimal opacity = 0.45m)
        {
            @Params = new
                {
                    text,
                    gravity,
                    point_size = pointSize,
                    font_family = fontFamilty,
                    opacity
                };
        }
    }
}
