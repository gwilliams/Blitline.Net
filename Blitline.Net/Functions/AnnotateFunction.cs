using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    public class AnnotateFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "annotate"; }
        }

        public override object Params { get; protected set; }

        public AnnotateFunction(string text, int x = 0, int y = 0, string colour = "#ffffff", string fontFamily = "Helvetica", int pointSize = 32, string stroke = "transparent", Gravity gravity = Gravity.CenterGrativty)
        {
            @Params = new
                {
                    text,
                    x,
                    y,
                    color = colour,
                    font_family = fontFamily,
                    point_size = pointSize,
                    stroke,
                    gravity
                };
        }
    }
}
