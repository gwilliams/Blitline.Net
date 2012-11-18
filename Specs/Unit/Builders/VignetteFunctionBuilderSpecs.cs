using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class VignetteFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAVignetteFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a vignette function".Context(() => request = BuildA.Request()
                .WithVignetteFunction(f => f.WithColour("ccc").WithX(2).WithY(3)
                    .WithThreshold(3m).WithSigma(4m).WithRadius(5m).Build()).Build());

            "Then the name should be vignette".Observation(() => Assert.Equal("vignette", request.Functions[0].Name));

            "And the colour should be ccc".Observation(() => Assert.Equal("ccc", ((VignetteFunction)request.Functions[0]).Colour));
            "And x should be 2".Observation(() => Assert.Equal(2, ((VignetteFunction)request.Functions[0]).X));
            "And y should be 3".Observation(() => Assert.Equal(3, ((VignetteFunction)request.Functions[0]).Y));
            "And the threshold should be 3".Observation(() => Assert.Equal(3m, ((VignetteFunction)request.Functions[0]).Threshold));
            "And the sigma should be 4".Observation(() => Assert.Equal(4m, ((VignetteFunction)request.Functions[0]).Sigma));
            "And the radius should be 5".Observation(() => Assert.Equal(5m, ((VignetteFunction)request.Functions[0]).Radius));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal("ccc", t.GetProperty("color").GetValue(p, null).ToString());
                Assert.Equal(2, (int)t.GetProperty("x").GetValue(p, null));
                Assert.Equal(3, (int)t.GetProperty("y").GetValue(p, null));
                Assert.Equal(3m, (decimal)t.GetProperty("threshold").GetValue(p, null));
                Assert.Equal(4m, (decimal)t.GetProperty("sigma").GetValue(p, null));
                Assert.Equal(5m, (decimal)t.GetProperty("radius").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAVignetteFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a vignette function".Context(() => request = BuildA.Request()
                .WithVignetteFunction(f => f.Build()).Build());

            "Then the name should be vignette".Observation(() => Assert.Equal("vignette", request.Functions[0].Name));

            "And the colour should be #000000".Observation(() => Assert.Equal("#000000", ((VignetteFunction)request.Functions[0]).Colour));
            "And x should be 10".Observation(() => Assert.Equal(10, ((VignetteFunction)request.Functions[0]).X));
            "And y should be 10".Observation(() => Assert.Equal(10, ((VignetteFunction)request.Functions[0]).Y));
            "And the threshold should be 0.05".Observation(() => Assert.Equal(0.05m, ((VignetteFunction)request.Functions[0]).Threshold));
            "And the sigma should be 10".Observation(() => Assert.Equal(10m, ((VignetteFunction)request.Functions[0]).Sigma));
            "And the radius should be 0".Observation(() => Assert.Equal(0m, ((VignetteFunction)request.Functions[0]).Radius));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal("#000000", t.GetProperty("color").GetValue(p, null).ToString());
                Assert.Equal(10, (int)t.GetProperty("x").GetValue(p, null));
                Assert.Equal(10, (int)t.GetProperty("y").GetValue(p, null));
                Assert.Equal(0.05m, (decimal)t.GetProperty("threshold").GetValue(p, null));
                Assert.Equal(10m, (decimal)t.GetProperty("sigma").GetValue(p, null));
                Assert.Equal(0m, (decimal)t.GetProperty("radius").GetValue(p, null));
            });
        }
    }
}
