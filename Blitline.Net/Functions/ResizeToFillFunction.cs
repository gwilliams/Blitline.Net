using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Resize the image to fit within the specified dimensions while retaining the aspect ratio of the original image. 
    /// If necessary, crop the image in the larger dimension 
    /// Common English Translation: This is probably the crop you want if you want to cut a center piece out of a photo and use it as a thumbnail. 
    /// This wont do any scaling, only cut out the center (by default) to your defined size.
    /// </summary>
    public class ResizeToFillFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "resize_to_fill"; }
        }

        public override object @Params
        {
            get
            {
                return new
                {
                    width = Width,
                    height = Height,
                    gravity = Gravity.ToString(),
                    only_shrink_larger = OnlyShrinkLarger
                };
            }
        }

        public override void Validate() {}

        /// <summary>
        /// Width of desired image
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of desired image
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Location of crop (defaults to 'CenterGravity')
        /// </summary>
        public Gravity Gravity { get; set; }

        /// <summary>
        /// Don’t upsize image (defaults to false)
        /// </summary>
        public bool OnlyShrinkLarger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">Width of desired image</param>
        /// <param name="height">Height of desired image</param>
        /// <param name="gravity">Location of crop (defaults to 'CenterGravity')</param>
        /// <param name="onlyShrinkLarger">Don’t upsize image (defaults to false)</param>
        public ResizeToFillFunction(int width, int height, Gravity gravity = Gravity.CenterGrativty, bool onlyShrinkLarger = false)
        {
            Width = width;
            Height = height;
            Gravity = gravity;
            OnlyShrinkLarger = onlyShrinkLarger;
        }

        protected internal ResizeToFillFunction()
        {
            Gravity = Gravity.CenterGrativty;
        }
    }
}
