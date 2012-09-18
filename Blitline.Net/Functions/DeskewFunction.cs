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

        public override object Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="threshold">Maximum threshold percentage for deskewing (Default = 0.40)</param>
        public DeskewFunction(decimal threshold = 0.40m)
        {
            @Params = new
                {
                    threshold
                };
        }
    }
}
