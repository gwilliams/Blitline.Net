using System;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Draws an ellipse
    /// </summary>
    public class EllipseFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "ellipse"; }
        }

        public override dynamic Params
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Center X coordinate
        /// </summary>
        public int OriginX { get; set; }

        /// <summary>
        /// Center Y coordinate
        /// </summary>
        public int OriginY { get; set; }

        /// <summary>
        /// Width of ellipse
        /// </summary>
        public int EllipseWidth { get; set; }

        /// <summary>
        /// Height of ellipse
        /// </summary>
        public int EllipseHeight { get; set; }

        /// <summary>
        /// Color of stroke (default "#ffffff")
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Width of ellipse perimeter(stroke) line (default 0, no stroke)
        /// </summary>
        public int StrokeWidth { get; set; }
        
        /// <summary>
        /// Opacity of stroke (default 1.0)
        /// </summary>
        public decimal StrokeOpacity { get; set; }

        /// <summary>
        /// Color to fill the ellipse with (defaults to 'color' value)
        /// </summary>
        public string FillColor { get; set; }

        /// <summary>
        /// Opacity of fill (defaults to 1.0)
        /// </summary>
        public decimal FillOpacity { get; set; }

        public EllipseFunction()
        {
            Color = "#FFFFFF";
            StrokeWidth = 0;
            StrokeOpacity = 1.0m;
            FillColor = Color;
            FillOpacity = 1.0m;
        }

        public override void Validate()
        {
            if(OriginX <= 0) throw new ArgumentException("OriginX required");
            if(OriginY <= 0) throw new ArgumentException("OriginY required");
            if (EllipseWidth <= 0) throw new ArgumentException("EllipseWidth required");
            if (EllipseHeight <= 0) throw new ArgumentException("EllipseHeight required");
        }
    }
}