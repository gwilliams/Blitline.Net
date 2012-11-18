namespace Blitline.Net.Functions.Builders
{
    public class ContrastFunctionBuilder : FunctionBuilder<ContrastFunction>
    {
        public ContrastFunctionBuilder()
        {
            Function = new ContrastFunction();
        }

        public ContrastFunctionBuilder Sharpen(bool sharpen)
        {
            ((ContrastFunction) Function).Sharpen = sharpen;
            return this;
        }

        protected override ContrastFunction BuildImp()
        {
            return (ContrastFunction)Function;
        }
    }
}
