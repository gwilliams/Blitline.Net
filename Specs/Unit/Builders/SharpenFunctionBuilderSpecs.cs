using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class SharpenFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildASharpenFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a sharpen function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Sharpen(f => f.WithSigma(5m).WithRadius(2m).Build()).Build());

            "Then the name should be sharpen".Observation(() => Assert.Equal("sharpen", request.Functions[0].Name));
            "And the sigma should be 5".Observation(() => Assert.Equal(5m, ((SharpenFunction)request.Functions[0]).Sigma));
            "And the radius should be 2".Observation(() => Assert.Equal(2m, ((SharpenFunction)request.Functions[0]).Radius));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5m, (decimal)t.GetProperty("sigma").GetValue(p, null));
                Assert.Equal(2m, (decimal)t.GetProperty("radius").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildASharpenFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a sharpen function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Sharpen(f => f.Build()).Build());

            "Then the name should be sharpen".Observation(() => Assert.Equal("sharpen", request.Functions[0].Name));
            "And the sigma should be 1".Observation(() => Assert.Equal(1m, ((SharpenFunction)request.Functions[0]).Sigma));
            "And the radius should be 0".Observation(() => Assert.Equal(0m, ((SharpenFunction)request.Functions[0]).Radius));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(1m, (decimal)t.GetProperty("sigma").GetValue(p, null));
                Assert.Equal(0m, (decimal)t.GetProperty("radius").GetValue(p, null));
            });
        }
    }
}
