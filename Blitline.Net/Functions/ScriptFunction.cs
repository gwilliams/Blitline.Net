using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Run your own scripts on Blitline cloud servers.
    /// </summary>
    public class ScriptFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "script"; }
        }

        /// <summary>
        /// Bash string that will execute on the server
        /// </summary>
        public string BashString { get; set; }

        public override object Params { get { return new {bashString = BashString}; } }
    }
}