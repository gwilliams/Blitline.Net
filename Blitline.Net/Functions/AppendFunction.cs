namespace Blitline.Net.Functions
{
    public class AppendFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "append"; }
        }

        public override object Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertical">Whether images are appended vertically(true) or horizontally(false)</param>
        public AppendFunction(bool vertical)
        {
            @Params = new
                {
                    vertical
                };
        }
    }
}
