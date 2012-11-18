namespace Blitline.Net.Functions.Builders
{
    public class TrimFunctionBuilder : FunctionBuilder<TrimFunction>
    {
        public TrimFunctionBuilder()
        {
            Function = new TrimFunction();
        }

        protected override TrimFunction BuildImp()
        {
            return (TrimFunction) Function;
        }
    }
}
