using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    public class ResizeToFillFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "resize_to_fill"; }
        }

        public override object @Params { get; protected set; }

        public ResizeToFillFunction(int width, int height, Gravity gravity)
        {
            var g = gravity.ToString();
            @Params = new
                          {
                              width,
                              height,
                              g
                          };
        }
    }
}
