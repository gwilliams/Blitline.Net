using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net;
using Blitline.Net.Request;
using Machine.Specifications;
using SubSpec;

namespace Specs.Unit.Builders
{
    
    public class RequestBuilderSpecs
    {
        [Specification]
        public void DoIt()
        {
            BlitlineRequest request = default(BlitlineRequest);
           
            "Given I do something".Context(() => { });

            "When I do it".Do(() => request = BuildA.Request().WithApplicationId("123").WithSourceImageUri(new Uri("https://foo.bar.gif"))
                .WithCropFunction(f => f.WithDimensions(1,2,3,4).WithResizeFunction(r => r.WithDimensions(1,2).Build()).Build()).Build());

            "Then something".Observation(() =>
                                             {
                                                 request.ApplicationId.ShouldNotBeEmpty();
                                                 var x = 1;
                                             });
        }
    }
}
