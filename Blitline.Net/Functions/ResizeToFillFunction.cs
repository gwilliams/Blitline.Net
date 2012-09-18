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

        public override object @Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">Width of desired image</param>
        /// <param name="height">Height of desired image</param>
        /// <param name="gravity">Location of crop (defaults to 'CenterGravity')</param>
        /// <param name="onlyShrinkLarger">Don’t upsize image (defaults to false)</param>
        public ResizeToFillFunction(int width, int height, Gravity gravity = Gravity.CenterGrativty, bool onlyShrinkLarger = false)
        {
            var g = gravity.ToString();
            @Params = new
                          {
                              width,
                              height,
                              gravity = g,
                              only_shrink_larger = onlyShrinkLarger
                          };
        }
    }
}
