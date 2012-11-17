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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sigma">Gaussian operator (defaults to 0.0)</param>
        /// <param name="radius">Gaussian operator (defaults to 0.0)</param>
        /// <param name="angle">Angle of sketch (defaults to 0.0)</param>
        public SketchFunction(decimal sigma = 0.0m, decimal radius = 0.0m, decimal angle = 0.0m)
        {
            Sigma = sigma;
            Radius = radius;
            Angle = angle;
        }

        protected internal SketchFunction() {}
    }
}
