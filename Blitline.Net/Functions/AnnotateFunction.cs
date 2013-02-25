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

        /// <summary>
        /// Text to display on image
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// X offset (defaults to 0)
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y offset (defaults to 0)
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Colour of text (defaults to '#ffffff')
        /// </summary>
        public string Colour { get; set; }

        /// <summary>
        /// Font of text (defaults to 'Helvetica')
        /// </summary>
        public string FontFamily { get; set; }

        /// <summary>
        /// Size of text (defaults to 32)
        /// </summary>
        public int PointSize { get; set; }

        /// <summary>
        /// Color of stroke (defaults to 'transparent')
        /// </summary>
        public string Stroke { get; set; }

        /// <summary>
        /// Placement of text (defaults to 'CenterGravity')
        /// </summary>
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
                               gravity = Gravity.ToString()
                           };
            }
        }

	    public AnnotateFunction()
        {
            Colour = "#ffffff";
            FontFamily = "Helvetica";
            PointSize = 32;
            Stroke = "transparent";
            Gravity = Gravity.CenterGrativty;
        }
    }
}
