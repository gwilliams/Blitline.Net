using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class MedianFilterFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAMedianFilterFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a median filter function".Context(() => request = BuildA.Request()
                .WithMedianFilterFunction(f => f.WithRadius(2m).Build()).Build());

            "Then the name should be median_filter".Observation(() => Assert.Equal("median_filter", request.Functions[0].Name));
            "And the radius should be 2".Observation(() => Assert.Equal(2, ((MedianFilterFunction)request.Functions[0]).Radius));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(2m, (decimal)t.GetProperty("radius").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAMedianFilterWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a median filter function".Context(() => request = BuildA.Request()
                .WithMedianFilterFunction(f => f.Build()).Build());

            "Then the name should be median_filter".Observation(() => Assert.Equal("median_filter", request.Functions[0].Name));
            "And the radius should be 1".Observation(() => Assert.Equal(1.0m, ((MedianFilterFunction)request.Functions[0]).Radius));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(1.0m, (decimal)t.GetProperty("radius").GetValue(p, null));
            });
        }
    }
}
