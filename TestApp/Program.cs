using System;
using Blitline.Net.Builders;
using Blitline.Net.Request;

namespace TestApp
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			const string applicationKey = "a5KqkemeX2RttyYdkOrdug";
			const string bucketName = "gdoubleu-test-photos";
			const string sourceImage = "https://s3-eu-west-1.amazonaws.com/gdoubleu-test-photos/moi.jpg";
			const string imageIdentifier = "foo.png";

			var request = BuildA.Request (r => r
										  .WithApplicationId (applicationKey)
										  .WithSourceImageUri (new Uri (sourceImage))

			                              .Crop (f => f.WithGravity(Blitline.Net.ParamOptions.Gravity.NorthGravity).SaveAs (s => s.WithImageIdentifier (imageIdentifier).ToS3 (s3 => s3.ToBucket (bucketName).WithKey ("annotate-default.png")))));

			var response = request.Send();
			Console.Read();
		}
	}
}
