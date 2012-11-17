using System;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.crop
{
    [Subject(typeof(CropFunction))]
    public class when_creating_crop_function
    {
        static CropFunction function;

        Because of = () => function = new CropFunction(1, 2, 3, 4);

        It it_should_set_values_on_params = () =>
        {
            Type t = function.Params.GetType();
            ((int)t.GetProperty("x").GetValue(function.Params, null)).ShouldEqual(1);
            ((int)t.GetProperty("y").GetValue(function.Params, null)).ShouldEqual(2);
            ((int)t.GetProperty("width").GetValue(function.Params, null)).ShouldEqual(3);
            ((int)t.GetProperty("height").GetValue(function.Params, null)).ShouldEqual(4);
        };
    }
}
