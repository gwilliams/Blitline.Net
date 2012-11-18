namespace Blitline.Net.Functions.Builders
{
    public class CropFunctionBuilder : FunctionBuilder<CropFunction>
    {
        public CropFunctionBuilder()
        {
            Function = new CropFunction();
        }

        public CropFunctionBuilder WithDimensions(int x, int y, int width, int height)
        {
            ((CropFunction) Function).X = x;
            ((CropFunction)Function).Y = y;
            ((CropFunction)Function).Width = width;
            ((CropFunction)Function).Height = height;

            return this;
        }

        protected override CropFunction BuildImp()
        {
            return (CropFunction)Function;
        }
    }
}