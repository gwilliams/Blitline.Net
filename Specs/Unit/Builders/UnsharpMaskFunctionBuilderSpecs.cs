using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class UnsharpMaskFunctionBuilderSpecs
    {
        [Fact]
        public void CanNotBuildAnUnsharpMaskFunctionWhenAmountOutOfBounds()
        {
            Assert.Throws<ArgumentException>(() => BuildA.Request().WithUnsharpMaskFunction(
                f => f.WithAmount(1.1m).WithThreshold(0.1m).Build()).Build());
        }

        [Fact]
        public void CanNotBuildAnUnsharpMaskFunctionWhenThresholdOutOfBounds()
        {
            Assert.Throws<ArgumentException>(() => BuildA.Request().WithUnsharpMaskFunction(
                f => f.WithAmount(0.1m).WithThreshold(1.1m).Build()).Build());
        }

        [Specification]
        public void CanBuildAnUnsharpMaskFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a unsharp mask function".Context(() => request = BuildA.Request()
                .WithUnsharpMaskFunction(f => f.WithSigma(5m).WithRadius(4m).WithAmount(0.3m).WithThreshold(0.2m).Build()).Build());

            "Then the name should be unsharp_mask".Observation(() => Assert.Equal("unsharp_mask", request.Functions[0].Name));
            "And the sigma should be 5".Observation(() => Assert.Equal(5m, ((UnsharpMaskFunction)request.Functions[0]).Sigma));
            "And the radius should be 4".Observation(() => Assert.Equal(4m, ((UnsharpMaskFunction)request.Functions[0]).Radius));
            "And the amount should be 0.3".Observation(() => Assert.Equal(0.3m, ((UnsharpMaskFunction)request.Functions[0]).Amount));
            "And the threshold should be 0.2".Observation(() => Assert.Equal(0.2m, ((UnsharpMaskFunction)request.Functions[0]).Threshold));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5m, (decimal)t.GetProperty("sigma").GetValue(p, null));
                Assert.Equal(4m, (decimal)t.GetProperty("radius").GetValue(p, null));
                Assert.Equal(0.3m, (decimal)t.GetProperty("amount").GetValue(p, null));
                Assert.Equal(0.2m, (decimal)t.GetProperty("threshold").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAnUnsharpMaskFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a unsharp mask function".Context(() => request = BuildA.Request()
                .WithUnsharpMaskFunction(f => f.Build()).Build());

            "Then the name should be unsharp_mask".Observation(() => Assert.Equal("unsharp_mask", request.Functions[0].Name));
            "And the sigma should be 1".Observation(() => Assert.Equal(1m, ((UnsharpMaskFunction)request.Functions[0]).Sigma));
            "And the radius should be 0".Observation(() => Assert.Equal(0m, ((UnsharpMaskFunction)request.Functions[0]).Radius));
            "And the amount should be 1".Observation(() => Assert.Equal(1m, ((UnsharpMaskFunction)request.Functions[0]).Amount));
            "And the threshold should be 0.05".Observation(() => Assert.Equal(0.05m, ((UnsharpMaskFunction)request.Functions[0]).Threshold));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(1m, (decimal)t.GetProperty("sigma").GetValue(p, null));
                Assert.Equal(0m, (decimal)t.GetProperty("radius").GetValue(p, null));
                Assert.Equal(1m, (decimal)t.GetProperty("amount").GetValue(p, null));
                Assert.Equal(0.05m, (decimal)t.GetProperty("threshold").GetValue(p, null));
            });
        }
    }
}
