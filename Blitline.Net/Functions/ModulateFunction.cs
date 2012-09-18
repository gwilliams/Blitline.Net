namespace Blitline.Net.Functions
{
    /// <summary>
    /// Changes the brightness, saturation, and hue.
    /// </summary>
    public class ModulateFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "modulate"; }
        }

        public override object Params { get; protected set; }

        public ModulateFunction(decimal brightness = 1.0m, decimal saturation = 1.0m, decimal hue = 1.0m)
        {
            @Params = new
                {
                    brightness,
                    saturation,
                    hue
                };
        }
    }
}
