namespace Blitline.Net.Functions.Builders
{
    public class MedianFilterFunctionBuilder : FunctionBuilder<MedianFilterFunction>
    {
        public MedianFilterFunction WithRadius(decimal radius)
        {
            BuildImp.Radius = radius;
			return BuildImp;
        }
    }
}
