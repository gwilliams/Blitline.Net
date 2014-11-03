namespace Blitline.Net.Functions.Builders
{
    public class AppendFunctionBuilder : FunctionBuilder<AppendFunction>
    {
        public AppendFunctionBuilder AppendVeritically(bool vertical)
        {
            BuildImp.Vertical = vertical;
            return this;
        }
    }
}
