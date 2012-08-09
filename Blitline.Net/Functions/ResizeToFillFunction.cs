using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    public class ResizeToFillFunction : BlitlineFunction
    {
        public override string name
        {
            get { return "resize_to_fill"; }
        }

        public override object @params { get; set; }

        public ResizeToFillFunction(int width, int height, Gravity gravity)
        {
            var g = gravity.ToString();
            @params = new
                          {
                              width,
                              height,
                              g
                          };
        }
    }
}
