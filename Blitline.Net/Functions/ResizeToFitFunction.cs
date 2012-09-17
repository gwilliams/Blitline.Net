namespace Blitline.Net.Functions
{
    public class ResizeToFitFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "resize_to_fit"; }
        }

        public override object @Params { get; set; }

        public ResizeToFitFunction(int width, int height) : this(width, height, false) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="onlyShrinkLarger">Don't upsize image</param>
        public ResizeToFitFunction(int width, int height, bool onlyShrinkLarger)
        {
            @Params = new
            {
                width,
                height,
                only_shrink_larger = onlyShrinkLarger
            };
        }
    }
}