using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class ResizeToFillFunctionBuilder : FunctionBuilder<ResizeToFillFunction>
    {
        public ResizeToFillFunctionBuilder WithWidth(int width)
        {
            BuildImp.Width = width;
            return this;
        }

        public ResizeToFillFunctionBuilder WithHeight(int height)
        {
            BuildImp.Height = height;
            return this;
        }

        public ResizeToFillFunctionBuilder WithGravity(Gravity gravity)
        {
            BuildImp.Gravity = gravity;
            return this;
        }

        public ResizeToFillFunctionBuilder OnlyShrinkLarger(bool onlyShrinkLarger)
        {
            BuildImp.OnlyShrinkLarger = onlyShrinkLarger;
            return this;
        }
    }
}
