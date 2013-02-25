namespace Blitline.Net.Functions.Builders
{
    public class ContrastFunctionBuilder : FunctionBuilder<ContrastFunction>
    {
        public ContrastFunctionBuilder Sharpen(bool sharpen)
        {
            BuildImp.Sharpen = sharpen;
            return this;
        }
    }
}
