using System;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.Contrast
{
    [Subject(typeof(ContrastFunction))]
    public class when_only_supplying_default_values
    {
        static ContrastFunction function;

        Because of = () => function = new ContrastFunction();

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((bool)t.GetProperty("sharpen").GetValue(function.Params, null)).ShouldEqual(false);

        };
    }

    [Subject(typeof(ContrastFunction))]
    public class when_only_supplying_custom_values
    {
        static ContrastFunction function;

        Because of = () => function = new ContrastFunction(true);

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((bool)t.GetProperty("sharpen").GetValue(function.Params, null)).ShouldEqual(true);
        };
    }
}
