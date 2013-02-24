using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class SketchFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildASketchFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a sketch function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Sketch(f => f.WithSigma(5m).WithRadius(2m).WithAngle(2m).Build()).Build());

            "Then the name should be sketch".Observation(() => Assert.Equal("sketch", request.Functions[0].Name));
            "And the sigma should be 5".Observation(() => Assert.Equal(5m, ((SketchFunction)request.Functions[0]).Sigma));
            "And the radius should be 2".Observation(() => Assert.Equal(2m, ((SketchFunction)request.Functions[0]).Radius));
            "And the angle should be 2".Observation(() => Assert.Equal(2m, ((SketchFunction)request.Functions[0]).Angle));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5m, (decimal)t.GetProperty("sigma").GetValue(p, null));
                Assert.Equal(2m, (decimal)t.GetProperty("radius").GetValue(p, null));
                Assert.Equal(2m, (decimal)t.GetProperty("angle").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildASketchFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a sketch function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Sketch(f => f.Build()).Build());

            "Then the name should be sketch".Observation(() => Assert.Equal("sketch", request.Functions[0].Name));
            "And the sigma should be 0".Observation(() => Assert.Equal(0m, ((SketchFunction)request.Functions[0]).Sigma));
            "And the radius should be 0".Observation(() => Assert.Equal(0m, ((SketchFunction)request.Functions[0]).Radius));
            "And the angle should be 0".Observation(() => Assert.Equal(0m, ((SketchFunction)request.Functions[0]).Angle));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(0m, (decimal)t.GetProperty("sigma").GetValue(p, null));
                Assert.Equal(0m, (decimal)t.GetProperty("radius").GetValue(p, null));
                Assert.Equal(0m, (decimal)t.GetProperty("angle").GetValue(p, null));
            });
        }
    }
}
