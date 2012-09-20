namespace Blitline.Net.Functions
{
    /// <summary>
    /// Adjusts contrasts within the image.
    /// </summary>
    internal class ContrastStretchChannelFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "contrast_stretch_channel"; }
        }

        public override object Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blackPoint">Burn at most this many pixels. Specify an absolute number of pixels as a numeric value</param>
        /// <param name="whitePoint">Burn at most this many pixels. Specify an absolute number of pixels as a numeric value. If not given defaults to all_points-black_point</param>
        public ContrastStretchChannelFunction(int blackPoint, int whitePoint = 0)
        {
            @Params = new
                {
                    black_point = blackPoint,
                    white_point = whitePoint
                };
        }
    }
}
