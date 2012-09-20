using System;
using Blitline.Net.Functions;
using Machine.Specifications;

namespace Specs.Unit.Blur
{
     [Subject(typeof(BlurFunction))]
    public class when_creating_blur_function
    {
        static BlurFunction annotate;

        Because of = () => annotate = new BlurFunction(10, 5);

        It it_should_set_values_on_params = () =>
        {
            Type t = annotate.Params.GetType();
            ((decimal)t.GetProperty("sigma").GetValue(annotate.Params, null)).ShouldEqual(10);
            ((decimal)t.GetProperty("radius").GetValue(annotate.Params, null)).ShouldEqual(5);
        };
    }
}
