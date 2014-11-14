namespace Blitline.Net.Functions
{
    /// <summary>
    /// Reduces the speckle noise while preserving edges
    /// </summary>
    public class DespeckleFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "despeckle"; }
        }

        public override dynamic Params
        {
            get { return new {}; }
        }
    }
}