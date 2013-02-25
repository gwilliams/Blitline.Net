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

        public int NumberOfColours { get; set; }
        public string ColourSpace { get; set; }
        public bool Dither { get; set; }

	    public QuantizeFunction()
        {
            ColourSpace = "RGBColorspace";
        }
    }
}
