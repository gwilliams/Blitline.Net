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

        public override object Params
        {
            get
            {
                return new
                {
                    brightness = Brightness,
                    saturation = Saturation,
                    hue = Hue
                };
            }
        }

        public override void Validate() {}

        public decimal Brightness { get; set; }
        public decimal Saturation { get; set; }
        public decimal Hue { get; set; }

        public ModulateFunction(decimal brightness = 1.0m, decimal saturation = 1.0m, decimal hue = 1.0m)
        {
            Brightness = brightness;
            Saturation = saturation;
            Hue = hue;
        }

        public ModulateFunction()
        {
            Brightness = 1.0m;
            Saturation = 1.0m;
            Hue = 1.0m;
        }
    }
}
