using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class MedianFilterFunctionBuilderSpecs : CanBuildDefaultFunctionBase<MedianFilterFunctionBuilder, MedianFilterFunction>
    {
        [Specification]
        public void CanBuildAMedianFilterFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a median filter function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .MedianFilter(f => f.WithRadius(2m))));

            "Then the name should be median_filter".Observation(() => Assert.Equal("median_filter", request.Functions[0].Name));
            "And the radius should be 2".Observation(() => Assert.Equal(2, ((MedianFilterFunction)request.Functions[0]).Radius));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(2m, (decimal)t.GetProperty("radius").GetValue(p, null));
            });
        }

        #region CanBuildDefaultFunctionBase

        protected override void AssertParams(dynamic t, dynamic p)
        {
            Assert.Equal(1.0m, (decimal)t.GetProperty("radius").GetValue(p, null));
        }

        protected override string Name
        {
            get { return "median_filter"; }
        }

        protected override void And()
        {
            "And the radius should be 1".Observation(() => Assert.Equal(1.0m, _function.Radius));
        }

        #endregion
    }
}
