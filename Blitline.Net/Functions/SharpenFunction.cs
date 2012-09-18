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

        public override object Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sigma">Gaussian sigma of sharpen (defaults to 1.0)</param>
        /// <param name="radius"Gaussian radius of shapen (defaults to 0.0)></param>
        public SharpenFunction(decimal sigma = 1.0m, decimal radius = 0.0m)
        {
            @Params = new
                {
                    sigma, 
                    radius
                };
        }
    }
}
