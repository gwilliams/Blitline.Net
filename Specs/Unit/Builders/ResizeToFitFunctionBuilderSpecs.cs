using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class ResizeToFitFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAResizeToFitFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a resize to resize_to_fit function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithResizeToFitFunction(f => f.WithWidth(5).WithHeight(2)
                    .OnlyShrinkLarger(true).Build()).Build());

            "Then the name should be resize_to_fit".Observation(() => Assert.Equal("resize_to_fit", request.Functions[0].Name));
            "And the width should be 5".Observation(() => Assert.Equal(5, ((ResizeToFitFunction)request.Functions[0]).Width));
            "And the height should be 2".Observation(() => Assert.Equal(2, ((ResizeToFitFunction)request.Functions[0]).Height));
            "And the only shrink larger be true".Observation(() => Assert.Equal(true, ((ResizeToFitFunction)request.Functions[0]).OnlyShrinkLarger));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(2, (int)t.GetProperty("height").GetValue(p, null));
                Assert.Equal(true, (bool)t.GetProperty("only_shrink_larger").GetValue(p, null));
            });
        }
    }
}
