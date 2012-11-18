namespace Blitline.Net.Functions
{
    /// <summary>
    /// Adjusts contrasts within the image.
    /// </summary>
    public class ContrastFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "contrast"; }
        }

        public override object Params
        {
            get
            {
                return new
                           {
                               sharpen = Sharpen
                           };
            }
        }

        public override void Validate() {}

        /// <summary>
        /// Contrast is increased if true (defaults to false)
        /// </summary>
        public bool Sharpen { get; set; }

        /// <summary>
        /// Contrast is increased if true (defaults to false)
        /// </summary>
        /// <param name="sharpen"></param>
        public ContrastFunction(bool sharpen = false)
        {
            Sharpen = sharpen;
        }

        protected internal ContrastFunction() {}
    }
}
