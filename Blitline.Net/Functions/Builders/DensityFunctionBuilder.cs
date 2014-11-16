namespace Blitline.Net.Functions.Builders
{
    public class DensityFunctionBuilder : FunctionBuilder<DensityFunction>
    {
        public DensityFunctionBuilder WithDpi(int dpi)
        {
            BuildImp.Dpi = dpi;
            return this;
        }
    }
}