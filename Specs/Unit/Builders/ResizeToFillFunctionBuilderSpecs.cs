using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class ResizeToFillFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAResizeToFillFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a resize to resize_to_fill function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .ResizeToFill(f => f.WithWidth(5).WithHeight(2).WithGravity(Gravity.NorthEastGravity)
                    .OnlyShrinkLarger(true).Build()).Build());

            "Then the name should be resize_to_fill".Observation(() => Assert.Equal("resize_to_fill", request.Functions[0].Name));
            "And the width should be 5".Observation(() => Assert.Equal(5, ((ResizeToFillFunction)request.Functions[0]).Width));
            "And the height should be 2".Observation(() => Assert.Equal(2, ((ResizeToFillFunction)request.Functions[0]).Height));
            "And the gravity should be NorthEastGravity".Observation(() => Assert.Equal(Gravity.NorthEastGravity, ((ResizeToFillFunction)request.Functions[0]).Gravity));
            "And the only shrink larger be true".Observation(() => Assert.Equal(true, ((ResizeToFillFunction)request.Functions[0]).OnlyShrinkLarger));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(2, (int)t.GetProperty("height").GetValue(p, null));
                Assert.Equal("NorthEastGravity", t.GetProperty("gravity").GetValue(p, null).ToString());
                Assert.Equal(true, (bool)t.GetProperty("only_shrink_larger").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAResizeToFillFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a resize to resize_to_fill function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .ResizeToFill(f => f.WithWidth(5).WithHeight(2).Build()).Build());

            "Then the name should be resize_to_fill".Observation(() => Assert.Equal("resize_to_fill", request.Functions[0].Name));
            "And the width should be 5".Observation(() => Assert.Equal(5, ((ResizeToFillFunction)request.Functions[0]).Width));
            "And the height should be 2".Observation(() => Assert.Equal(2, ((ResizeToFillFunction)request.Functions[0]).Height));
            "And the gravity should be CenterGrativty".Observation(() => Assert.Equal(Gravity.CenterGrativty, ((ResizeToFillFunction)request.Functions[0]).Gravity));
            "And the only shrink larger be false".Observation(() => Assert.Equal(false, ((ResizeToFillFunction)request.Functions[0]).OnlyShrinkLarger));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(2, (int)t.GetProperty("height").GetValue(p, null));
                Assert.Equal("CenterGrativty", t.GetProperty("gravity").GetValue(p, null).ToString());
                Assert.Equal(false, (bool)t.GetProperty("only_shrink_larger").GetValue(p, null));
            });
        }
    }
}
