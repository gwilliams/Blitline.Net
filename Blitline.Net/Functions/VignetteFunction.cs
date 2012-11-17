using System;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Gradually shades the edges of the image by transforming the pixels into the background color.
    /// </summary>
    public class VignetteFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "vignette"; }
        }

        public override object Params
        {
            get
            {
                return new
                {
                    color = Colour,
                    x = X,
                    y = Y,
                    threshold = Threshold,
                    sigma = Sigma,
                    radius = Radius
                };
            }
        }

        public string Colour { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public decimal Threshold { get; set; }
        public decimal Sigma { get; set; }
        public decimal Radius { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="threshold"></param>
        /// <param name="sigma"></param>
        /// <param name="radius"></param>
        public VignetteFunction(string colour = "#000000", int x = 10, int y = 10, decimal threshold = 0.05m, decimal sigma = 10.0m, decimal radius = 0.0m)
        {
            if(threshold < 0 || threshold > 1.0m) throw new ArgumentException("threshold cannot be less than 0 and greater than 1.0", "threshold");

            Colour = colour;
            X = x;
            Y = y;
            Threshold = threshold;
            Sigma = sigma;
            Radius = radius;
        }

        protected internal VignetteFunction() {}
    }
}
