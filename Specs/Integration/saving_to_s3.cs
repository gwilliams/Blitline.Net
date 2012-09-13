using System.Linq;
using System.Net.Http;
using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Machine.Specifications;

namespace Specs.Integration
{
    [Subject("Saving to S3")]
    public class saving_to_s3
    {
        static BlitlineApi _blitline;
        static HttpClient _client;
        static BlitlineResponse _response;
        static BlitlineRequest _request;
        const string BucketName = "elevate-test-photos";

        Establish context = () =>
        {
            _client = new HttpClient();
            _blitline = new BlitlineApi(_client);
            _request = new BlitlineRequest("bqbTZJ-fe3sBFfJ2G0mKWw", "https://s3-eu-west-1.amazonaws.com/elevate-test-photos/gw%40elevatedirect.com-new.png");

            var cropFunction = new CropFunction(51, 126, 457 - 126, 382 - 51)
            {
                Save = new Save
                {
                    ImageIdentifier = "image_identifier",
                    S3Destination = new S3Destination
                                         {
                                             Bucket = "elevate-test-photos",
                                             Key = "blitline.png"
                                         }
                }
            };

            _request.AddFunction(cropFunction);

        };

        Because of = () => _response = _blitline.ProcessImages(_request);

        It response_should_contain_correct_s3_url = () =>
                                                        {
                                                            _response.Results.Images.First().S3Url.ShouldNotBeEmpty();
                                                            _response.Results.Images.First().S3Url.ShouldContain(BucketName);
                                                        };

    }
}
