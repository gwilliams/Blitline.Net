using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class CropToSquareFunctionBuilder : FunctionBuilder<CropToSquareFunction>
    {
        public CropToSquareFunctionBuilder WithGravity(Gravity gravity)
        {
            BuildImp.Gravity = gravity;

            return this;
        }
    }
}