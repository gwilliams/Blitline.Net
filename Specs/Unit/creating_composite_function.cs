using System;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Machine.Specifications;

namespace Specs.Unit.Composite
{
    [Subject(typeof(CompositeFunction))]
    public class when_only_supplying_default_values
    {
        static CompositeFunction function;

        Because of = () => function = new CompositeFunction("src");

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            t.GetProperty("src").GetValue(function.Params, null).ToString().ShouldEqual("src");
            ((int)t.GetProperty("x").GetValue(function.Params, null)).ShouldEqual(0);
            ((int)t.GetProperty("y").GetValue(function.Params, null)).ShouldEqual(0);
            ((bool)t.GetProperty("as_mask").GetValue(function.Params, null)).ShouldEqual(false);
            ((CompositeOps)t.GetProperty("composite_op").GetValue(function.Params, null)).ShouldEqual(CompositeOps.OverCompositeOp);

        };
    }

    [Subject(typeof(CompositeFunction))]
    public class when_only_supplying_custom_values
    {
        static CompositeFunction function;

        Because of = () => function = new CompositeFunction("Text", true, 1, 2, CompositeOps.AtopCompositeOp);

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            t.GetProperty("src").GetValue(function.Params, null).ToString().ShouldEqual("src");
            ((int)t.GetProperty("x").GetValue(function.Params, null)).ShouldEqual(1);
            ((int)t.GetProperty("y").GetValue(function.Params, null)).ShouldEqual(2);
            ((bool)t.GetProperty("as_mask").GetValue(function.Params, null)).ShouldEqual(true);
            ((CompositeOps)t.GetProperty("composite_op").GetValue(function.Params, null)).ShouldEqual(CompositeOps.AtopCompositeOp);

        };
    }
}
