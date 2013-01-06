using System.Collections.Generic;
using Blitline.Net.Request;
using Blitline.Net.Response;

namespace Blitline.Net
{
    public interface IBlitlineApi
    {
        BlitlineResponse ProcessImages(BlitlineRequest blitlineRequest);
        BlitlineBatchResponse ProcessImages(IEnumerable<BlitlineRequest> blitlineRequests);
    }
}