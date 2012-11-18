using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class GammaChannelFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAGammaChannelFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a gamma channel function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithGammaChannelFunction(f => f.WithGamma(3.5m).Build()).Build());

            "Then the name should be gamma_channel".Observation(() => Assert.Equal("gamma_channel", request.Functions[0].Name));
            "And the gamma should be 3.5".Observation(() => Assert.Equal(3.5m, ((GammaChannelFunction)request.Functions[0]).Gamma));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(3.5m, (decimal)t.GetProperty("gamma").GetValue(p, null));
            });
        }
    }
}
