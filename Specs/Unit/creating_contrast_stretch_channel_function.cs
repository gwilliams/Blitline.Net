using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.ContrastStretchChannel
{
    [Subject(typeof(ContrastStretchChannelFunction))]
    public class when_only_supplying_default_values
    {
        static ContrastStretchChannelFunction function;

        Because of = () => function = new ContrastStretchChannelFunction(1);

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((int)t.GetProperty("black_point").GetValue(function.Params, null)).ShouldEqual(1);
            ((int)t.GetProperty("white_point").GetValue(function.Params, null)).ShouldEqual(0);

        };
    }

    [Subject(typeof(ContrastStretchChannelFunction))]
    public class when_only_supplying_custom_values
    {
        static ContrastStretchChannelFunction function;

        Because of = () => function = new ContrastStretchChannelFunction(1, 2);

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((int)t.GetProperty("black_point").GetValue(function.Params, null)).ShouldEqual(1);
            ((int)t.GetProperty("white_point").GetValue(function.Params, null)).ShouldEqual(2);
        };
    }
}
