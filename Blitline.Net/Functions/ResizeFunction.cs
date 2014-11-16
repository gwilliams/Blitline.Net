using System;
using System.Dynamic;
using Blitline.Net.Functions;

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

        public int Width { get; set; }
        public int Height { get; set; }
        public decimal ScaleFactor { get; set; }
    }

}
