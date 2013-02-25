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

			"Given I have a scale function with only a scale factor".Context(() =>
				{
					const string bucketName = "gdoubleu-test-photos";

					request = BuildA.Request(r => r
								.WithApplicationId("a5KqkemeX2RttyYdkOrdug")
								.WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
								.Scale(f => f.WithScaleFactor(0.25m)
														.SaveAs(s => s.WithImageIdentifier("image_identifier")
																	  .ToS3(s3 => s3
																				  .ToBucket(bucketName)
																				  .WithKey("moi-scale-factor.png")))));
				});

			"When I process the request".Do(() => response = request.Send());

			"Then the s3 url should not be empty".Observation(() => Assert.NotEmpty(response.Results.Images.First().S3Url));
		}

		[Specification]
		public void CanProcessAScaleFunctionWithJustHeightAndWidth()
		{
			var request = default(BlitlineRequest);
			var response = default(BlitlineResponse);

			"Given I have a scale function with only a scale factor".Context(() =>
				{
					const string bucketName = "gdoubleu-test-photos";

					request = BuildA.Request(r => r
								.WithApplicationId("a5KqkemeX2RttyYdkOrdug")
								.WithSourceImageUri(new Uri("https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg"))
								.Scale(f => f.WithHeight(50).WithWidth(100)
														.SaveAs(s => s.WithImageIdentifier("image_identifier")
																	  .ToS3(s3 => s3
																				  .ToBucket(bucketName)
																				  .WithKey("moi-scale-heightwidth.png")))));
				});

			"When I process the request".Do(() => response = request.Send());

			"Then the s3 url should not be empty".Observation(() => Assert.NotEmpty(response.Results.Images.First().S3Url));
		}
	}
}
