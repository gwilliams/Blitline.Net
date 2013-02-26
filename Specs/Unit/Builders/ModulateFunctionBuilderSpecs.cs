using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class ModulateFunctionBuilderSpecs : CanBuildDefaultFunctionBase<ModulateFunctionBuilder, ModulateFunction>
    {
        [Specification]
        public void CanBuildAModulateFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a modulate function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Modulate(f => f.WithBrightness(2m).WithSaturation(2.0m).WithHue(2.0m))));

            "Then the name should be modulate".Observation(() => Assert.Equal("modulate", request.Functions[0].Name));
            "And the brightness should be 2".Observation(() => Assert.Equal(2.0m, ((ModulateFunction)request.Functions[0]).Brightness));
            "And the saturation should be 2".Observation(() => Assert.Equal(2.0m, ((ModulateFunction)request.Functions[0]).Saturation));
            "And the hue should be 2".Observation(() => Assert.Equal(2.0m, ((ModulateFunction)request.Functions[0]).Hue));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(2.0m, (decimal)t.GetProperty("brightness").GetValue(p, null));
                Assert.Equal(2.0m, (decimal)t.GetProperty("saturation").GetValue(p, null));
                Assert.Equal(2.0m, (decimal)t.GetProperty("hue").GetValue(p, null));
            });
        }

        #region CanBuildDefaultFunctionBase

        protected override void And()
        {
            "And the brightness should be 1".Observation(() => Assert.Equal(1.0m, _function.Brightness));
            "And the saturation should be 1".Observation(() => Assert.Equal(1.0m, _function.Saturation));
            "And the hue should be 1".Observation(() => Assert.Equal(1.0m, _function.Hue));
        }

        protected override void AssertParams(dynamic t, dynamic p)
        {
            Assert.Equal(1.0m, (decimal) t.GetProperty("brightness").GetValue(p, null));
            Assert.Equal(1.0m, (decimal) t.GetProperty("saturation").GetValue(p, null));
            Assert.Equal(1.0m, (decimal) t.GetProperty("hue").GetValue(p, null));
        }

        protected override string Name
        {
            get { return "modulate"; }
        }

        #endregion

    }
}
