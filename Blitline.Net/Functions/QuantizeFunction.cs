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

        public override object Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfColours">Number of colors to reduce to</param>
        /// <param name="colourSpace">The colorspace to quantize in (defaults to "RGBColorspace")</param>
        /// <param name="dither">Whether or not to use dithering on the resulting image (defaults to "false")</param>
        public QuantizeFunction(int numberOfColours, string colourSpace = "RGBColorspace", bool dither = false)
        {
            @Params = new
                {
                    number_colors = numberOfColours,
                    color_space = colourSpace,
                    dither
                };
        }
    }
}
