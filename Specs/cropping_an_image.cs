using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Machine.Specifications;
using RestSharp;

namespace Specs
{
    [Subject("Can Crop Image")]
    public class cropping_an_image
    {
        static BlitlineApi _blitline;
        static RestClient _client;
        static BlitlineResponse _response;
        static BlitlineRequest _request;

        Establish context = () =>
                                {
                                    _client = new RestClient();
                                    _blitline = new BlitlineApi(_client);
                                    _request = new BlitlineRequest("bqbTZJ-fe3sBFfJ2G0mKWw", "https://s3-eu-west-1.amazonaws.com/elevate-test-photos/gw%40elevatedirect.com-new.png");

                                    var cropFunction = new CropFunction(51, 126, 457 - 126, 382 - 51)
                                                           {
                                                               save = new Save
                                                                          {
                                                                              image_identifier = "profile",
                                                                              s3_destination = new S3Destination
                                                                                                   {
                                                                                                       bucket =
                                                                                                           "elevate-test-photos",
                                                                                                       key =
                                                                                                           "test_image.png"
                                                                                                   }
                                                                          }
                                                           };

                                    _request.AddFunction(cropFunction);

                                };

        Because of = () => _response = _blitline.ProcessImages(_request);

        It it_should_not_resport_as_failed = () => _response.Failed.ShouldBeFalse();
    }
}
