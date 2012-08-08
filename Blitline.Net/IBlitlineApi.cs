namespace Blitline.Net
{
    public interface IBlitlineApi
    {
        BlitlineResponse ProcessImages(BlitlineRequest blitlineRequest);
    }
}