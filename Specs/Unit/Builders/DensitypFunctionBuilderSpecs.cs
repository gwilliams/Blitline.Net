using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class DensitypFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildADensityFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a density function".Context(() => request = BuildA.Request(r => r
                                                                                              .WithApplicationId("123")
                                                                                              .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                                                                                              .Density(f => f.WithDpi(300))));

            "Then the name should be density".Observation(() => Assert.Equal("density", request.Functions[0].Name));
            "And dpi should be 300".Observation(() => Assert.Equal(300, ((DensityFunction)request.Functions[0]).Dpi));
            
            "And the params should be constructed".Observation(() =>
                {
                    var p = request.Functions[0].Params;
                    var t = p.GetType();
                    Assert.Equal(300, t.GetProperty("dpi").GetValue(p, null));
                });
        }
    }
}