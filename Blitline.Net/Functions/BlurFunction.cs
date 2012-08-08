namespace Blitline.Net.Functions
{
    public class BlurFunction : BlitlineFunction
    {
        public override string name
        {
            get { return "blur"; }
        }

        public override object @params { get; set; }

        public BlurFunction(decimal sigma, decimal radius)
        {
            @params = new
                          {
                              sigma,
                              radius
                          };
        }
    }
}
