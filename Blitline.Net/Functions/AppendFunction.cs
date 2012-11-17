namespace Blitline.Net.Functions
{
    /// <summary>
    /// Appends images together either vertically or horizontally
    /// </summary>
    public class AppendFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "append"; }
        }

        public override object Params
        {
            get
            {
                return new
                           {
                               vertical = Vertical
                           };
            }
        }

        /// <summary>
        /// Whether images are appended vertically(true) or horizontally(false)
        /// </summary>
        public bool Vertical { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertical">Whether images are appended vertically(true) or horizontally(false)</param>
        public AppendFunction(bool vertical)
        {
            Vertical = vertical;
        }

        protected internal AppendFunction() {}
    }
}
