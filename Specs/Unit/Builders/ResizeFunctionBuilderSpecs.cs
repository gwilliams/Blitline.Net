using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class ResizeFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAResizeFunctionWithOnlyAScaleFactor()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a resize function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithResizeFunction(f => f.WithScaleFactor(0.2m).Build()).Build());

            "Then the name should be resize".Observation(() => Assert.Equal("resize", request.Functions[0].Name));
            "And the width should be 0".Observation(() => Assert.Equal(0, ((ResizeFunction)request.Functions[0]).Width));
            "And the height should be 0".Observation(() => Assert.Equal(0, ((ResizeFunction)request.Functions[0]).Height));
            "And the scale factor should be 0.2".Observation(() => Assert.Equal(0.2m, ((ResizeFunction)request.Functions[0]).ScaleFactor));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(0, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(0, (int) t.GetProperty("height").GetValue(p, null));
                Assert.Equal(0.2m, (decimal)t.GetProperty("scale_factor").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAResizeFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a resize function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithResizeFunction(f => f.WithWidth(5).WithHeight(2).Build()).Build());

            "Then the name should be resize".Observation(() => Assert.Equal("resize", request.Functions[0].Name));
            "And the width should be 5".Observation(() => Assert.Equal(5, ((ResizeFunction)request.Functions[0]).Width));
            "And the height should be 2".Observation(() => Assert.Equal(2, ((ResizeFunction)request.Functions[0]).Height));
            "And the scale factor should be 0".Observation(() => Assert.Equal(0m, ((ResizeFunction)request.Functions[0]).ScaleFactor));

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
