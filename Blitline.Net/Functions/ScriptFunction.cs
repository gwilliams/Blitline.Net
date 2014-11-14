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
        public string Files { get; set; }
        public string Executable { get; set; }

        public override object Params 
        { 
            get 
            { 
                return new 
                {
                    bash_string = BashString,
                    files = Files,
                    executable = Executable
                }; 
            }
        }

        public override void Validate()
        {
            if (BashString != null && (Files != null || Executable != null)) throw new ArgumentException("BashString requires NO Executable or Files", "BashString");
            if (Files != null && Executable == null) throw new ArgumentException("Files requires Executable", "Files");
            if (Executable != null && Files == null) throw new ArgumentException("Executable requires Files", "Executable");
        }
    }
}