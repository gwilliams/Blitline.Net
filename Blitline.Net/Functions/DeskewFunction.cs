namespace Blitline.Net.Functions
{
    /// <summary>
    /// Straightens an image.
    /// </summary>
    public class DeskewFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "deskew"; }
        }

        public override object Params { get { return new {threshold = Threshold}; } }

        /// <summary>
        /// Maximum threshold percentage for deskewing (Default = 0.40)
        /// </summary>
        public decimal Threshold { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="threshold">Maximum threshold percentage for deskewing (Default = 0.40)</param>
        public DeskewFunction(decimal threshold = 0.40m)
        {
            Threshold = threshold;
        }

        protected internal DeskewFunction()
        {
            Threshold = 0.4m;
        }
    }
}
