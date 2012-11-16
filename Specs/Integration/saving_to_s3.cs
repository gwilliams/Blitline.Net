using System;
using System.Linq;
using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Machine.Specifications;
using SubSpec;

namespace Specs.Integration
{
    public class SavingToS3
    {
        [Specification]
        public void CanSaveToS3Bucket()
        {
            var blitlineApi = default(BlitlineApi);
            var request = default(BlitlineRequest);
            var response = default(BlitlineResponse);
            var bucketName = default(string);

            "Given I have a blitline request with an s3 destination".Context(() =>
                {
                    var req = BuildA.Request()
                        .WithApplicationId("bqbTZJ-fe3sBFfJ2G0mKWw")
                        .WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/elevate-test-photos/gw%40elevatedirect.com-new.png"))
                        .WithCropFunction(f => f.WithDimensions(51, 126, 457 - 126, 382 - 51)
                            .SaveAs(s => s.WithImageIdentifier("image")
                                .WithExtension("jpg")
                                .WithQuality(75)
                                .WithS3Destination(ss => ss.WithBucketName("bucket")
                                    .WithKey("key")
                                    .Build())
                                .Build())
                            .Build())
                        .Build();
                    
                    bucketName = "elevate-test-photos";
                    blitlineApi = new BlitlineApi();
                    request = new BlitlineRequest();//"bqbTZJ-fe3sBFfJ2G0mKWw", "https://s3-eu-west-1.amazonaws.com/elevate-test-photos/gw%40elevatedirect.com-new.png");

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

                    request.AddFunction(cropFunction);

                });

            "When I process the request".Do(() => response = blitlineApi.ProcessImages(request));

            "Then the s3 url should not be empty".Observation(() => response.Results.Images.First().S3Url.ShouldNotBeEmpty());

            "And the s3 url should contain the bucket name".Observation(() => response.Results.Images.First().S3Url.ShouldContain(bucketName));
        }
    }
}
