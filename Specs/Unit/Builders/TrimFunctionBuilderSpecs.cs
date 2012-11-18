using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net.Builders;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class TrimFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildATrimFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an trim function".Context(() => request = BuildA.Request()
                .WithTrimFunction(f => f.Build()).Build());

            "Then the name should be trim".Observation(() => Assert.Equal("trim", request.Functions[0].Name));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(0, t.GetProperties().Length);
            });
        }
    }
}
