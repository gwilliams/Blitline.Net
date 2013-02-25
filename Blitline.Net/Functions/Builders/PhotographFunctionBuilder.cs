namespace Blitline.Net.Functions.Builders
{
    public class PhotographFunctionBuilder : FunctionBuilder<PhotographFunction>
    {
        public PhotographFunctionBuilder WithAngle(int angle)
        {
            BuildImp.Angle = angle;
            return this;
        }
    }
}
