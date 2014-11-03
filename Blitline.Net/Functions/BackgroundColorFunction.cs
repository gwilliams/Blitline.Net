namespace Blitline.Net.Functions
{
    /// <summary>
    /// Sets a transparent background color to be a solid (usefull when converting pngs to jpgs)
    /// </summary>
    public class BackgroundColorFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "background_color"; }
        }

        public string Colour { get; set; }

        public override object Params { get { return new {color = Colour}; } }

        public BackgroundColorFunction()
        {
            Colour = "#ffffff";
        }
    }
}