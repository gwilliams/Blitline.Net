using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class AppendFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAnAppendFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

			"When I build an append function".Context(() => request = BuildA.Request(r => r
			    .WithApplicationId("123")
			    .WithSourceImageUri(new Uri("http://foo.bar.gif"))
				.Append(f => f.AppendVeritically(true).WithOtherImages (new Uri("http://foo.jpg"), new Uri("http://bar.jpg")))));

            "Then the name should be append".Observation(() => Assert.Equal("append", request.Functions[0].Name));
            "And the vertical should be true".Observation(() => Assert.Equal(true, ((AppendFunction)request.Functions[0]).Vertical));
			"And the other_images should be set".Observation (() => Assert.Equal ("http://foo.jpg,http://bar.jpg", ((AppendFunction)request.Functions [0]).OtherImages));

            "And the params should be constructed".Observation(() =>
                {
                    var p = request.Functions[0].Params;
                    var t = p.GetType();
                    Assert.Equal(true, (bool)t.GetProperty("vertical").GetValue(p, null));
                });
        }
    }
}
