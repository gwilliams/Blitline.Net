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
            Function = new CropFunction(x, y, width, height);
            return this;
        }

        protected override CropFunction BuildImp()
        {
            return (CropFunction)Function;
        }
    }
}