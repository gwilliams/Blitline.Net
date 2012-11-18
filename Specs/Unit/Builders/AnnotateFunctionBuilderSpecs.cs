using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class AnnotateFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAnAnnotateFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an annotate function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithAnnotateFunction(f => f
                    .WithText("Text")
                    .WithX(1)
                    .WithY(1)
                    .WithColour("ccc")
                    .WithFontFamilty("Arial")
                    .WithPointSize(10)
                    .WithStroke("super")
                    .WithGravity(Gravity.NorthGravity)
                    .Build())
                .Build());

            "The the name should be annotate".Observation(() => Assert.Equal("annotate", request.Functions[0].Name));
            "And the text should be set".Observation(() => Assert.Equal("Text", ((AnnotateFunction)request.Functions[0]).Text));
            "And the x should be 1".Observation(() => Assert.Equal(1, ((AnnotateFunction) request.Functions[0]).X));
            "And the y should be 1".Observation(() => Assert.Equal(1, ((AnnotateFunction) request.Functions[0]).Y));
            "And the colour should be ccc".Observation(() => Assert.Equal("ccc", ((AnnotateFunction)request.Functions[0]).Colour));
            "And the font family should be Arial".Observation(() => Assert.Equal("Arial", ((AnnotateFunction)request.Functions[0]).FontFamily));
            "And the point size should be 10".Observation(() => Assert.Equal(10, ((AnnotateFunction)request.Functions[0]).PointSize));
            "And the stroke should be super".Observation(() => Assert.Equal("super", ((AnnotateFunction)request.Functions[0]).Stroke));
            "And the gravity should be NorthGravity".Observation(() => Assert.Equal(Gravity.NorthGravity, ((AnnotateFunction)request.Functions[0]).Gravity));

            "And the params should be constructed".Observation(() =>
                {
                    var p = request.Functions[0].Params;
                    var t = p.GetType();
                    Assert.Equal("Text", t.GetProperty("text").GetValue(p, null).ToString());
                    Assert.Equal(1, (int)t.GetProperty("x").GetValue(p, null));
                    Assert.Equal(1, (int)t.GetProperty("y").GetValue(p, null));
                    Assert.Equal("ccc",t.GetProperty("color").GetValue(p, null).ToString());
                    Assert.Equal("Arial", t.GetProperty("font_family").GetValue(p, null).ToString());
                    Assert.Equal(10, (int)t.GetProperty("point_size").GetValue(p, null));
                    Assert.Equal("super", t.GetProperty("stroke").GetValue(p, null).ToString());
                    Assert.Equal(Gravity.NorthGravity, (Gravity)t.GetProperty("gravity").GetValue(p, null));
                });
        }

        [Specification]
        public void CanBuildAnAnnotateFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an annotate function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithAnnotateFunction(f => f
                    .WithText("Text")
                    .Build())
                .Build());

            "The the name should be annotate".Observation(() => Assert.Equal("annotate", request.Functions[0].Name));
            "And the text should be set".Observation(() => Assert.Equal("Text", ((AnnotateFunction)request.Functions[0]).Text));
            "And the x should be 0".Observation(() => Assert.Equal(0, ((AnnotateFunction)request.Functions[0]).X));
            "And the y should be 0".Observation(() => Assert.Equal(0, ((AnnotateFunction)request.Functions[0]).Y));
            "And the colour should be #ffffff".Observation(() => Assert.Equal("#ffffff", ((AnnotateFunction)request.Functions[0]).Colour));
            "And the font family should be Helvetica".Observation(() => Assert.Equal("Helvetica", ((AnnotateFunction)request.Functions[0]).FontFamily));
            "And the point size should be 32".Observation(() => Assert.Equal(32, ((AnnotateFunction)request.Functions[0]).PointSize));
            "And the stroke should be transparent".Observation(() => Assert.Equal("transparent", ((AnnotateFunction)request.Functions[0]).Stroke));
            "And the gravity should be CenterGravity".Observation(() => Assert.Equal(Gravity.CenterGrativty, ((AnnotateFunction)request.Functions[0]).Gravity));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal("Text", t.GetProperty("text").GetValue(p, null).ToString());
                Assert.Equal(0, (int)t.GetProperty("x").GetValue(p, null));
                Assert.Equal(0, (int)t.GetProperty("y").GetValue(p, null));
                Assert.Equal("#ffffff", t.GetProperty("color").GetValue(p, null).ToString());
                Assert.Equal("Helvetica", t.GetProperty("font_family").GetValue(p, null).ToString());
                Assert.Equal(32, (int)t.GetProperty("point_size").GetValue(p, null));
                Assert.Equal("transparent", t.GetProperty("stroke").GetValue(p, null).ToString());
                Assert.Equal(Gravity.CenterGrativty, (Gravity)t.GetProperty("gravity").GetValue(p, null));
            });
        }
    }
}
