namespace Blitline.Net.Functions
{
    public class CropFunction : BlitlineFunction
    {
        public override string name
        {
            get { return "crop"; }
        }

        public override object @params { get; set; }

        public CropFunction(int x, int y, int width, int height)
        {
            @params = new
                          {
                              x,
                              y,
                              width,
                              height
                          };
        }
    }
}