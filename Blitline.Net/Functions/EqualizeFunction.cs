namespace Blitline.Net.Functions
{
    /// <summary>
    /// Equalizes an image (Auto-adjust image).
    /// </summary>
    public class EqualizeFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "equalize"; }
        }

        public override object Params { get; protected set; }

        public EqualizeFunction()
        {
            @Params = new {};
        }
    }
}
