using System;
using System.Linq;
using Blitline.Net.Builders;
using Blitline.Net.Request;
using Blitline.Net.Response;
using SubSpec;
using Xunit;

namespace Specs.Integration
{
    public class SavingToS3
    {
        [Specification]
        public void CanSaveToS3Bucket()
        {
            var request = default(BlitlineRequest);
            var response = default(BlitlineResponse);
            var bucketName = default(string);

            "Given I have a blitline request with an s3 destination".Context(() =>
                {   
                    bucketName = "gdoubleu-test-photos";

                    request = BuildA.Request()
                                    .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                                    .WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-blitline/moi.jpg"))
                                    .WithCropFunction(f => f.WithDimensions(51, 126, 457 - 126, 382 - 51)
                                                            .SaveAs(s => s.WithImageIdentifier("image_identifier")
                                                                          .WithS3Destination(s3 => s3
                                                                                      .WithBucketName(bucketName)
                                                                                      .WithKey("blitline.png")
                                                                                      .Build())
                                                                           .Build())
                                                            .Build())
                                    .Build();
                });

            "When I process the request".Do(() => response = request.Send());

            "Then the s3 url should not be empty".Observation(() => Assert.NotEmpty(response.Results.Images.First().S3Url));

            "And the s3 url should contain the bucket name".Observation(() => Assert.Contains(bucketName, response.Results.Images.First().S3Url));
        }
    }
}
