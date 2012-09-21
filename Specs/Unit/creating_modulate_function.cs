using System;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.Modulate
{
    [Subject(typeof(ModulateFunction))]
    public class when_only_supplying_default_values
    {
        static ModulateFunction function;

        Because of = () => function = new ModulateFunction();

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((decimal)t.GetProperty("brightness").GetValue(function.Params, null)).ShouldEqual(1.0m);
            ((decimal)t.GetProperty("saturation").GetValue(function.Params, null)).ShouldEqual(1.0m);
            ((decimal)t.GetProperty("hue").GetValue(function.Params, null)).ShouldEqual(1.0m);

        };
    }

    [Subject(typeof(ModulateFunction))]
    public class when_only_supplying_custom_values
    {
        static ModulateFunction function;

        Because of = () => function = new ModulateFunction(2m, 3m, 4m);

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((decimal)t.GetProperty("brightness").GetValue(function.Params, null)).ShouldEqual(2.0m);
            ((decimal)t.GetProperty("saturation").GetValue(function.Params, null)).ShouldEqual(3.0m);
            ((decimal)t.GetProperty("hue").GetValue(function.Params, null)).ShouldEqual(4.0m);

        };
    }
}
