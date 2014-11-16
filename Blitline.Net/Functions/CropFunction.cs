using Blitline.Net.ParamOptions;

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
                               height = Height,
                               preserve_aspect_if_smaller = PreserveAspectIfSmaller,
                               gravity = Gravity
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

        /// <summary>
        /// If source image is smaller than target size, crop smaller image to still be same aspect ratio
        /// </summary>
        public bool PreserveAspectIfSmaller { get; set; }

        /// <summary>
        /// Sets the starting gravity of where the x,y will offset from
        /// </summary>
        public Gravity Gravity { get; set; }

        public CropFunction()
        {
            Gravity = Gravity.CenterGrativty;
        }
    }
}