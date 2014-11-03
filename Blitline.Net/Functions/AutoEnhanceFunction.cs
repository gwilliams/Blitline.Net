namespace Blitline.Net.Functions
{
    /// <summary>
    /// Automatically 'enhances' (magic wand) an image
    /// </summary>
    public class AutoEnhanceFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "auto_enhance"; }
        }

        public override object Params { get { return new { }; } }
    }
}