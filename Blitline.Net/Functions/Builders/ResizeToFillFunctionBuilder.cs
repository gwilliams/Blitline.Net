using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions.Builders
{
    public class ResizeToFillFunctionBuilder : FunctionBuilder<ResizeToFillFunction>
    {
        public ResizeToFillFunctionBuilder()
        {
            Function = new ResizeToFillFunction();
        }

        public ResizeToFillFunctionBuilder WithWidth(int width)
        {
            ((ResizeToFillFunction) Function).Width = width;
            return this;
        }

        public ResizeToFillFunctionBuilder WithHeight(int height)
        {
            ((ResizeToFillFunction) Function).Height = height;
            return this;
        }

        public ResizeToFillFunctionBuilder WithGravity(Gravity gravity)
        {
            ((ResizeToFillFunction) Function).Gravity = gravity;
            return this;
        }

        public ResizeToFillFunctionBuilder OnlyShrinkLarger(bool onlyShrinkLarger)
        {
            ((ResizeToFillFunction) Function).OnlyShrinkLarger = onlyShrinkLarger;
            return this;
        }

        protected override ResizeToFillFunction BuildImp()
        {
            return (ResizeToFillFunction) Function;
        }
    }
}
