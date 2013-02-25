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

        public override void Validate()
        {
            if (Threshold < 0 || Threshold > 1.0m) throw new ArgumentException("Threshold cannot be less than 0 and greater than 1.0", "Threshold");
        }

        public string Colour { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public decimal Threshold { get; set; }
        public decimal Sigma { get; set; }
        public decimal Radius { get; set; }

	    public VignetteFunction()
        {
            Colour = "#000000";
            X = 10;
            Y = 10;
            Threshold = 0.05m;
            Sigma = 10m;
        }
    }
}
