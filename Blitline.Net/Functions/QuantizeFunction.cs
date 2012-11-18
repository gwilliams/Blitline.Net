namespace Blitline.Net.Functions
{
    /// <summary>
    /// Analyzes the colors within a reference image and chooses a fixed number of colors to represent the image
    /// </summary>
    public class QuantizeFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "quantize"; }
        }

        public override object Params
        {
            get
            {
                return new
                {
                    number_colors = NumberOfColours,
                    color_space = ColourSpace,
                    dither = Dither
                };
            }
        }

        public override void Validate() {}

        public int NumberOfColours { get; set; }
        public string ColourSpace { get; set; }
        public bool Dither { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfColours">Number of colors to reduce to</param>
        /// <param name="colourSpace">The colorspace to quantize in (defaults to "RGBColorspace")</param>
        /// <param name="dither">Whether or not to use dithering on the resulting image (defaults to "false")</param>
        public QuantizeFunction(int numberOfColours, string colourSpace = "RGBColorspace", bool dither = false)
        {
            NumberOfColours = numberOfColours;
            ColourSpace = colourSpace;
            Dither = dither;
        }

        protected internal QuantizeFunction()
        {
            ColourSpace = "RGBColorspace";
        }
    }
}
