using System.Collections.Generic;
using Blitline.Net.Request;
using Blitline.Net.Response;
using SubSpec;
using Xunit;

namespace Specs.Unit
{
    public class BlitlineResponseSpecs
    {
        [Specification]
        public void CanFixS3Urls()
        {
            BlitlineResponse _response = default(BlitlineResponse);
            BlitlineRequest _request = default(BlitlineRequest);
            Dictionary<string, string> _imageKeyBucketList = default(Dictionary<string, string>);

            "Given I have a blitline response with incorrect s3 urls".Context(() =>
                {
                    _response = new BlitlineResponse
                                    {
                                        Results = new Results
                                                      {
                                                          Images = new List<Image>
                                                                       {
                                                                           new Image
                                                                               {
                                                                                   ImageIdentifier = "image",
                                                                                   S3Url =
                                                                                       "http://s3.amazonaws.com/gdoubleu-test-photos/annotate-default.png"
                                                                               }
                                                                       }
                                                      }
                                    };
                    _request = new BlitlineRequest
                                   {
                                       FixS3ImageUrl = true,
                                   };

                    _imageKeyBucketList = new Dictionary<string, string>
                                              {
                                                  {"annotate-default","gdoubleu-test-photos"}
                                              };
                });

            "When I fix the urls".Do(() => _response.FixS3Urls(_imageKeyBucketList));

            "Then the url is correct".Observation(() => Assert.Equal("http://gdoubleu-test-photos.s3.amazonaws.com/annotate-default.png", _response.Results.Images[0].S3Url));
        }
    }
}
