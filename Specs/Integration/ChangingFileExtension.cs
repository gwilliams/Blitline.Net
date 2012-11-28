using System;
using System.Linq;
using Blitline.Net;
using Blitline.Net.Builders;
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
                    _request = BuildA.Request()
                                     .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                                     .WithSourceImageUri(
                                         new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
                                     .WithCropFunction(f => f.WithDimensions(51, 126, 457 - 126, 382 - 51)
                                                             .SaveAs(
                                                                 s =>
                                                                 s.WithImageIdentifier("file_extension")
                                                                  .WithExtension(Extension.Png)
                                                                  .Build())
                                                             .Build())
                                     .Build();
                });

            "When I process the request".Do(() => _response = _request.Send());

            "Then the processed image should contain the new extension".Observation(() => Assert.Contains(".png", _response.Results.Images.First().S3Url));
        }
        
    }
}
