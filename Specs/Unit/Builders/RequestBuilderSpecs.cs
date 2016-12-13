using System;
using System.Collections.Generic;
using System.Linq;
using Blitline.Net;
using Blitline.Net.Builders;
using Blitline.Net.ParamOptions;
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

            "When I build a request".Context(() => request = BuildA.Request(r => r
                                                              .WithApplicationId("123")
                                                              .FixS3ImageUrl()
                                                              .ContentTypeAsJson()
                                                              .SuppressAutoOrientation()
                                                              .WithPostbackUri(new Uri("http://www.bar.com/"))
                                                              .WithExtendedMetaData()
                                                              .WithHash(Hash.Md5)
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .SourceIsScreenshot()
                                                              .Crop(f => f.WithDimensions(1,2,3,4))));

            "Then the request is not null".Observation(() => Assert.NotNull(request));

            "And the application id is 123".Observation(() => Assert.Equal("123", request.ApplicationId));

            "And the source image is http://www.foo.com/bar.gif".Observation(() => Assert.Equal("http://www.foo.com/bar.gif", request.SourceImage));

            "And content type as json is true".Observation(() => Assert.True(request.ContentTypeJson));

            "And supress auto orientation is true".Observation(() => Assert.True(request.SuppressAutoOrient));

            "And the postback url is http://postback.com".Observation(() => Assert.Equal("http://www.bar.com/", request.PostbackUrl));

            "And extended meta data is true".Observation(() => Assert.True(request.ExtendedMetaData));

            "And the hash is Md5".Observation(() => Assert.Equal(Hash.Md5, request.Hash));

            "And the source type is screen_shot_url".Observation(() => Assert.Equal("screen_shot_url", request.SourceType));

            "And there is 1 function".Observation(() => Assert.Equal(1, request.Functions.Count));

            "And UseHttps is false".Observation(() => Assert.False(request.UseHttps));
        }

        [Specification]
        public void CanBuildARequestUsingHttps()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request with sub functions".Context(() => request = BuildA.Request(r => r
                                                              .WithApplicationId("123")
                                                              .UseHttps()
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .Crop(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .Deskew(d => d.WithThreshold(0.2m)))));

            "Then UseHttps is true".Observation(() => Assert.True(request.UseHttps));
        }

        [Specification]
        public void CanBuildARequestWithSubFunctions()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request with sub functions".Context(() => request = BuildA.Request(r => r
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .Crop(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .Deskew(d => d.WithThreshold(0.2m)))));

            "Then the primary function has 1 sub-function".Observation(
                () => Assert.Equal(1, request.Functions.First().Functions.Count));
        }

        [Specification]
        public void CanBuildARequestWithSaveData()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request".Context(() => request = BuildA.Request(r => r
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .Crop(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .SaveAs(s => s.WithImageIdentifier("image")
                                                                      .WithExtension(Extension.PNG)
                                                                      .WithQuality(10)
                                                                      .QuantizePng()
                                                                      .WithInterlaceType(InterlaceType.LineInterlace)))));

            "Then the function has a save value".Observation(() => Assert.NotNull(request.Functions.First().Save));

            "And the image identifier is image".Observation(() => Assert.Equal("image", request.Functions.First().Save.ImageIdentifier));

            "And the quality is 10".Observation(() => Assert.Equal(10, request.Functions.First().Save.Quality));

            "And quantize png is true".Observation(() => Assert.True(request.Functions[0].Save.PngQuantize));

            "And the interlace type is LineInterlace".Observation(() => Assert.Equal("LineInterlace", request.Functions[0].Save.Interlace));
        }

        [Specification]
        public void CanBuildARequestWithAnS3Destination()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request".Context(() => request = BuildA.Request(r => r
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .Crop(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .SaveAs(s => s.WithImageIdentifier("image")
                                                                      .WithExtension(Extension.PNG)
                                                                      .WithQuality(10)
                                                                      .ToS3(s3 => s3.ToBucket("Bucket")
                                                                        .WithKey("Key")
                                                                        .WithHeader("1","foo")
                                                                        .WithHeaders(new Dictionary<string, string>{{"2","bar"}}))))));

            "Then save contains an s3 destination".Observation(() => Assert.NotNull(request.Functions.First().Save.S3Destination));

            "And the bucket name is Bucket".Observation(() => Assert.Equal("Bucket", request.Functions.First().Save.S3Destination.Bucket));

            "And the key is Key".Observation(() => Assert.Equal("Key", request.Functions.First().Save.S3Destination.Key));

            "And there are 2 headers".Observation(() => Assert.Equal(2, request.Functions.First().Save.S3Destination.Headers.Count));

            "And the first header is foo".Observation(() => Assert.Equal("foo", request.Functions.First().Save.S3Destination.Headers.First().Value));

            "And the second header is bar".Observation(() => Assert.Equal("bar", request.Functions.First().Save.S3Destination.Headers.Last().Value));
        }

        [Specification]
        public void CanBuildARequestWithAnAzureDestination()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                .Crop(c => c.WithDimensions(1, 2, 3, 4)
                    .SaveAs(s => s.WithImageIdentifier("image")
                    .WithExtension(Extension.PNG)
                    .WithQuality(10)
                    .ToAzure(f => f.WithAccountName("azureaccount")
                        .WithSharedAccessSignature("sharedaccesssignature")
                        )
                    )
                )));

            "Then save contains an azure destination".Observation(() => Assert.NotNull(request.Functions.First().Save.AzureDestination));

            "And the account name should be azureaccount".Observation(() => Assert.Equal("azureaccount", request.Functions.First().Save.AzureDestination.AccountName));

            "And the shared access signature should be sharedaccesssignature".Observation(() => Assert.Equal("sharedaccesssignature", request.Functions.First().Save.AzureDestination.SharedAccessSignature));
        }

        [Specification]
        public void CanBuildARequestWithAnFtpDestination()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                .Crop(c => c.WithDimensions(1, 2, 3, 4)
                    .SaveAs(s => s.WithImageIdentifier("image")
                    .WithExtension(Extension.PNG)
                    .WithQuality(10)
                    .ToFtp(f => f.WithServer("ftp://ftp.foo.com")
                        .WithUser("bob")
                        .WithPassword("smith")
                        .WithFileName("bar.gif")
                        .WithDirectory("/images"))
                        )
                    )
                ));

            "Then the save contains an ftp destination".Observation(() => Assert.NotNull(request.Functions.First().Save.FtpDestination));

            "And the ftp server is ftp://ftp.foo.com".Observation(() => Assert.Equal("ftp://ftp.foo.com", request.Functions.First().Save.FtpDestination.Server));

            "And the ftp user is bob".Observation(() => Assert.Equal("bob", request.Functions.First().Save.FtpDestination.User));

            "And the ftp password is smith".Observation(() => Assert.Equal("smith", request.Functions.First().Save.FtpDestination.Password));

            "And the ftp filename is bar.gif".Observation(() => Assert.Equal("bar.gif", request.Functions.First().Save.FtpDestination.FileName));

            "And the ftp directory is /images".Observation(() => Assert.Equal("/images", request.Functions.First().Save.FtpDestination.Directory));
        }
        
        [Specification]
        public void CanBuildAMultipageRequest()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a multipage request".Context(() => request = BuildA.Request(r => r
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .SourceIsMultipageDocument()
                                                              .Crop(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .SaveAs(s => s.WithImageIdentifier("image")
                                                                      .WithExtension(Extension.PNG)
                                                                      .WithQuality(10)
                                                                      .ToS3(s3 => s3.ToBucket("Bucket")
                                                                        .WithKey("Key")
                                                                        .WithHeader("1", "foo")
                                                                        .WithHeaders(new Dictionary<string, string> { { "2", "bar" } }))))));

            "Then source type is multipage".Observation(() => Assert.Equal("multi_page", request.SourceType));
        }

        [Specification]
        public void CanBuildAMultipageWithSpecificPagesRequest()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a multipage with page numbers request".Context(() => request = BuildA.Request(r => r
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .SourceIsMultipageDocument(new[]{1,3})
                                                              .Crop(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .SaveAs(s => s.WithImageIdentifier("image")
                                                                      .WithExtension(Extension.PNG)
                                                                      .WithQuality(10)
                                                                      .ToS3(s3 => s3.ToBucket("Bucket")
                                                                        .WithKey("Key")
                                                                        .WithHeader("1", "foo")
                                                                        .WithHeaders(new Dictionary<string, string> { { "2", "bar" } }))))));

            "Then source type is multipage".Observation(() => Assert.Equal("multi_page", request.SourceType.Name));

            "And there are 2 pages".Observation(() => Assert.Equal(2, request.SourceType.Pages.Length));

            "And the 1st page is 1".Observation(() => Assert.Equal(1, request.SourceType.Pages[0]));

            "And the 1st page is 3".Observation(() => Assert.Equal(3, request.SourceType.Pages[1]));
        }

        [Specification]
        public void CanBuildARequestWithoutSourceType()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a request without source type".Context(() => request = BuildA.Request(r => r
                                                              .WithApplicationId("123")
                                                              .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                                                              .Crop(f => f.WithDimensions(1, 2, 3, 4)
                                                                  .SaveAs(s => s.WithImageIdentifier("image")
                                                                      .WithExtension(Extension.PNG)
                                                                      .WithQuality(10)
                                                                      .ToS3(s3 => s3.ToBucket("Bucket")
                                                                        .WithKey("Key")
                                                                        .WithHeader("1", "foo")
                                                                        .WithHeaders(new Dictionary<string, string> { { "2", "bar" } }))))));

            "Then source type is null".Observation(() => Assert.Null(request.SourceType));
        }

        [Fact]
        public void CannotBuildARequestWithS3AndAzureSaveDestinations()
        {
            Assert.Throws<NotSupportedException>(() => BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                .Crop(f => f.WithDimensions(1, 2, 3, 4)
                .SaveAs(s => s.WithImageIdentifier("image")
                    .WithExtension(Extension.PNG)
                    .WithQuality(10)
                    .ToS3(s3 => s3.ToBucket("Bucket")
                        .WithKey("Key")
                        .WithHeader("1", "foo")
                        .WithHeaders(new Dictionary<string, string> { { "2", "bar" } }))
                    .ToAzure(a => a
                        .WithAccountName("azureAccount")
                        .WithSharedAccessSignature("sharedkey"))))));
        }

        [Fact]
        public void CannotBuildARequestWithS3AndFtpSaveDestinations()
        {
            Assert.Throws<NotSupportedException>(() => BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                .Crop(f => f.WithDimensions(1, 2, 3, 4)
                .SaveAs(s => s.WithImageIdentifier("image")
                    .WithExtension(Extension.PNG)
                    .WithQuality(10)
                    .ToS3(s3 => s3.ToBucket("Bucket")
                        .WithKey("Key")
                        .WithHeader("1", "foo")
                        .WithHeaders(new Dictionary<string, string> { { "2", "bar" } }))
                    .ToFtp(a => a
                        .WithDirectory("directory")
                        .WithFileName("filename")
                        .WithPassword("password")
                        .WithServer("server")
                        .WithUser("user"))))));
        }

        [Fact]
        public void CannotBuildARequestWithAzureAndFtpSaveDestinations()
        {
            Assert.Throws<NotSupportedException>(() => BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                .Crop(f => f.WithDimensions(1, 2, 3, 4)
                .SaveAs(s => s.WithImageIdentifier("image")
                    .WithExtension(Extension.PNG)
                    .WithQuality(10)
                    .ToAzure(a => a
                        .WithAccountName("azureAccount")
                        .WithSharedAccessSignature("sharedkey"))
                    .ToFtp(a => a
                        .WithDirectory("directory")
                        .WithFileName("filename")
                        .WithPassword("password")
                        .WithServer("server")
                        .WithUser("user"))))));
        }

        [Fact]
        public void CannotBuildARequestWithoutASaveImageIdentifier()
        {
            Assert.Throws<ArgumentNullException>(() => BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://www.foo.com/bar.gif"))
                .Crop(f => f.WithDimensions(1, 2, 3, 4)
                .SaveAs(s => s
                    .WithExtension(Extension.PNG)
                    .WithQuality(10)
                    .ToAzure(a => a
                        .WithAccountName("azureAccount")
                        .WithSharedAccessSignature("sharedkey"))
                    .ToFtp(a => a
                        .WithDirectory("directory")
                        .WithFileName("filename")
                        .WithPassword("password")
                        .WithServer("server")
                        .WithUser("user"))))));
        }
    }
}
