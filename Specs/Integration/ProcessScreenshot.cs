using System;
using System.Linq;
using Blitline.Net.Builders;
using Blitline.Net.Request;
using Blitline.Net.Response;
using SubSpec;
using Xunit;

namespace Specs.Integration
{
    public class ProcessScreenshot
    {
        [Specification]
        public void CanSaveToS3Bucket()
        {
            var request = default(BlitlineRequest);
            var response = default(BlitlineResponse);

            "Given I have a screenshot request".Context(() =>
                                                            {
                                                                const string bucketName = "gdoubleu-test-photos";

                                                                request = BuildA.Request()
                                .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                                .WithSourceImageUri(new Uri("http://www.google.co.uk"))
                                .SourceIsScreenshot()
                                .WithCropFunction(f => f.WithDimensions(51, 126, 457 - 126, 382 - 51)
                                                        .SaveAs(s => s.WithImageIdentifier("image_identifier")
                                                                      .WithS3Destination(s3 => s3
                                                                                  .WithBucketName(bucketName)
                                                                                  .WithKey("screenshot.png")
                                                                                  .Build())
                                                                       .Build())
                                                        .Build())
                                .Build();
                                                            });

            "When I process the request".Do(() => response = request.Send());

            "Then the s3 url should not be empty".Observation(() => Assert.NotEmpty(response.Results.Images.First().S3Url));
        } 
    }
}