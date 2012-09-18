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

        public override object Params { get; protected set; }

        public CompositeFunction(string src, bool asMask = false, int x = 0, int y = 0, CompositeOps compositeOp = CompositeOps.OverCompositeOp)
        {
            @Params = new
                {
                    src,
                    as_mask = asMask,
                    x,
                    y,
                    composite_op = compositeOp.ToString()
                };
        }
    }
}
