namespace Blitline.Net.Functions.Builders
{
    public class MedianFilterFunctionBuilder : FunctionBuilder<MedianFilterFunction>
    {
        public MedianFilterFunctionBuilder WithRadius(decimal radius)
        {
            BuildImp.Radius = radius;
            return this;
        }
    }
}
