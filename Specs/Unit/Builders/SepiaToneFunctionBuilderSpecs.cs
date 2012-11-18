using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class SepiaToneFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildASpeiaToneFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an sepia tone function".Context(() => request = BuildA.Request()
                .WithSepiaToneFunction(f => f.WithThreshold(1).Build()).Build());

            "Then the name should be sepia_tone".Observation(() => Assert.Equal("sepia_tone", request.Functions[0].Name));
            "And the threshold should be 1".Observation(() => Assert.Equal(1, ((SepiaToneFunction)request.Functions[0]).Threshold));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(1, (int)t.GetProperty("threshold").GetValue(p, null));
            });
        }
    }
}
