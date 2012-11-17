using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class PadResizeToFitFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAModulateFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a pad resize to fit function".Context(() => request = BuildA.Request()
                .WithPadResizeToFitFunction(f => f.WithWidth(2).WithHeight(2).WithColour("ccc").WithGravity(Gravity.NorthEastGravity).Build()).Build());

            "Then the name should be pad_resize_to_fit".Observation(() => Assert.Equal("pad_resize_to_fit", request.Functions[0].Name));
            "And the width should be 2".Observation(() => Assert.Equal(2, ((PadResizeToFitFunction)request.Functions[0]).Width));
            "And the height should be 2".Observation(() => Assert.Equal(2, ((PadResizeToFitFunction)request.Functions[0]).Height));
            "And the hue should be ccc".Observation(() => Assert.Equal("ccc", ((PadResizeToFitFunction)request.Functions[0]).Colour));
            "And the gravity should be NorthEastGravity".Observation(() => Assert.Equal(Gravity.NorthEastGravity, ((PadResizeToFitFunction)request.Functions[0]).Gravity));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(2, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(2, (int)t.GetProperty("height").GetValue(p, null));
                Assert.Equal("ccc", t.GetProperty("color").GetValue(p, null).ToString());
                Assert.Equal(Gravity.NorthEastGravity, (Gravity)t.GetProperty("gravity").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAModulateWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a median pad resize to fit function".Context(() => request = BuildA.Request()
                .WithPadResizeToFitFunction(f => f.WithWidth(2).WithHeight(2).Build()).Build());

            "Then the name should be pad_resize_to_fit".Observation(() => Assert.Equal("pad_resize_to_fit", request.Functions[0].Name));
            "And the width should be 2".Observation(() => Assert.Equal(2, ((PadResizeToFitFunction)request.Functions[0]).Width));
            "And the height should be 2".Observation(() => Assert.Equal(2, ((PadResizeToFitFunction)request.Functions[0]).Height));
            "And the hue should be #ffffff".Observation(() => Assert.Equal("#ffffff", ((PadResizeToFitFunction)request.Functions[0]).Colour));
            "And the gravity should be CenterGrativty".Observation(() => Assert.Equal(Gravity.CenterGrativty, ((PadResizeToFitFunction)request.Functions[0]).Gravity));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(2, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(2, (int)t.GetProperty("height").GetValue(p, null));
                Assert.Equal("#ffffff", t.GetProperty("color").GetValue(p, null).ToString());
                Assert.Equal(Gravity.CenterGrativty, (Gravity)t.GetProperty("gravity").GetValue(p, null));
            });
        }
    }
}
