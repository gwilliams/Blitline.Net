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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sigma">Gaussian sigma of sharpen (defaults to 1.0)</param>
        /// <param name="radius">Gaussian radius of shapen (defaults to 0.0)</param>
        public SharpenFunction(decimal sigma = 1.0m, decimal radius = 0.0m)
        {
            Sigma = sigma;
            Radius = radius;
        }

        protected internal SharpenFunction()
        {
            Sigma = 1.0m;
        }
    }
}
