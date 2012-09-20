using System;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.Deskew
{
    [Subject(typeof(DeskewFunction))]
    public class when_only_supplying_default_values
    {
        static DeskewFunction function;

        Because of = () => function = new DeskewFunction();

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((decimal)t.GetProperty("threshold").GetValue(function.Params, null)).ShouldEqual(0.4m);

        };
    }

    [Subject(typeof(DeskewFunction))]
    public class when_only_supplying_custom_values
    {
        static DeskewFunction function;

        Because of = () => function = new DeskewFunction(10);

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((decimal)t.GetProperty("threshold").GetValue(function.Params, null)).ShouldEqual(10);
        };
    }
}
