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

        public override object Params
        {
            get
            {
                return new
                {
                    threshold = Threshold
                };
            }
        }

        public int Threshold { get; set; }

        public SepiaToneFunction(int threshold = 0)
        {
            Threshold = threshold;
        }

        protected internal SepiaToneFunction() {}
    }
}
