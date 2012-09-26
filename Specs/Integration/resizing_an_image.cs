using System.Linq;
using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Machine.Specifications;

namespace Specs.Integration
{
    [Subject("Process an image")]
    public class resizing_an_image
    {
        static BlitlineApi _blitline;
        static BlitlineResponse _response;
        static BlitlineRequest _request;

        Establish context = () =>
        {
            _blitline = new BlitlineApi();
            _request = new BlitlineRequest("bqbTZJ-fe3sBFfJ2G0mKWw", "http://www.savethestudent.org/uploads/photobox.jpg");

            var resizeFunction = new ResizeToFitFunction(100,100)
            {
                Save = new Save
                {
                    ImageIdentifier = "image_identifier"
                }
            };

            _request.AddFunction(resizeFunction);

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
