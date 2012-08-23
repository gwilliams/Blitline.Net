using System.Linq;
using System.Net.Http;
using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Machine.Specifications;

namespace Specs.Integration
{
    [Subject("Process an image")]
    public class processing_an_image
    {
        static BlitlineApi _blitline;
        static HttpClient _client;
        static BlitlineResponse _response;
        static BlitlineRequest _request;

        Establish context = () =>
                                {
                                    _client = new HttpClient();
                                    _blitline = new BlitlineApi(_client);
                                    _request = new BlitlineRequest("bqbTZJ-fe3sBFfJ2G0mKWw", "https://s3-eu-west-1.amazonaws.com/elevate-test-photos/gw%40elevatedirect.com-new.png");

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

        It response_should_not_report_as_failed = () =>
            {
                _response.Failed.ShouldBeFalse();
            };
        It response_should_have_a_job_id = () => _response.Results.JobId.ShouldNotBeEmpty();

        It response_should_have_image_identifier = () => _response.Results.Images.First().ImageIdentifier.ShouldNotBeEmpty();

    }
}
