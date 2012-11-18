using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class RotateFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAnAppendFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a rotate function".Context(() => request = BuildA.Request()
                .WithRotateFunction(f => f.WithAmount(10).Build()).Build());

            "Then the name should be rotate".Observation(() => Assert.Equal("rotate", request.Functions[0].Name));
            "And the amount should be 10".Observation(() => Assert.Equal(10, ((RotateFunction)request.Functions[0]).Amount));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(10, (int)t.GetProperty("amount").GetValue(p, null));
            });
        }
    }
}
