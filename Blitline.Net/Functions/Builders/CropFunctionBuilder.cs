using Blitline.Net.ParamOptions;

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

        public CropFunctionBuilder WithGravity(Gravity gravity)
        {
            BuildImp.Gravity = gravity;

            return this;
        }

        public CropFunctionBuilder PreserveAspectIfSmaller()
        {
            BuildImp.PreserveAspectIfSmaller = true;
            return this;
        }
    }
}