using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net;
using Blitline.Net.Functions.Builders;

namespace TestApp
{
	public class MyFunction : BlitlineFunction
	{
		public int Age { get; set; }
		public override string Name {
			get {
				return "MyFunction";
			}
		}

		public override dynamic Params {
			get {
				return new {
					age = Age
				};
			}
		}
	}

	public class MyFunctionBuilder : FunctionBuilder<MyFunction>
	{
		public MyFunctionBuilder WithAge (int age)
		{
			BuildImp.Age = age;
			return this;
		}
	}

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
			                              .AddFunction<MyFunctionBuilder, MyFunction> (x => x.WithAge (123))
			                              .Crop (f => f.WithGravity(Blitline.Net.ParamOptions.Gravity.NorthGravity).SaveAs (s => s.WithImageIdentifier (imageIdentifier).ToS3 (s3 => s3.ToBucket (bucketName).WithKey ("annotate-default.png")))));

			var response = request.Send();
			Console.Read();
		}
	}
}
