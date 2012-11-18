using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net.Builders;
using Blitline.Net.Request;
using Blitline.Net.Response;
using SubSpec;
using Xunit;

namespace Specs.Integration
{
    public class ProcessScaleFunction
    {
        [Specification]
        public void CanProcessAScaleFunctionWithJustScaleFactor()
        {
            var request = default(BlitlineRequest);
            var response = default(BlitlineResponse);
            var bucketName = default(string);

            "Given I have a scale function with only a scale factor".Context(() =>
            {
                bucketName = "gdoubleu-test-photos";

                request = BuildA.Request()
                                .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                                .WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
                                .WithScaleFunction(f => f.WithScaleFactor(0.25m)
                                                        .SaveAs(s => s.WithImageIdentifier("image_identifier")
                                                                      .WithS3Destination(s3 => s3
                                                                                  .WithBucketName(bucketName)
                                                                                  .WithKey("moi-scale-factor.png")
                                                                                  .Build())
                                                                       .Build())
                                                        .Build())
                                .Build();
            });

            "When I process the request".Do(() => response = request.Send());

            "Then the s3 url should not be empty".Observation(() => Assert.NotEmpty(response.Results.Images.First().S3Url));
        }

        [Specification]
        public void CanProcessAScaleFunctionWithJustHeightAndWidth()
        {
            var request = default(BlitlineRequest);
            var response = default(BlitlineResponse);
            var bucketName = default(string);

            "Given I have a scale function with only a scale factor".Context(() =>
            {
                bucketName = "gdoubleu-test-photos";

                request = BuildA.Request()
                                .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                                .WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
                                .WithScaleFunction(f => f.WithHeight(50).WithWidth(100)
                                                        .SaveAs(s => s.WithImageIdentifier("image_identifier")
                                                                      .WithS3Destination(s3 => s3
                                                                                  .WithBucketName(bucketName)
                                                                                  .WithKey("moi-scale-heightwidth.png")
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
