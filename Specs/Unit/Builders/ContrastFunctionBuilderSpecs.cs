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
    public class ContrastFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAContrastFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an append function".Context(() => request = BuildA.Request()
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
