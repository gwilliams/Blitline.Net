namespace Blitline.Net.Functions.Builders
{
    public class ScriptFunctionBuilder : FunctionBuilder<ScaleFunction>
    {
        public ScriptFunctionBuilder WithBashString(string bashString)
        {
            BuildImp.BashString = bashString;
            return this;
        }
    }
}
