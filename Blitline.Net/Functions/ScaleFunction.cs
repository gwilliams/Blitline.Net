using System;
using System.Dynamic;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Resize the image to a specific height and width. 
    /// Note: This is not used very often. You are probably looking for "resize_to_fit".
    /// </summary>
    public class ScaleFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "scale"; }
        }

        public override dynamic Params
        {
            get
            {
                dynamic o = new ExpandoObject();

                o.width = Width;
                o.height = Height;

                if (ScaleFactor > 0) o.scale_factor = ScaleFactor;

                return o;
            }
        }

        public override void Validate()
        {
              if (ScaleFactor != 0 && (Width != 0 || Height != 0))
              {
                  throw new ArgumentException("Can only supply Width and Height OR ScaleFactor. Not Both.");
              }
        }

        /// <summary>
        /// The new width of the image
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The new height of the image
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Instead of height and width you can set a scale factor. (eg 0.5 = 50%)
        /// </summary>
        public decimal ScaleFactor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">The new width of the image</param>
        /// <param name="height">The new height of the image</param>
        /// <param name="scaleFactor">Instead of height and width you can set a scale factor. (eg 0.5 = 50%)</param>
        public ScaleFunction(int width, int height, decimal scaleFactor = 0.5m)
        {
            Width = width;
            Height = height;
            ScaleFactor = scaleFactor;
        }

        public ScaleFunction() {}
    }
}
