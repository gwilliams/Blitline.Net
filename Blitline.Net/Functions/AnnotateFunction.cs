using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Adds text to an image
    /// </summary>
    public class AnnotateFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "annotate"; }
        }

        public override object Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Text to display on image</param>
        /// <param name="x">X offset (defaults to 0)</param>
        /// <param name="y">Y offset (defaults to 0)</param>
        /// <param name="colour">Color of text (defaults to '#ffffff')</param>
        /// <param name="fontFamily">Font of text (defaults to 'Helvetica')</param>
        /// <param name="pointSize">Size of text (defaults to 32)</param>
        /// <param name="stroke">Color of stroke (defaults to 'transparent')</param>
        /// <param name="gravity">Placement of text (defaults to 'CenterGravity')</param>
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
