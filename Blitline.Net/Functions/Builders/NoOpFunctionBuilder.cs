namespace Blitline.Net.Functions.Builders
{
    public class NoOpFunctionBuilder : FunctionBuilder<NoOpFunction>
    {
        public NoOpFunctionBuilder()
        {
            Function = new NoOpFunction();    
        }

        protected override NoOpFunction BuildImp()
        {
            return (NoOpFunction) Function;
        }
    }
}
