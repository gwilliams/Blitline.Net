namespace Blitline.Net.Functions.Builders
{
    public class QuantizeFunctionBuilder : FunctionBuilder<QuantizeFunction>
    {
        public QuantizeFunctionBuilder WithNumberOfColours(int numberOfColours)
        {
            BuildImp.NumberOfColours = numberOfColours;
            return this;
        }

        public QuantizeFunctionBuilder WithColourSpace(string colourSpace)
        {
            BuildImp.ColourSpace = colourSpace;
            return this;
        }

        public QuantizeFunctionBuilder Dither(bool dither)
        {
            BuildImp.Dither = dither;
            return this;
        }
    }
}
