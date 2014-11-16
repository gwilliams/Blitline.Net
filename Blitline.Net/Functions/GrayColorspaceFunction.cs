namespace Blitline.Net.Functions
{
    /// <summary>
    /// Turns image into grayscale
    /// </summary>
    public class GrayColorspaceFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "gray_colorspace"; }
        }

        public override dynamic Params
        {
            get { return new { }; }
        }
    }
}