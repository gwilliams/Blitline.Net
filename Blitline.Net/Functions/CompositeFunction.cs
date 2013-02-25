using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Composites one image onto another
    /// </summary>
    public class CompositeFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "composite"; }
        }

        public string Source { get; set; }
        public bool AsMask { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public CompositeOps CompositeOp { get; set; }

        public override object Params
        {
            get
            {
                return new
                {
                    src = Source,
                    as_mask = AsMask,
                    x = X,
                    y = Y,
                    composite_op = CompositeOp.ToString()
                };
            }
        }

	    public CompositeFunction()
        {
            CompositeOp = CompositeOps.OverCompositeOp;
        }
    }
}
