namespace Blitline.Net.Functions
{
    /// <summary>
    /// Resize the image to fit within the specified dimensions while retaining the original aspect ratio. 
    /// The image may be shorter or narrower than specified in the smaller dimension but will not be larger than the specified values
    /// Common English Translation: This is probably the crop you want if you need to rescale a photo down to a smaller size while keeping the same height to width ratio.
    /// </summary>
    public class ResizeToFitFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "resize_to_fit"; }
        }

        public override object @Params { get; protected set; }

        public ResizeToFitFunction(int width, int height) : this(width, height, false) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">Width of desired image</param>
        /// <param name="height">Height of desired image</param>
        /// <param name="onlyShrinkLarger">Don't upsize image</param>
        public ResizeToFitFunction(int width, int height, bool onlyShrinkLarger = false)
        {
            @Params = new
            {
                width,
                height,
                only_shrink_larger = onlyShrinkLarger
            };
        }
    }
}