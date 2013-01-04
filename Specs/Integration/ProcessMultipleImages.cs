using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net;
using Blitline.Net.Builders;
using Blitline.Net.Request;
using Blitline.Net.Response;
using SubSpec;
using Xunit;

namespace Specs.Integration
{
    public class ProcessMultipleImages
    {
        BlitlineApi _blitline = default(BlitlineApi);
        BlitlineResponse _response = default(BlitlineResponse);
        BlitlineRequest[] _requests = default(BlitlineRequest[]);

        [Specification]
        public void CanProcessMultipleImages()
        {
            "Given I have multiple images to process".Context(() =>
            {
                var bucketName = "gdoubleu-test-photos";
                _blitline = new BlitlineApi();
                _requests = new List<BlitlineRequest>
                                {
                                    BuildA.Request()
                                        .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                                        .WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
                                        .WithScaleFunction(f => f.WithHeight(50).WithWidth(100)
                                                                .SaveAs(s => s.WithImageIdentifier("image_identifier")
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
                                                                .SaveAs(s => s.WithImageIdentifier("image_identifier")
                                                                              .WithS3Destination(s3 => s3
                                                                                          .WithBucketName(bucketName)
                                                                                          .WithKey("multi-2.png")
                                                                                          .Build())
                                                                               .Build())
                                                                .Build())
                                        .Build()
                                }.ToArray();
            });

            "When I process the request".Do(() => _response = _blitline.ProcessImages(_requests));

            "Then the processed image should contain the new extension".Observation(() => Assert.Contains(".png", _response.Results.Images.First().S3Url));
        }
    }
}
