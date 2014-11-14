using System.Collections.Generic;
using Blitline.Net.Request;
using Blitline.Net.Response;
using System.Threading.Tasks;

namespace Blitline.Net
{
    public interface IBlitlineApi
    {
        BlitlineResponse ProcessImages(BlitlineRequest blitlineRequest);
        Task<BlitlineResponse> ProcessImagesAsync(BlitlineRequest blitlineRequest);
        BlitlineBatchResponse ProcessImages(IEnumerable<BlitlineRequest> blitlineRequests);
        Task<BlitlineBatchResponse> ProcessImagesAsync(IEnumerable<BlitlineRequest> blitlineRequests);
    }
}