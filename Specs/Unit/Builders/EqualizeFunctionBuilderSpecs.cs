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
    public class EqualizeFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAnEqualizeFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an equalize function".Context(() => request = BuildA.Request()
                .WithEqualizeFunction(f => f.Build()).Build());

            "Then the name should be equalize".Observation(() => Assert.Equal("equalize", request.Functions[0].Name));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(0, t.GetProperties().Length);
            });
        }
    }
}
