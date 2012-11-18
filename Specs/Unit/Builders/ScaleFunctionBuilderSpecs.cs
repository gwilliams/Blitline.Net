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
            Assert.Throws<ArgumentException>(() => BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithScaleFunction(
                f => f.WithHeight(10).WithWidth(5).WithScaleFactor(0.4m).Build()).Build());
        }

        [Specification]
        public void CanBuildAScaleFunctionWithOnlyScaleFactor()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a scale function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithScaleFunction(f => f.WithScaleFactor(0.75m).Build()).Build());

            "Then the name should be scale".Observation(() => Assert.Equal("scale", request.Functions[0].Name));
            "And the width should be 0".Observation(() => Assert.Equal(0, ((ScaleFunction)request.Functions[0]).Width));
            "And the height should be 0".Observation(() => Assert.Equal(0, ((ScaleFunction)request.Functions[0]).Height));
            "And the scale factor should be 0.75".Observation(() => Assert.Equal(0.75m, ((ScaleFunction)request.Functions[0]).ScaleFactor));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(0, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(0, (int)t.GetProperty("height").GetValue(p, null));
                Assert.Equal(0.75m, (decimal)t.GetProperty("scale_factor").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAScaleFunctionWithOnlyWidthAndHeight()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a scale function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithScaleFunction(f => f.WithWidth(5).WithHeight(2).Build()).Build());

            "Then the name should be scale".Observation(() => Assert.Equal("scale", request.Functions[0].Name));
            "And the width should be 5".Observation(() => Assert.Equal(5, ((ScaleFunction)request.Functions[0]).Width));
            "And the height should be 2".Observation(() => Assert.Equal(2, ((ScaleFunction)request.Functions[0]).Height));
            "And the scale factor should be 0".Observation(() => Assert.Equal(0m, ((ScaleFunction)request.Functions[0]).ScaleFactor));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(2, (int)t.GetProperty("height").GetValue(p, null));
                Assert.Equal(0m, (decimal)t.GetProperty("scale_factor").GetValue(p, null));
            });
        }
    }
}
