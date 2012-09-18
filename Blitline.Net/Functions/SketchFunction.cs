using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Simulates a pencil sketch.
    /// </summary>
    public class SketchFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "sketch"; }
        }

        public override object Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sigma">Gaussian operator (defaults to 0.0)</param>
        /// <param name="radius">Gaussian operator (defaults to 0.0)</param>
        /// <param name="angle">Angle of sketch (defaults to 0.0)</param>
        public SketchFunction(decimal sigma = 0.0m, decimal radius = 0.0m, decimal angle = 0.0m)
        {
            @Params = new
                {
                    sigma,
                    radius,
                    angle
                };
        }
    }
}
