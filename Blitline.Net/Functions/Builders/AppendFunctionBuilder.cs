namespace Blitline.Net.Functions.Builders
{
    public class AppendFunctionBuilder : FunctionBuilder<AppendFunction>
    {
        public AppendFunctionBuilder()
        {
            Function = new AppendFunction();
        }

        public AppendFunctionBuilder AppendVeritically(bool vertical)
        {
            ((AppendFunction) Function).Vertical = vertical;
            return this;
        }

        protected override AppendFunction BuildImp()
        {
            return (AppendFunction) Function;
        }
    }
}
