namespace Blitline.Net.Functions
{
    /// <summary>
    /// Simple noop. No function performed on image.
    /// </summary>
    public class NoOpFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "no_op"; }
        }

        public override object Params { get { return new {}; } }

        public NoOpFunction()
        {
        }
    }
}
