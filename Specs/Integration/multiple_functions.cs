using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Machine.Specifications;

namespace Specs.Integration
{
    [Subject("Multiple functions")]
    public class multiple_functions
    {
        static BlitlineApi _blitline;
        static HttpClient _client;
        static BlitlineResponse _response;
        static BlitlineRequest _request;
        const string BucketName = "elevate-test-photos";

        Establish context = () =>
            {
                _blitline = new BlitlineApi();
                _request = new BlitlineRequest("bqbTZJ-fe3sBFfJ2G0mKWw", "https://s3-eu-west-1.amazonaws.com/elevate-test-photos/gw%40elevatedirect.com-new.png");

                var resizeFunction = new ResizeFunction(50, 50)
                                         {
                                             Functions = new List<BlitlineFunction>
                                                             {
                                                                 new CropFunction(51, 126, 457 - 126, 382 - 51)
                                                                     {
                                                                         Save = new Save
                                                                                    {
                                                                                        ImageIdentifier = "image_identifier",
                                                                                        S3Destination =
                                                                                            new S3Destination
                                                                                                {
                                                                                                    Bucket = "elevate-test-photos",
                                                                                                    Key = "crop_blitline.png"
                                                                                                }
                                                                                    }
                                                                     }
                                                             },
                                                             Save = new Save
                                                                        {
                                                                            ImageIdentifier = "resize_identifier",
                                                                            S3Destination = new S3Destination
                                                                                                {
                                                                                                    Bucket = "elevate-test-photos",
                                                                                                    Key = "crop_blitline.png"
                                                                                                }
                                                                        }
                                         };

                _request.AddFunction(resizeFunction);
            };

        Because of = () => _response = _blitline.ProcessImages(_request);

        It should_be_something = () =>
                                     {
                                         var x = 1;
                                     };

        
    }
}
