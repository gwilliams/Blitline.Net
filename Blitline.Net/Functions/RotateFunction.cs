namespace Blitline.Net.Functions
{
    /// <summary>
    /// Resize the image to fit within the specified dimensions while retaining the original aspect ratio. 
    /// The image may be shorter or narrower than specified in the smaller dimension but will not be larger than the specified values
    /// </summary>
    public class RotateFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "rotate"; }
        }

        public override object Params
        {
            get
            {
                return new
                {
                    amount = Amount
                };
            }
        }

        public int Amount { get; set; }

        /// <summary>
        /// The number of degrees to rotate the image.
        /// </summary>
        /// <param name="amount"></param>
        public RotateFunction(int amount)
        {
            Amount = amount;
        }

        protected internal RotateFunction() {}
    }
}
