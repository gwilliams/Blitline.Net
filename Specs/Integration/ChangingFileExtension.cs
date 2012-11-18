using System.Linq;
using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using SubSpec;
using Xunit;

namespace Specs.Integration
{
    public class ChangingFileExtension
    {
        BlitlineApi _blitline = default(BlitlineApi);
        BlitlineResponse _response = default (BlitlineResponse);
        BlitlineRequest _request = default (BlitlineRequest);

        [Specification]
        public void CanChangeImageFileExtension()
        {
            "Given I have a request which specifies a different file extension".Context(() =>
                {
                    _blitline = new BlitlineApi();
                    _request = new BlitlineRequest("a5KqkemeX2RttyYdkOrdug",
                                                   "https://s3-eu-west-1.amazonaws.com/gdoubleu-blitline/moi.jpg");

                    var cropFunction = new CropFunction(51, 126, 457 - 126, 382 - 51)
                                           {
                                               Save = new Save
                                                          {
                                                              ImageIdentifier = "image_identifier",
                                                              Extension = ".jpg"
                                                          }
                                           };

                    _request.AddFunction(cropFunction);
                });

            "When I process the request".Do(() => _response = _blitline.ProcessImages(_request));

            "Then the processed image should contain the new extension".Observation(() => Assert.Contains(".jpg", _response.Results.Images.First().S3Url));
        }
        
    }
}
