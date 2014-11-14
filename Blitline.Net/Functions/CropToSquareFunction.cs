using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Crop an image to a sqaure, based on height vs width. Square side length will be the smaller of the 2.
    /// </summary>
    public class CropToSquareFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "crop_to_square"; }
        }

        public override dynamic Params
        {
            get { return new {gravity = Gravity}; }
        }

        /// <summary>
        /// Gravity of resulting crop (default CenterGravity)
        /// </summary>
        public Gravity Gravity { get; set; }

        public CropToSquareFunction()
        {
            Gravity = Gravity.CenterGrativty;
        }
    }
}