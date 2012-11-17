namespace Blitline.Net.Functions.Builders
{
    public class PhotographFunctionBuilder : FunctionBuilder<PhotographFunction>
    {
        public PhotographFunctionBuilder()
        {
            Function = new PhotographFunction();
        }

        public PhotographFunctionBuilder WithAngle(int angle)
        {
            ((PhotographFunction) Function).Angle = angle;
            return this;
        }

        protected override PhotographFunction BuildImp()
        {
            return (PhotographFunction) Function;
        }
    }
}
