using System;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Sets the DPI of the image
    /// </summary>
    public class DensityFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "density"; }
        }

        public override dynamic Params
        {
            get { return new {dpi = Dpi}; }
        }

        /// <summary>
        /// Sets the DPI of the image
        /// </summary>
        public int Dpi { get; set; }

        public override void Validate()
        {
            if(Dpi <= 0) throw new ArgumentException("Dpi required");
        }
    }
}