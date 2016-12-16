using System;
using System.Linq;
using Blitline.Net.Builders;
using Blitline.Net.ParamOptions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using SubSpec;
using Xunit;

namespace Specs.Integration
{
    public class ProcessAnnotateFunction
    {
        [Fact]
        public async void CanProcessAnnotationFunctionAsync()
        {
            const string bucketName = "gdoubleu-test-photos";
            
            var request = BuildA.Request(r => r
                        .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                        .WithSourceImageUri(
                            new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
                        .Annotate(f => f.WithText("Hello")
                                            .SaveAs(s => s.WithImageIdentifier("image_identifier")
                                                            .ToS3(s3 => s3
                                                                        .ToBucket(bucketName)
                                                                        .WithKey("annotate-default.png")))));

            var task =  request.SendAsync();

            var foo = await task;

            Console.WriteLine(foo.Results.JobId);
        }

        [Specification]
        public void CanProcessAnAnnotateFunctionWithOnlyRequiredValues()
        {
            var request = default(BlitlineRequest);
            var response = default(BlitlineResponse);

	        "Given I have a annotate function".Context(() =>
		        {
			        const string bucketName = "gdoubleu-test-photos";

			        request = BuildA.Request(r => r
	                            .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
	                            .WithSourceImageUri(
		                            new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
	                            .Annotate(f => f.WithText("Hello")
													.SaveAs(s => s.WithImageIdentifier("image_identifier")
																	.ToS3(s3 => s3
																				.ToBucket(bucketName)
																				.WithKey("annotate-default.png")))));
		        });

            "When I process the request".Do(() => response = request.Send());

            "Then the s3 url should not be empty".Observation(() => Assert.NotEmpty(response.Results.Images.First().S3Url));

            "And there should be no error reported".Observation(() => Assert.Null(response.Results.Error));
        }

        [Specification]
        public void CanProcessAnAnnotateFunction()
        {
            var request = default(BlitlineRequest);
            var response = default(BlitlineResponse);

	        "Given I have a annotate function".Context(() =>
		        {
			        const string bucketName = "gdoubleu-test-photos";

			        request = BuildA.Request(r => r
                                .WithApplicationId("a5KqkemeX2RttyYdkOrdug")
                                .WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
                                .Annotate(f => f.WithText("Hello")
                                    .WithColour("#FFF000")
                                    .WithPointSize(48)
                                    .WithFontFamilty("Arial")
                                    .WithGravity(Gravity.NorthEastGravity)
                                                        .SaveAs(s => s.WithImageIdentifier("image_identifier")
                                                                      .ToS3(s3 => s3
                                                                                  .ToBucket(bucketName)
                                                                                  .WithKey("annotate-full.png")))));
		        });

            "When I process the request".Do(() => response = request.Send());

            "Then the s3 url should not be empty".Observation(() => Assert.NotEmpty(response.Results.Images.First().S3Url));

            "And there should be no error reported".Observation(() => Assert.Null(response.Results.Error));
        }
    }
}
