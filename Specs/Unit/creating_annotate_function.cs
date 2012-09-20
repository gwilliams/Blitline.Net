using System;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
using Machine.Specifications;

namespace Specs.Unit.Annotate
{
    [Subject(typeof(AnnotateFunction))]
    public class when_only_supplying_default_values
    {
        static AnnotateFunction function;

        Because of = () => function = new AnnotateFunction("Text");

        It it_should_set_default_values_on_params = () =>
            {
                Type t = function.Params.GetType();
                t.GetProperty("text").GetValue(function.Params, null).ToString().ShouldEqual("Text");
                ((int)t.GetProperty("x").GetValue(function.Params, null)).ShouldEqual(0);
                ((int)t.GetProperty("y").GetValue(function.Params, null)).ShouldEqual(0);
                t.GetProperty("color").GetValue(function.Params, null).ToString().ShouldEqual("#ffffff");
                t.GetProperty("font_family").GetValue(function.Params, null).ToString().ShouldEqual("Helvetica");
                ((int)t.GetProperty("point_size").GetValue(function.Params, null)).ShouldEqual(32);
                t.GetProperty("stroke").GetValue(function.Params, null).ToString().ShouldEqual("transparent");
                ((Gravity)t.GetProperty("gravity").GetValue(function.Params, null)).ShouldEqual(Gravity.CenterGrativty);
                
            };
    }

    [Subject(typeof(AnnotateFunction))]
    public class when_only_supplying_custom_values
    {
        static AnnotateFunction function;

        Because of = () => function = new AnnotateFunction("Text", 1, 2, "#ccc", "Arial", 12, "blur", Gravity.SouthGravity);

        It it_should_set_default_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            t.GetProperty("text").GetValue(function.Params, null).ToString().ShouldEqual("Text");
            ((int)t.GetProperty("x").GetValue(function.Params, null)).ShouldEqual(1);
            ((int)t.GetProperty("y").GetValue(function.Params, null)).ShouldEqual(2);
            t.GetProperty("color").GetValue(function.Params, null).ToString().ShouldEqual("#ccc");
            t.GetProperty("font_family").GetValue(function.Params, null).ToString().ShouldEqual("Arial");
            ((int)t.GetProperty("point_size").GetValue(function.Params, null)).ShouldEqual(12);
            t.GetProperty("stroke").GetValue(function.Params, null).ToString().ShouldEqual("blur");
            ((Gravity)t.GetProperty("gravity").GetValue(function.Params, null)).ShouldEqual(Gravity.SouthGravity);

        };
    }
}
