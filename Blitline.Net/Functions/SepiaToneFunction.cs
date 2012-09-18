namespace Blitline.Net.Functions
{
    /// <summary>
    /// Applies sepia filter
    /// </summary>
    public class SepiaToneFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "sepia_tone"; }
        }

        public override object Params { get; protected set; }

        public SepiaToneFunction(int threshold = 0)
        {
            @Params = new
                {
                    threshold
                };
        }
    }
}
