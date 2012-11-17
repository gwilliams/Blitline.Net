namespace Blitline.Net.Functions
{
    /// <summary>
    /// Resize the image to a specific height and width. 
    /// Note: This is not used very often. You are probably looking for "resize_to_fit".
    /// </summary>
    public class ResizeFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "resize"; }
        }

        public override object Params
        {
            get
            {
                return new
                {
                    width = Width,
                    height = Height,
                    scale_factor = ScaleFactor
                };
            }
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public decimal ScaleFactor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">The new width of the image</param>
        /// <param name="height">The new height of the image</param>
        /// <param name="scaleFactor">Instead of height and width you can set a scale factor. (eg 0.5 = 50%)</param>
        public ResizeFunction(int width, int height, decimal scaleFactor = 0.5m)
        {
            Width = width;
            Height = height;
            ScaleFactor = scaleFactor;
        }

        protected internal ResizeFunction()
        {
            ScaleFactor = 0.5m;
        }
    }
}
