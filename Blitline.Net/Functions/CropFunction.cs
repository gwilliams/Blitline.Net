namespace Blitline.Net.Functions
{
    /// <summary>
    /// Crop an image to a specific size. 
    /// Note: This is not used very often. You are probably looking for "resize_to_fill".
    /// </summary>
    public class CropFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "crop"; }
        }

        public override object @Params
        {
            get
            {
                return new
                           {
                               x = X,
                               y = Y,
                               width = Width,
                               height = Height
                           };
            }
        }

        /// <summary>
        /// X offset
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y offset
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Width of resulting image
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of resulting image
        /// </summary>
        public int Height { get; set; }
    }
}