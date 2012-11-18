using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class ContrastFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAContrastFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an contrast function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithContrastFunction(f => f.Sharpen(true).Build()).Build());

            "Then the name should be contrast".Observation(() => Assert.Equal("contrast", request.Functions[0].Name));
            "And the sharpen should be true".Observation(() => Assert.Equal(true, ((ContrastFunction)request.Functions[0]).Sharpen));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(true, (bool)t.GetProperty("sharpen").GetValue(p, null));
            });
        }
    }
}
