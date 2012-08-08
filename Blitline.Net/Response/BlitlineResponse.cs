namespace Blitline.Net.Response
{
    public class BlitlineResponse
    {
        public Results Results { get; set; }

        public bool Failed { get { return !string.IsNullOrEmpty(Results.Error); } }
    }
}