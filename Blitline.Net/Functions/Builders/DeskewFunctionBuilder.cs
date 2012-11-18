namespace Blitline.Net.Functions.Builders
{
    public class DeskewFunctionBuilder : FunctionBuilder<DeskewFunction>
    {
        public DeskewFunctionBuilder()
        {
            Function = new DeskewFunction();
        }

        public DeskewFunctionBuilder WithThreshold(decimal threshold)
        {
            ((DeskewFunction) Function).Threshold = threshold;
            return this;
        }

        protected override DeskewFunction BuildImp()
        {
            return (DeskewFunction)Function;
        }
    }
}
