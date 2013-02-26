using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;
using SubSpec;
using Xunit;

namespace Specs.Unit.Builders
{
    public abstract class CanBuildDefaultFunctionBase<TBuilder, TFunction>
        where TFunction : BlitlineFunction, new() 
        where TBuilder: FunctionBuilder<TFunction>, new()
    {
        protected TBuilder _builder;
        protected TFunction _function;

        [Specification]
        public void CanBuildAFunction()
        {
            _builder = new TBuilder();
            _function = null;

            When.Context(() => _function = _builder.Build());

            ThenName.Observation(() => Assert.Equal(Name, _function.Name));
            And();

            "And the params should be constructed".Observation(() =>
            {
                var p = _function.Params;
                var t = p.GetType();
                AssertParams(t, p);
            });
        }

        protected abstract void AssertParams(dynamic t, dynamic p);

        private string ThenName
        {
            get { return string.Format("Then the name should be {0}", Name); }
        }

        private string When { get { return string.Format("When I build a {0} function", Name); } }
        protected abstract string Name { get; }

        protected virtual void And()
        {
        }

    }
}