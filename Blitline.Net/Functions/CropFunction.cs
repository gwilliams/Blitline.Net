namespace Blitline.Net.Functions
{
    public class CropFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "crop"; }
        }

        public override object @Params { get; protected set; }

        public CropFunction(int x, int y, int width, int height)
        {
            @Params = new
                          {
                              x,
                              y,
                              width,
                              height
                          };
        }
    }
}