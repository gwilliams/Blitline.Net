using Blitline.Net.Builders;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class NoOpFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildANoOpFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an equalize function".Context(() => request = BuildA.Request()
                .WithNoOpFunction(f => f.Build()).Build());

            "Then the name should be no_op".Observation(() => Assert.Equal("no_op", request.Functions[0].Name));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal(0, t.GetProperties().Length);
            });
        }
    }
}
