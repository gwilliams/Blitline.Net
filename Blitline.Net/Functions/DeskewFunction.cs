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

	    public DeskewFunction()
        {
            Threshold = 0.4m;
        }
    }
}
