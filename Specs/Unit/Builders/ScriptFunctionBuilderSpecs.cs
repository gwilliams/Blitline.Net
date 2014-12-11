using System;
using Blitline.Net.Builders;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public class ScriptFunctionBuilderSpecs
    {
        [Specification]
        public void CanBuildAScriptFunctionWithBashString()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an script function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Script(f => f.WithBashString("something"))));

            "Then the name should be script".Observation(() => Assert.Equal("script", request.Functions[0].Name));
            "And the bash string should be something".Observation(() => Assert.Equal("something", ((ScriptFunction)request.Functions[0]).BashString));
        }

        [Specification]
        public void CanBuildAScriptFunctionWithFilesAndExecutables()
        {
            BlitlineRequest request = default(BlitlineRequest);

            "When I build an script function".Context(() => request = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Script(f => f.WithFiles("files").WithExecutable("executable"))));

            "Then the name should be script".Observation(() => Assert.Equal("script", request.Functions[0].Name));
            "And the files should be files".Observation(() => Assert.Equal("files", ((ScriptFunction)request.Functions[0]).Files));
            "And the executables should be executable".Observation(() => Assert.Equal("executable", ((ScriptFunction)request.Functions[0]).Executable));
        }
    }
}
