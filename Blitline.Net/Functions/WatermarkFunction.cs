using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    public class WatermarkFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "watermark"; }
        }

        public override object Params
        {
            get
            {
                return new
                {
                    text = Text,
                    gravity = Gravity,
                    point_size = PointSize,
                    font_family = FontFamily,
                    opacity = Opacity
                };
            }
        }

        public string Text { get; set; }
        public Gravity Gravity { get; set; }
        public int PointSize { get; set; }
        public string FontFamily { get; set; }
        public decimal Opacity { get; set; }
    

        public WatermarkFunction(string text, Gravity gravity = Gravity.CenterGrativty, int pointSize = 94, string fontFamilty = "Helvetica", decimal opacity = 0.45m)
        {
            Text = text;
            Gravity = gravity;
            PointSize = pointSize;
            FontFamily = fontFamilty;
            Opacity = opacity;
        }
    }
}
