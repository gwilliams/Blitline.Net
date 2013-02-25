using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class WatermarkFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAWatermarkFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a watermark function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Watermark(f => f.WithText("text").WithGravity(Gravity.NorthEastGravity)
                    .WithPointSize(10)
                    .WithFontFamily("Arial")
                    .WithOpacity(0.1m))));

            "Then the name should be watermark".Observation(() => Assert.Equal("watermark", request.Functions[0].Name));
            "And the text should be text".Observation(() => Assert.Equal("text", ((WatermarkFunction)request.Functions[0]).Text));
            "And the gravity should be NorthEastGravity".Observation(() => Assert.Equal(Gravity.NorthEastGravity, ((WatermarkFunction)request.Functions[0]).Gravity));
            "And the point size should be 10".Observation(() => Assert.Equal(10, ((WatermarkFunction)request.Functions[0]).PointSize));
            "And the font family should be Arial".Observation(() => Assert.Equal("Arial", ((WatermarkFunction)request.Functions[0]).FontFamily));
            "And the opacity should be 0.1".Observation(() => Assert.Equal(0.1m, ((WatermarkFunction)request.Functions[0]).Opacity));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal("text", t.GetProperty("text").GetValue(p, null).ToString());
                Assert.Equal(Gravity.NorthEastGravity, (Gravity)t.GetProperty("gravity").GetValue(p, null));
                Assert.Equal(10, (int)t.GetProperty("point_size").GetValue(p, null));
                Assert.Equal("Arial", t.GetProperty("font_family").GetValue(p, null).ToString());
                Assert.Equal(0.1m, (decimal)t.GetProperty("opacity").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAWatermarkFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a watermark function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Watermark(f => f.WithText("text"))));

            "Then the name should be watermark".Observation(() => Assert.Equal("watermark", request.Functions[0].Name));
            "And the text should be text".Observation(() => Assert.Equal("text", ((WatermarkFunction)request.Functions[0]).Text));
            "And the gravity should be CenterGrativty".Observation(() => Assert.Equal(Gravity.CenterGrativty, ((WatermarkFunction)request.Functions[0]).Gravity));
            "And the point size should be 94".Observation(() => Assert.Equal(94, ((WatermarkFunction)request.Functions[0]).PointSize));
            "And the font family should be Helvetica".Observation(() => Assert.Equal("Helvetica", ((WatermarkFunction)request.Functions[0]).FontFamily));
            "And the opacity should be 0.45".Observation(() => Assert.Equal(0.45m, ((WatermarkFunction)request.Functions[0]).Opacity));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal("text", t.GetProperty("text").GetValue(p, null).ToString());
                Assert.Equal(Gravity.CenterGrativty, (Gravity)t.GetProperty("gravity").GetValue(p, null));
                Assert.Equal(94, (int)t.GetProperty("point_size").GetValue(p, null));
                Assert.Equal("Helvetica", t.GetProperty("font_family").GetValue(p, null).ToString());
                Assert.Equal(0.45m, (decimal)t.GetProperty("opacity").GetValue(p, null));
            });
        }
    }
}
