using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class DeskewFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildADeskewFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a deskew function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Deskew(f => f.WithThreshold(1m).Build()).Build());

            "Then the name should be deskew".Observation(() => Assert.Equal("deskew", request.Functions[0].Name));
            "And threshold should be 1".Observation(() => Assert.Equal(1, ((DeskewFunction)request.Functions[0]).Threshold));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(1, (decimal)t.GetProperty("threshold").GetValue(p, null));
            });
        }
    }
}
