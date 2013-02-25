namespace Blitline.Net.Functions
{
    /// <summary>
    /// Adjusts contrasts within the image.
    /// </summary>
    public class ContrastStretchChannelFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "contrast_stretch_channel"; }
        }

        public override object Params
        {
            get
            {
                return new
                           {
                               black_point = BlackPoint,
                               white_point = WhitePoint
                           };
            }
        }

        public int BlackPoint { get; set; }
        public int WhitePoint { get; set; }
    }
}
