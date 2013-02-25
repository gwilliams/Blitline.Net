using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class ContrastStrecthChannelFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAContrastStretchChannelFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an contrast stretch channel function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .ContrastStretchChannel(f => f.WithBlackPoint(10)
                    .WithWhitePoint(5))));

            "Then the name should be contrast_stretch_channel".Observation(() => Assert.Equal("contrast_stretch_channel", request.Functions[0].Name));
            "And the black point should be 10".Observation(() => Assert.Equal(10, ((ContrastStretchChannelFunction)request.Functions[0]).BlackPoint));
            "And the white point should be 5".Observation(() => Assert.Equal(5, ((ContrastStretchChannelFunction)request.Functions[0]).WhitePoint));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(10, (int)t.GetProperty("black_point").GetValue(p, null));
                Assert.Equal(5, (int)t.GetProperty("white_point").GetValue(p, null));
            });
        }
    }
}
