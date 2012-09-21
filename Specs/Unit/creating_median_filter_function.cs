using System;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.MedianFilter
{
    [Subject(typeof(MedianFilterFunction))]
    public class when_only_supplying_default_values
    {
        static MedianFilterFunction function;

        Because of = () => function = new MedianFilterFunction();

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((decimal)t.GetProperty("radius").GetValue(function.Params, null)).ShouldEqual(1.0m);

        };
    }

    [Subject(typeof(MedianFilterFunction))]
    public class when_only_supplying_custom_values
    {
        static MedianFilterFunction function;

        Because of = () => function = new MedianFilterFunction(5.1m);

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((decimal)t.GetProperty("radius").GetValue(function.Params, null)).ShouldEqual(5.1m);

        };
    }
}
