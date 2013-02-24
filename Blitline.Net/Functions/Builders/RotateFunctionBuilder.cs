namespace Blitline.Net.Functions.Builders
{
    public class RotateFunctionBuilder : FunctionBuilder<RotateFunction>
    {
        public RotateFunctionBuilder WithAmount(int amount)
        {
            BuildImp.Amount = amount;
            return this;
        }
    }
}
