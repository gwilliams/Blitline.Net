namespace Blitline.Net.Functions
{
    /// <summary>
    /// Adjusts contrasts within the image.
    /// </summary>
    public class GammaChannelFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "gamma_channel"; }
        }

        public override object Params { get { return new {gamma = Gamma}; } }

        /// <summary>
        /// Gamma adjustent (Usually 0.8 to 2.3)
        /// </summary>
        public decimal Gamma { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gamma">Gamma adjustent (Usually 0.8 to 2.3)</param>
        public GammaChannelFunction(decimal gamma)
        {
            Gamma = gamma;
        }

        protected internal GammaChannelFunction() {}
    }
}
