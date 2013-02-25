namespace Blitline.Net.Functions.Builders
{
    public class ResizeToFitFunctionBuilder : FunctionBuilder<ResizeToFitFunction>
    {
        public ResizeToFitFunctionBuilder WithWidth(int width)
        {
            BuildImp.Width = width;
            return this;
        }

        public ResizeToFitFunctionBuilder WithHeight(int height)
        {
            BuildImp.Height = height;
            return this;
        }

        public ResizeToFitFunctionBuilder OnlyShrinkLarger(bool onlyShrinkLarger)
        {
            BuildImp.OnlyShrinkLarger = onlyShrinkLarger;
            return this;
        }
    }
}
