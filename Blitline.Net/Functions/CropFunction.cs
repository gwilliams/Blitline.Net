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

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">X offset</param>
        /// <param name="y">Y offset</param>
        /// <param name="width">Width of resulting image</param>
        /// <param name="height">Height of resulting image</param>
        public CropFunction(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        protected internal CropFunction() {}
    }
}