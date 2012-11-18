using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class QuantizeFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAQuantizeFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a quantize function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithQuantizeFunction(f => f.WithNumberOfColours(5).WithColourSpace("colours").Dither(true).Build()).Build());

            "Then the name should be quantize".Observation(() => Assert.Equal("quantize", request.Functions[0].Name));
            "And the number of colours should be 5".Observation(() => Assert.Equal(5, ((QuantizeFunction)request.Functions[0]).NumberOfColours));
            "And the colour space should be colours".Observation(() => Assert.Equal("colours", ((QuantizeFunction)request.Functions[0]).ColourSpace));
            "And the the dither should be true".Observation(() => Assert.Equal(true, ((QuantizeFunction)request.Functions[0]).Dither));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5, (int)t.GetProperty("number_colors").GetValue(p, null));
                Assert.Equal("colours", t.GetProperty("color_space").GetValue(p, null).ToString());
                Assert.Equal(true, (bool)t.GetProperty("dither").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAQuantizeFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a quantize function".Context(() => request = BuildA.Request()
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .WithQuantizeFunction(f => f.WithNumberOfColours(5).Build()).Build());

            "Then the name should be quantize".Observation(() => Assert.Equal("quantize", request.Functions[0].Name));
            "And the number of colours should be 5".Observation(() => Assert.Equal(5, ((QuantizeFunction)request.Functions[0]).NumberOfColours));
            "And the colour space should be colours".Observation(() => Assert.Equal("RGBColorspace", ((QuantizeFunction)request.Functions[0]).ColourSpace));
            "And the the dither should be false".Observation(() => Assert.Equal(false, ((QuantizeFunction)request.Functions[0]).Dither));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5, (int)t.GetProperty("number_colors").GetValue(p, null));
                Assert.Equal("RGBColorspace", t.GetProperty("color_space").GetValue(p, null).ToString());
                Assert.Equal(false, (bool)t.GetProperty("dither").GetValue(p, null));
            });
        }
    }
}
