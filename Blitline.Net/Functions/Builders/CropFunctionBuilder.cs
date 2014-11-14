namespace Blitline.Net.Functions.Builders
{
    public class CropFunctionBuilder : FunctionBuilder<CropFunction>
    {
        public CropFunctionBuilder WithDimensions(int x, int y, int width, int height)
        {
            BuildImp.X = x;
            BuildImp.Y = y;
            BuildImp.Width = width;
            BuildImp.Height = height;

            return this;
        }
    }
}