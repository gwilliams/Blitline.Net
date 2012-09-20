using System;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.Append
{
    [Subject(typeof(AppendFunction))]
    public class when_creating_append_function
    {
        static AppendFunction function;

        Because of = () => function = new AppendFunction(true);

        It it_should_set_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((bool)t.GetProperty("vertical").GetValue(function.Params, null)).ShouldEqual(true);
        };
    }
}
