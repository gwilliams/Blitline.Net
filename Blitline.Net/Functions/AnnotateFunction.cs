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

        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Colour { get; set; }
        public string FontFamily { get; set; }
        public int PointSize { get; set; }
        public string Stroke { get; set; }
        public Gravity Gravity { get; set; }

        public override object Params
        {
            get
            {
                return new
                           {
                               text = Text,
                               x = X,
                               y = Y,
                               color = Colour ?? "#ffffff",
                               font_family = FontFamily ?? "Helvetica",
                               point_size = PointSize,
                               stroke = Stroke ?? "transparent",
                               gravity = Gravity
                           };
            }
        }

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
            Text = text;
            X = x;
            Y = y;
            Colour = colour;
            FontFamily = fontFamily;
            PointSize = pointSize;
            Stroke = stroke;
            Gravity = gravity;
        }

        protected internal AnnotateFunction() {}
    }
}
