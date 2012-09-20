using System;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.GammaChannel
{
    [Subject(typeof(GammaChannelFunction))]
    public class when_creating_blur_function
    {
        static GammaChannelFunction function;

        Because of = () => function = new GammaChannelFunction(10);

        It it_should_set_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((decimal)t.GetProperty("gamma").GetValue(function.Params, null)).ShouldEqual(10);
        };
    }
}
