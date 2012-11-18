namespace Blitline.Net.Functions.Builders
{
    public class SketchFunctionBuilder : FunctionBuilder<SketchFunction>
    {
        public SketchFunctionBuilder()
        {
            Function = new SketchFunction();
        }

        public SketchFunctionBuilder WithSigma(decimal sigma)
        {
            ((SketchFunction) Function).Sigma = sigma;
            return this;
        }

        public SketchFunctionBuilder WithRadius(decimal radius)
        {
            ((SketchFunction) Function).Radius = radius;
            return this;
        }

        public SketchFunctionBuilder WithAngle(decimal angle)
        {
            ((SketchFunction) Function).Angle = angle;
            return this;
        }

        protected override SketchFunction BuildImp()
        {
            return (SketchFunction) Function;
        }
    }
}
