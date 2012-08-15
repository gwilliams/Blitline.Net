namespace Blitline.Net.Functions
{
    public class ResizeToFitFunction : BlitlineFunction
    {
        public override string name
        {
            get { return "resize_to_fit"; }
        }

        public override object @params { get; set; }

        public ResizeToFitFunction(int width, int height) : this(width, height, false) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="onlyShrinkLarger">Don't upsize image</param>
        public ResizeToFitFunction(int width, int height, bool onlyShrinkLarger)
        {
            @params = new
            {
                width,
                height,
                only_shrink_larger = onlyShrinkLarger
            };
        }
    }
}