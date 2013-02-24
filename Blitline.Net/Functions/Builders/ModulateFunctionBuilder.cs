namespace Blitline.Net.Functions.Builders
{
    public class ModulateFunctionBuilder : FunctionBuilder<ModulateFunction>
    {
        public ModulateFunctionBuilder WithBrightness(decimal brightness)
        {
            BuildImp.Brightness = brightness;
            return this;
        }

        public ModulateFunctionBuilder WithSaturation(decimal saturation)
        {
            BuildImp.Saturation = saturation;
            return this;
        }

        public ModulateFunctionBuilder WithHue(decimal hue)
        {
            BuildImp.Hue = hue;
            return this;
        }
    }
}
