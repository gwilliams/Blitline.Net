namespace Blitline.Net.Functions
{
    /// <summary>
    /// Creates an image that has a white border, with a slight curl, that appears like a photograph
    /// </summary>
    public class PhotographFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "photograph"; }
        }

        public override object Params { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle">Angle of rotation</param>
        public PhotographFunction(int angle = 0)
        {
            @Params = new {angle};
        }
    }
}
