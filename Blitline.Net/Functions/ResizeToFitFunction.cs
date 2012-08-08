namespace Blitline.Net.Functions
{
    public class ResizeToFitFunction : BlitlineFunction
    {
        public override string name
        {
            get { return "resize_to_fit"; }
        }

        public override object @params { get; set; }

        public ResizeToFitFunction(int width, int height)
        {
            @params = new
                          {
                              width, height
                          };
        }
    }
}