using System;
using System.Collections.Generic;
using System.Linq;
using Blitline.Net.Builders;
using Blitline.Net.Request;
using Blitline.Net.Response;
using SubSpec;
using Xunit;

namespace Specs.Integration
{
    public class ProcessMultipleImages
    {
        BlitlineBatchResponse _response = default(BlitlineBatchResponse);
        BlitlineRequest[] _requests = default(BlitlineRequest[]);

        [Specification]
        public void CanProcessMultipleImages()
        {
            "Given I have multiple images to process".Context(() =>
            {
                var bucketName = "gdoubleu-test-photos";
                _requests = new List<BlitlineRequest>
                                {
                                    BuildA.Request()
                                        .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                                        .WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
                                        .WithScaleFunction(f => f.WithHeight(50).WithWidth(100)
                                                                .SaveAs(s => s.WithImageIdentifier("first_image")
                                                                              .WithS3Destination(s3 => s3
                                                                                          .WithBucketName(bucketName)
                                                                                          .WithKey("multi-1.png")
                                                                                          .Build())
                                                                               .Build())
                                                                .Build())
                                        .Build(),
                                    BuildA.Request()
                                        .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                                        .WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
                                        .WithScaleFunction(f => f.WithHeight(50).WithWidth(100)
                                                                .SaveAs(s => s.WithImageIdentifier("second_image")
                                                                              .WithS3Destination(s3 => s3
                                                                                          .WithBucketName(bucketName)
                                                                                          .WithKey("multi-2.png")
                                                                                          .Build())
                                                                               .Build())
                                                                .Build())
                                        .Build()
                                }.ToArray();
            });

            "When I process the request".Do(() => _response = _requests.Send());

            "Then there should be 2 results".Observation(() => Assert.Equal(2, _response.Results.Count()));
        }
    }
}
