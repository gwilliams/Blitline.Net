using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class SharpenFunctionBuilderSpecs : CanBuildDefaultFunctionBase<SharpenFunctionBuilder, SharpenFunction>
    {
        [Specification]
        public void CanBuildASharpenFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a sharpen function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Sharpen(f => f.WithSigma(5m).WithRadius(2m))));

            "Then the name should be sharpen".Observation(() => Assert.Equal("sharpen", request.Functions[0].Name));
            "And the sigma should be 5".Observation(() => Assert.Equal(5m, ((SharpenFunction)request.Functions[0]).Sigma));
            "And the radius should be 2".Observation(() => Assert.Equal(2m, ((SharpenFunction)request.Functions[0]).Radius));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5m, (decimal)t.GetProperty("sigma").GetValue(p, null));
                Assert.Equal(2m, (decimal)t.GetProperty("radius").GetValue(p, null));
            });
        }

        #region CanBuildDefaultFunctionBase

        protected override void And()
        {
            "And the sigma should be 1".Observation(
                () => Assert.Equal(1m, _function.Sigma));
            "And the radius should be 0".Observation(
                () => Assert.Equal(0m, _function.Radius));
        }

        protected override void AssertParams(dynamic t, dynamic p)
        {
            Assert.Equal(1m, (decimal) t.GetProperty("sigma").GetValue(p, null));
            Assert.Equal(0m, (decimal) t.GetProperty("radius").GetValue(p, null));
        }

        protected override string Name
        {
            get { return "sharpen"; }
        }

        #endregion

    }
}
