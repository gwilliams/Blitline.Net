using System.Text.RegularExpressions;
using System;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Equalizes an image (Auto-adjust image).
    /// </summary>
    public class EqualizeFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "equalize"; }
        }

        public override object Params { get { return new {}; } }
    }

}
