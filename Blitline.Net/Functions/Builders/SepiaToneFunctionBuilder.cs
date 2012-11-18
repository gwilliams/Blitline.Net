namespace Blitline.Net.Functions.Builders
{
    public class SepiaToneFunctionBuilder : FunctionBuilder<SepiaToneFunction>
    {
        public SepiaToneFunctionBuilder()
        {
            Function = new SepiaToneFunction();
        }

        public SepiaToneFunctionBuilder WithThreshold(int thresold)
        {
            ((SepiaToneFunction) Function).Threshold = thresold;
            return this;
        }

        protected override SepiaToneFunction BuildImp()
        {
            return (SepiaToneFunction) Function;
        }
    }
}
