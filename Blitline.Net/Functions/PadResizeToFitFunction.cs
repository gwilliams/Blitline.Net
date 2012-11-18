using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Resize to fit, but will pad to keep the aspect ratio. 
    /// So for example, if you are going from a 3:4 aspect ratio to a 3:2 aspect ratio, 
    /// this method will assure the result the desired output size, and pad the filled in area with a specified color.
    /// </summary>
    public class PadResizeToFitFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "pad_resize_to_fit"; }
        }

        public override object Params
        {
            get
            {
                return new
                {
                    width = Width,
                    height = Height,
                    color = Colour,
                    gravity = Gravity.ToString()
                };
            }
        }

        public override void Validate() {}

        public int Width { get; set; }
        public int Height { get; set; }
        public string Colour { get; set; }
        public Gravity Gravity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">Output width</param>
        /// <param name="height">Output height</param>
        /// <param name="colour">Color for the padding (defaults to "#ffffff")</param>
        /// <param name="gravity">Location of output relative to padding (defaults to CenterGrativty)</param>
        public PadResizeToFitFunction(int width, int height, string colour = "#ffffff", Gravity gravity = Gravity.CenterGrativty)
        {
            Width = width;
            Height = height;
            Colour = colour;
            Gravity = gravity;
        }

        protected internal PadResizeToFitFunction()
        {
            Colour = "#ffffff";
            Gravity = Gravity.CenterGrativty;
        }
    }
}
