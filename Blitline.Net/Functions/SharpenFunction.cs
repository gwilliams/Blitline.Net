namespace Blitline.Net.Functions
{
    /// <summary>
    /// Sharpens the image
    /// </summary>
    public class SharpenFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "sharpen"; }
        }

        public override object Params
        {
            get
            {
                return new
                {
                    sigma = Sigma,
                    radius = Radius
                };
            }
        }

        /// <summary>
        /// Gaussian sigma of sharpen (defaults to 1.0)
        /// </summary>
        public decimal Sigma { get; set; }

        /// <summary>
        /// Gaussian radius of shapen (defaults to 0.0)
        /// </summary>
        public decimal Radius { get; set; }

	    public SharpenFunction()
        {
            Sigma = 1.0m;
        }
    }
}
