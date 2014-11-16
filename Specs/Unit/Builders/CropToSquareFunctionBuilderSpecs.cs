using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class CropToSquareFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildACropToSquareFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an crop to square function".Context(() => request = BuildA.Request(r => r
                                                                                                      .WithApplicationId("123")
                                                                                                      .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                                                                                                      .CropToSquare(f => f.WithGravity(Gravity.NorthEastGravity))));

            "Then the name should be crop_to_square".Observation(() => Assert.Equal("crop_to_square", request.Functions[0].Name));
            "And gravity should be north east".Observation(() => Assert.Equal(Gravity.NorthEastGravity, ((CropToSquareFunction)request.Functions[0]).Gravity));
            
            "And the params should be constructed".Observation(() =>
                {
                    var p = request.Functions[0].Params;
                    var t = p.GetType();
                    Assert.Equal(Gravity.NorthEastGravity, t.GetProperty("gravity").GetValue(p, null));
                });
        }
    }
}