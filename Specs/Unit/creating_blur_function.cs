using System;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.Blur
{
     [Subject(typeof(BlurFunction))]
    public class when_creating_blur_function
    {
        static BlurFunction function;

        Because of = () => function = new BlurFunction(10, 5);

        It it_should_set_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((decimal)t.GetProperty("sigma").GetValue(function.Params, null)).ShouldEqual(10);
            ((decimal)t.GetProperty("radius").GetValue(function.Params, null)).ShouldEqual(5);
        };
    }
}
