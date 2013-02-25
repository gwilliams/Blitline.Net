using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
	public class ScaleFunctionBuilderSpecs
	{
		[Fact]
		public void CanNotBuildAScaleFunctionWithScaleFactorWidthAndHightSet()
		{
			Assert.Throws<ArgumentException>(() => BuildA.Request(r => r
				.WithApplicationId("123")
				.WithSourceImageUri(new Uri("http://foo.bar.gif"))
				.Scale(
				f => f.WithHeight(10).WithWidth(5).WithScaleFactor(0.4m))));
		}

		[Specification]
		public void CanBuildAScaleFunctionWithOnlyScaleFactor()
		{
			BlitlineRequest request = default(BlitlineRequest);

			"When I build a scale function".Context(() => request = BuildA.Request(r => r
				.WithApplicationId("123")
				.WithSourceImageUri(new Uri("http://foo.bar.gif"))
				.Scale(f => f.WithScaleFactor(0.75m))));

			"Then the name should be scale".Observation(() => Assert.Equal("scale", request.Functions[0].Name));
			"And the width should be 0".Observation(() => Assert.Equal(0, ((ScaleFunction)request.Functions[0]).Width));
			"And the height should be 0".Observation(() => Assert.Equal(0, ((ScaleFunction)request.Functions[0]).Height));
			"And the scale factor should be 0.75".Observation(() => Assert.Equal(0.75m, ((ScaleFunction)request.Functions[0]).ScaleFactor));

			"And the params should be constructed".Observation(() =>
			{
				var p = request.Functions[0].Params;
				Assert.Equal(0, p.width);
				Assert.Equal(0, p.height);
				Assert.Equal(0.75m, p.scale_factor);
			});
		}

		[Specification]
		public void CanBuildAScaleFunctionWithOnlyWidthAndHeight()
		{
			BlitlineRequest request = default(BlitlineRequest);

			"When I build a scale function".Context(() => request = BuildA.Request(r => r
				.WithApplicationId("123")
				.WithSourceImageUri(new Uri("http://foo.bar.gif"))
				.Scale(f => f.WithWidth(5).WithHeight(2))));

			"Then the name should be scale".Observation(() => Assert.Equal("scale", request.Functions[0].Name));
			"And the width should be 5".Observation(() => Assert.Equal(5, ((ScaleFunction)request.Functions[0]).Width));
			"And the height should be 2".Observation(() => Assert.Equal(2, ((ScaleFunction)request.Functions[0]).Height));
			"And the scale factor should be 0".Observation(() => Assert.Equal(0m, ((ScaleFunction)request.Functions[0]).ScaleFactor));

			"And the params should be constructed".Observation(() =>
			{
				var p = request.Functions[0].Params;

				Assert.Equal(5, p.width);
				Assert.Equal(2, p.height);
			});
		}
	}
}
