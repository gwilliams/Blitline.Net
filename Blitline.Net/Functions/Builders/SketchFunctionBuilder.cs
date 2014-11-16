using System;

namespace Blitline.Net.Functions.Builders
{
	public class SketchFunctionBuilder : FunctionBuilder<SketchFunction>
    {
        public SketchFunctionBuilder WithSigma(decimal sigma)
        {
            BuildImp.Sigma = sigma;
            return this;
        }

        public SketchFunctionBuilder WithRadius(decimal radius)
        {
            BuildImp.Radius = radius;
            return this;
        }

        public SketchFunctionBuilder WithAngle(decimal angle)
        {
            BuildImp.Angle = angle;
            return this;
        }
    }
}
