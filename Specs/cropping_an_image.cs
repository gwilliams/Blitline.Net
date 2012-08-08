using Blitline.Net;
using Blitline.Net.Functions;
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
                                    _request = new BlitlineRequest("SOME_API_KEY", "https://www.google.co.uk/intl/en_ALL/images/logos/images_logo_lg.gif");

                                    var cropFunction = new CropFunction(155, 250, 240, 140)
                                                           {
                                                               save = new Save
                                                                          {
                                                                              image_identifier = "test_image"
                                                                          }
                                                           };
                                    _request.AddFunction(cropFunction);

                                };

        Because of = () => _response = _blitline.ProcessImages(_request);

        It it_should_not_resport_as_failed = () => _response.Failed.ShouldBeFalse();
    }
}
