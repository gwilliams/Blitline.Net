using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Machine.Specifications;
using RestSharp;
namespace Specs.Integration
{
    [Subject("Handling an error")]
    public class when_an_error_occurs
    {
        static BlitlineApi _blitline;
        static RestClient _client;
        static BlitlineResponse _response;
        static BlitlineRequest _request;

        Establish context = () =>
        {
            _client = new RestClient();
            _blitline = new BlitlineApi(_client);
            _request = new BlitlineRequest("some_crap_key", "https://s3-eu-west-1.amazonaws.com/elevate-test-photos/gw%40elevatedirect.com-new.png");

            var cropFunction = new CropFunction(51, 126, 457 - 126, 382 - 51)
            {
                save = new Save
                {
                    image_identifier = "image_identifier"
                }
            };

            _request.AddFunction(cropFunction);

        };

        Because of = () => _response = _blitline.ProcessImages(_request);

        It response_should_report_as_failed = () => _response.Failed.ShouldBeTrue();
        It response_should_contain_an_error = () => _response.Results.Error.ShouldNotBeEmpty();

    }
}
