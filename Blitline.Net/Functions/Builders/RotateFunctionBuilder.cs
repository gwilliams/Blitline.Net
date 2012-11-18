namespace Blitline.Net.Functions.Builders
{
    public class RotateFunctionBuilder : FunctionBuilder<RotateFunction>
    {
        public RotateFunctionBuilder()
        {
            Function = new RotateFunction();
        }

        public RotateFunctionBuilder WithAmount(int amount)
        {
            ((RotateFunction) Function).Amount = amount;
            return this;
        }

        protected override RotateFunction BuildImp()
        {
            return (RotateFunction) Function;
        }
    }
}
