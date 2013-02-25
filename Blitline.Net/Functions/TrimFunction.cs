namespace Blitline.Net.Functions
{        
    /// <summary>
    /// Makes a "best guess" crop to upper-left and lower-right corners. 
    /// For example, if you have an image with a bunch of white border around it, 
    /// and you want it cropped to only where there something other than the border color.
    /// </summary>
    public class TrimFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "trim"; }
        }

        public override object Params { get { return new {}; } }
    }
}
