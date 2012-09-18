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

        public override object @Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sigma">Gaussian sigma of blur (defaults to 1.0)</param>
        /// <param name="radius">Gaussian radius of blur (defaults to 0.0)</param>
        public BlurFunction(decimal sigma, decimal radius)
        {
            @Params = new
                          {
                              sigma,
                              radius
                          };
        }
    }
}
