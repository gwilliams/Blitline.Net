using System;
using System.Linq;
using Blitline.Net.Builders;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class RequestBuilderSpecs
    {
        [Specification]
        public void CanBuildARequest()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request".Context(() => request = BuildA.Request()
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .WithPostbackUri(new Uri("http://www.bar.com/"))
                                                              .WaitForS3()
                                                              .SuppressAutoOrientation()
                                                              .WithHash(Hash.Md5)
                                                              .WithCropFunction(f => f.WithDimensions(1,2,3,4).Build())
                                                              .Build());

            "Then the request is not null".Observation(() => Assert.NotNull(request));

            "And the application id is 123".Observation(() => Assert.Equal("123", request.ApplicationId));

            "And the source image is http://www.foo.com/bar.gif".Observation(() => Assert.Equal("http://www.foo.com/bar.gif", request.SourceImage));

            "And the postback uri is http://www.bar.com/".Observation(() => Assert.Equal("http://www.bar.com/", request.PostbackUrl));

            "And wait for s3 is true".Observation(() => Assert.True(request.WaitForS3));

            "And suppress auto orientation is true".Observation(() => Assert.True(request.SuppressAutoOrient));

            "And the hash should be md5".Observation(() => Assert.Equal(Hash.Md5, request.Hash));

            "And there is 1 function".Observation(() => Assert.Equal(1, request.Functions.Count));
        }

        [Specification]
        public void CanBuildARequestWithSubFunctions()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request with sub functions".Context(() => request = BuildA.Request()
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .WithCropFunction(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .WithDeskewFunction(r => r.WithThreshold(0.2m).Build())
                                                                  .Build())
                                                              .Build());

            "Then the primary function has 1 sub-function".Observation(
                () => Assert.Equal(1, request.Functions.First().Functions.Count));
        }

        [Specification]
        public void CanBuildARequestWithSaveData()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request".Context(() => request = BuildA.Request()
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .WithCropFunction(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .SaveAs(s => s.WithImageIdentifier("image")
                                                                      .WithExtension("png")
                                                                      .WithQuality(10)
                                                                      .Build())
                                                                  .Build())
                                                              .Build());

            "Then the function has a save value".Observation(() => Assert.NotNull(request.Functions.First().Save));

            "And the image identifier is image".Observation(() => Assert.Equal("image", request.Functions.First().Save.ImageIdentifier));

            "And the quality is 10".Observation(() => Assert.Equal(10, request.Functions.First().Save.Quality));
        }

        [Specification]
        public void CanBuildARequestWithAnS3Destination()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request".Context(() => request = BuildA.Request()
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .WithCropFunction(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .SaveAs(s => s.WithImageIdentifier("image")
                                                                      .WithExtension("png")
                                                                      .WithQuality(10)
                                                                      .WithS3Destination(s3 => s3.WithBucketName("Bucket")
                                                                        .WithKey("Key")
                                                                        .Build())
                                                                      .Build())
                                                                  .Build())
                                                              .Build());

            "Then save contains an s3 destination".Observation(() => Assert.NotNull(request.Functions.First().Save.S3Destination));

            "And the bucket name is Bucket".Observation(() => Assert.Equal("Bucket", request.Functions.First().Save.S3Destination.Bucket));

            "And the key is Key".Observation(() => Assert.Equal("Key", request.Functions.First().Save.S3Destination.Key));
        }
    }
}
