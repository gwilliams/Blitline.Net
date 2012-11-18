using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class ScaleFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAScaleFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a scale function".Context(() => request = BuildA.Request()
                .WithScaleFunction(f => f.WithWidth(5).WithHeight(2).WithScaleFactor(2m).Build()).Build());

            "Then the name should be scale".Observation(() => Assert.Equal("scale", request.Functions[0].Name));
            "And the width should be 5".Observation(() => Assert.Equal(5, ((ScaleFunction)request.Functions[0]).Width));
            "And the height should be 2".Observation(() => Assert.Equal(2, ((ScaleFunction)request.Functions[0]).Height));
            "And the scale factor should be 2".Observation(() => Assert.Equal(2m, ((ScaleFunction)request.Functions[0]).ScaleFactor));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5m, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(2m, (int)t.GetProperty("height").GetValue(p, null));
                Assert.Equal(2m, (decimal)t.GetProperty("scale_factor").GetValue(p, null));
            });
        }

        [Specification]
        public void CanBuildAScaleFunctionWithOnlyRequiredValues()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a scale function".Context(() => request = BuildA.Request()
                .WithScaleFunction(f => f.WithWidth(5).WithHeight(2).Build()).Build());

            "Then the name should be scale".Observation(() => Assert.Equal("scale", request.Functions[0].Name));
            "And the width should be 5".Observation(() => Assert.Equal(5, ((ScaleFunction)request.Functions[0]).Width));
            "And the height should be 2".Observation(() => Assert.Equal(2, ((ScaleFunction)request.Functions[0]).Height));
            "And the scale factor should be 0.5".Observation(() => Assert.Equal(0.5m, ((ScaleFunction)request.Functions[0]).ScaleFactor));

            "And the params should be constructed".Observation(() =>
            {
                var p = request.Functions[0].Params;
                var t = p.GetType();

                Assert.Equal(5, (int)t.GetProperty("width").GetValue(p, null));
                Assert.Equal(2, (int)t.GetProperty("height").GetValue(p, null));
                Assert.Equal(0.5m, (decimal)t.GetProperty("scale_factor").GetValue(p, null));
            });
        }
    }
}
