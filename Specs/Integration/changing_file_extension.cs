using System.Linq;
using System.Net.Http;
using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Machine.Specifications;

namespace Specs.Integration
{
    [Subject("Changing file extension")]
    public class changing_file_extension
    {
        static BlitlineApi _blitline;
        static HttpClient _client;
        static BlitlineResponse _response;
        static BlitlineRequest _request;

        Establish context = () =>
        {
            _blitline = new BlitlineApi();
            _request = new BlitlineRequest();//"bqbTZJ-fe3sBFfJ2G0mKWw", "https://s3-eu-west-1.amazonaws.com/elevate-test-photos/gw%40elevatedirect.com-new.png");

            var cropFunction = new CropFunction(51, 126, 457 - 126, 382 - 51)
            {
                Save = new Save
                {
                    ImageIdentifier = "image_identifier",
                    Extension = ".jpg"
                }
            };

            _request.AddFunction(cropFunction);

        };

        Because of = () => _response = _blitline.ProcessImages(_request);

        It should_return_correct_file_extension = () => _response.Results.Images.First().S3Url.ShouldContain(".jpg");
    }
}
