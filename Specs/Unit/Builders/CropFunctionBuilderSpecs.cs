using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class CropFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildACropFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an crop function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Crop(f => f.WithDimensions(1,2,3,4).WithGravity(Gravity.NorthEastGravity).PreserveAspectIfSmaller())));

            "Then the name should be crop".Observation(() => Assert.Equal("crop", request.Functions[0].Name));
            "And x should be 1".Observation(() => Assert.Equal(1, ((CropFunction)request.Functions[0]).X));
            "And y should be 2".Observation(() => Assert.Equal(2, ((CropFunction)request.Functions[0]).Y));
            "And width should be 3".Observation(() => Assert.Equal(3, ((CropFunction)request.Functions[0]).Width));
            "And height should be 4".Observation(() => Assert.Equal(4, ((CropFunction)request.Functions[0]).Height));
            "And gravity should be north east".Observation(() => Assert.Equal(Gravity.NorthEastGravity, ((CropFunction)request.Functions[0]).Gravity));
            "And preserve aspect if smaller should be true".Observation(() => Assert.Equal(true, ((CropFunction)request.Functions[0]).PreserveAspectIfSmaller));

            "And the params should be constructed".Observation(() =>
                {
                    var p = request.Functions[0].Params;
                    var t = p.GetType();
                    Assert.Equal(1, t.GetProperty("x").GetValue(p, null));
                    Assert.Equal(2, t.GetProperty("y").GetValue(p, null));
                    Assert.Equal(3, t.GetProperty("width").GetValue(p, null));
                    Assert.Equal(4, t.GetProperty("height").GetValue(p, null));
                    Assert.Equal(Gravity.NorthEastGravity, t.GetProperty("gravity").GetValue(p, null));
                    Assert.Equal(true, t.GetProperty("preserve_aspect_if_smaller").GetValue(p, null));
                });
        }
    }
}
