namespace Blitline.Net.Functions.Builders
{
    public class DeskewFunctionBuilder : FunctionBuilder<DeskewFunction>
    {
        public DeskewFunctionBuilder WithThreshold(decimal threshold)
        {
            BuildImp.Threshold = threshold;
            return this;
        }
    }
}
