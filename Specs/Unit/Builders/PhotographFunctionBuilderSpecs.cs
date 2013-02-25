using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class PhotographFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAnAppendFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an photograph function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Photograph(f => f.WithAngle(2))));

            "Then the name should be photograph".Observation(() => Assert.Equal("photograph", request.Functions[0].Name));
            "And the angle should be 2".Observation(() => Assert.Equal(2, ((PhotographFunction)request.Functions[0]).Angle));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(2, (int)t.GetProperty("angle").GetValue(p, null));
            });
        }
    }
}
