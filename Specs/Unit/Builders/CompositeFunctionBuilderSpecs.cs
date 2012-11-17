using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class CompositeFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildACompositeFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a composite function".Context(() => request = BuildA.Request()
                .WithCompositeFunction(f => f.WithSource("source")
                .AsMask(true)
                .WithX(1)
                .WithY(1)
                .WithCompositeOp(CompositeOps.AddCompositeOp).Build()).Build());

            "The the name should be composite".Observation(() => Assert.Equal("composite", request.Functions[0].Name));
            "And the source should be source".Observation(() => Assert.Equal("source", ((CompositeFunction)request.Functions[0]).Source));
            "And AsMask should be true".Observation(() => Assert.True(((CompositeFunction) request.Functions[0]).AsMask));
            "And x should be 1".Observation(() => Assert.Equal(1, ((CompositeFunction) request.Functions[0]).X));
            "And y should be 1".Observation(() => Assert.Equal(1, ((CompositeFunction) request.Functions[0]).Y));
            "And the composite ops should be AddCompositeOp".Observation(() => Assert.Equal(CompositeOps.AddCompositeOp, ((CompositeFunction)request.Functions[0]).CompositeOp));

            "And the params should be constructed".Observation(() =>
                {
                    var p = request.Functions[0].Params;
                    var t = p.GetType();
                    Assert.Equal("source", t.GetProperty("src").GetValue(p, null).ToString());
                    Assert.Equal(true, (bool)t.GetProperty("as_mask").GetValue(p, null));
                    Assert.Equal(1, (int)t.GetProperty("x").GetValue(p, null));
                    Assert.Equal(1, (int)t.GetProperty("y").GetValue(p, null));
                    Assert.Equal(CompositeOps.AddCompositeOp, (CompositeOps)t.GetProperty("composite_op").GetValue(p, null));
                });
        }

        [Specification]
        public void CanBuildACompositeFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a composite function".Context(() => request = BuildA.Request()
                .WithCompositeFunction(f => f.WithSource("source").Build()).Build());

            "The the name should be composite".Observation(() => Assert.Equal("composite", request.Functions[0].Name));
            "And the source should be source".Observation(() => Assert.Equal("source", ((CompositeFunction)request.Functions[0]).Source));
            "And AsMask should be false".Observation(() => Assert.False(((CompositeFunction)request.Functions[0]).AsMask));
            "And x should be 0".Observation(() => Assert.Equal(0, ((CompositeFunction)request.Functions[0]).X));
            "And y should be 0".Observation(() => Assert.Equal(0, ((CompositeFunction)request.Functions[0]).Y));
            "And the composite ops should be OverCompositeOp".Observation(() => Assert.Equal(CompositeOps.OverCompositeOp, ((CompositeFunction)request.Functions[0]).CompositeOp));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();
                Assert.Equal("source", t.GetProperty("src").GetValue(p, null).ToString());
                Assert.Equal(false, (bool)t.GetProperty("as_mask").GetValue(p, null));
                Assert.Equal(0, (int)t.GetProperty("x").GetValue(p, null));
                Assert.Equal(0, (int)t.GetProperty("y").GetValue(p, null));
                Assert.Equal(CompositeOps.OverCompositeOp, (CompositeOps)t.GetProperty("composite_op").GetValue(p, null));
            });
        }
    }
}
