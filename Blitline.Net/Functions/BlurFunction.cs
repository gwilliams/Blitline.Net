namespace Blitline.Net.Functions
{
    public class BlurFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "blur"; }
        }

        public override object @Params { get; protected set; }

        public BlurFunction(decimal sigma, decimal radius)
        {
            @Params = new
                          {
                              sigma,
                              radius
                          };
        }
    }
}
