using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class DeleteProfileFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildADeleteProfileFunction()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build a delete profile function".Context(() => request = BuildA.Request(r => r
                                                                                                     .WithApplicationId("123")
                                                                                                     .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                                                                                                     .DeleteProfile(f => f.WithProfileName("profile"))));

            "Then the name should be delete_profile".Observation(() => Assert.Equal("delete_profile", request.Functions[0].Name));
            "And profile name should be set to profile".Observation(() => Assert.Equal("profile", ((DeleteProfileFunction)request.Functions[0]).ProfileName));

            "And the params should be constructed".Observation(() =>
                {
                    var p = request.Functions[0].Params;
                    var t = p.GetType();
                    Assert.Equal("profile", t.GetProperty("name").GetValue(p, null));
                });
        }
    }
}