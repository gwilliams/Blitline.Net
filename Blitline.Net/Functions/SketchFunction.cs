namespace Blitline.Net.Functions
{
    /// <summary>
    /// Simulates a pencil sketch.
    /// </summary>
    public class SketchFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "sketch"; }
        }

        public override object Params
        {
            get
            {
                return new
                {
                    sigma = Sigma,
                    radius = Radius,
                    angle = Angle
                };
            }
        }

        /// <summary>
        /// Gaussian operator (defaults to 0.0)
        /// </summary>
        public decimal Sigma { get; set; }

        /// <summary>
        /// Gaussian operator (defaults to 0.0)
        /// </summary>
        public decimal Radius { get; set; }

        /// <summary>
        /// Angle of sketch (defaults to 0.0)
        /// </summary>
        public decimal Angle { get; set; }
    }
}
