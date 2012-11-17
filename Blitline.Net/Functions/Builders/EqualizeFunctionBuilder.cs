namespace Blitline.Net.Functions.Builders
{
    public class EqualizeFunctionBuilder : FunctionBuilder<EqualizeFunction>
    {
        public EqualizeFunctionBuilder()
        {
            Function = new EqualizeFunction();
        }

        protected override EqualizeFunction BuildImp()
        {
            return (EqualizeFunction) Function;
        }
    }
}
