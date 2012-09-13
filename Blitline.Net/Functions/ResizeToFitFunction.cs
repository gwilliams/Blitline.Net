namespace Blitline.Net.Functions
{
    public class ResizeToFitFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "resize_to_fit"; }
        }

        public override object @Params { get; set; }

        public ResizeToFitFunction(int width, int height)
        {
            @Params = new
                          {
                              width, height
                          };
        }
    }
}