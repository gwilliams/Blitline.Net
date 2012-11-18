namespace Blitline.Net.Functions.Builders
{
    public class QuantizeFunctionBuilder : FunctionBuilder<QuantizeFunction>
    {
        public QuantizeFunctionBuilder()
        {
            Function = new QuantizeFunction();
        }

        public QuantizeFunctionBuilder WithNumberOfColours(int numberOfColours)
        {
            ((QuantizeFunction) Function).NumberOfColours = numberOfColours;
            return this;
        }

        public QuantizeFunctionBuilder WithColourSpace(string colourSpace)
        {
            ((QuantizeFunction) Function).ColourSpace = colourSpace;
            return this;
        }

        public QuantizeFunctionBuilder Dither(bool dither)
        {
            ((QuantizeFunction) Function).Dither = dither;
            return this;
        }

        protected override QuantizeFunction BuildImp()
        {
            return (QuantizeFunction) Function;
        }
    }
}
