using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;
using Xunit;

namespace Specs.Unit.Builders
{
    public class AutoLevelFunctionBuilderSpecs : CanBuildDefaultFunctionBase<AutoLevelFunctionBuilder, AutoLevelFunction>
    {
        protected override void AssertParams(dynamic t, dynamic p)
        {
            Assert.Equal(0, t.GetProperties().Length);
        }

        protected override string Name
        {
            get { return "auto_level"; }
        }
    }
}