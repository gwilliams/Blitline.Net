namespace Blitline.Net.Functions
{
    /// <summary>
    /// Reduces noise in the image
    /// </summary>
    public class EnhanceFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "enhance"; }
        }

        public override dynamic Params
        {
            get { return new { }; }
        }
    }
}