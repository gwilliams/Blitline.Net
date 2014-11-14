using System;

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
        /// String representation of a bash file that will execute on the server (requires NO 'executable' or 'files)
        /// </summary>
        public string BashString { get; set; }

        /// <summary>
        /// Extra files to download before the script is run (requires 'executable')
        /// </summary>
        public string Files { get; set; }

        /// <summary>
        /// Command line to run script (requires 'files')
        /// </summary>
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