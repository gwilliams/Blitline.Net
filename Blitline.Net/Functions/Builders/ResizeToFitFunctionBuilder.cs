namespace Blitline.Net.Functions.Builders
{
    public class ResizeToFitFunctionBuilder : FunctionBuilder<ResizeToFitFunction>
    {
        public ResizeToFitFunctionBuilder()
        {
            Function = new ResizeToFitFunction();
        }

        public ResizeToFitFunctionBuilder WithWidth(int width)
        {
            ((ResizeToFitFunction) Function).Width = width;
            return this;
        }

        public ResizeToFitFunctionBuilder WithHeight(int height)
        {
            ((ResizeToFitFunction) Function).Height = height;
            return this;
        }

        public ResizeToFitFunctionBuilder OnlyShrinkLarger(bool onlyShrinkLarger)
        {
            ((ResizeToFitFunction) Function).OnlyShrinkLarger = onlyShrinkLarger;
            return this;
        }

        protected override ResizeToFitFunction BuildImp()
        {
            return (ResizeToFitFunction) Function;
        }
    }
}
