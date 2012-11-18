namespace Blitline.Net.Functions
{
    /// <summary>
    /// Blurs an image
    /// </summary>
    public class BlurFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "blur"; }
        }

        public override object @Params { get { return new {sigma = Sigma, radius = Radius}; } }
        
        public override void Validate() {}

        /// <summary>
        /// Gaussian sigma of blur (defaults to 1.0)
        /// </summary>
        public decimal Sigma { get; set; }

        /// <summary>
        /// Gaussian radius of blur (defaults to 0.0)
        /// </summary>
        public decimal Radius { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sigma">Gaussian sigma of blur (defaults to 1.0)</param>
        /// <param name="radius">Gaussian radius of blur (defaults to 0.0)</param>
        public BlurFunction(decimal sigma, decimal radius)
        {
            Sigma = sigma;
            Radius = radius;
        }

        protected internal BlurFunction()
        {
            Sigma = 1.0m;
            Radius = 0.0m;
        }
    }
}
