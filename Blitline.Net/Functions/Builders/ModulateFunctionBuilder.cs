namespace Blitline.Net.Functions.Builders
{
    public class ModulateFunctionBuilder : FunctionBuilder<ModulateFunction>
    {
        public ModulateFunctionBuilder()
        {
            Function = new ModulateFunction();
        }

        public ModulateFunctionBuilder WithBrightness(decimal brightness)
        {
            ((ModulateFunction) Function).Brightness = brightness;
            return this;
        }

        public ModulateFunctionBuilder WithSaturation(decimal saturation)
        {
            ((ModulateFunction) Function).Saturation = saturation;
            return this;
        }

        public ModulateFunctionBuilder WithHue(decimal hue)
        {
            ((ModulateFunction) Function).Hue = hue;
            return this;
        }

        protected override ModulateFunction BuildImp()
        {
            return (ModulateFunction) Function;
        }
    }
}
