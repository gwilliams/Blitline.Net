namespace Blitline.Net.Functions.Builders
{
    public class MedianFilterFunctionBuilder : FunctionBuilder<MedianFilterFunction>
    {
        public MedianFilterFunctionBuilder()
        {
            Function = new MedianFilterFunction();
        }

        public MedianFilterFunctionBuilder WithRadius(decimal radius)
        {
            ((MedianFilterFunction) Function).Radius = radius;
            return this;
        }

        protected override MedianFilterFunction BuildImp()
        {
            return (MedianFilterFunction) Function;
        }
    }
}
