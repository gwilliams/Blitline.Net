namespace Blitline.Net.Functions.Builders
{
    public class ScriptFunctionBuilder : FunctionBuilder<ScriptFunction>
    {
        public ScriptFunctionBuilder WithBashString(string bashString)
        {
            BuildImp.BashString = bashString;
            return this;
        }

        public ScriptFunctionBuilder WithFiles(string files)
        {
            BuildImp.Files = files;
            return this;
        }

        public ScriptFunctionBuilder WithExecutable(string executable)
        {
            BuildImp.Executable = executable;
            return this;
        }
    }
}
