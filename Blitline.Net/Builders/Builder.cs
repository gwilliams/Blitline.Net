using System;
using System.Collections.Generic;
using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;
using Blitline.Net.Request;

namespace Blitline.Net.Builders
{
    public abstract class Builder<T> : UberBuilder<T> where T : Function
    {
        protected List<BlitlineFunction> Functions { get; set; }

        protected Builder()
        {
            Functions = new List<BlitlineFunction>();
        }
        
        public override T Build()
        {
            var o = BuildImp();
            o.Functions.AddRange(Functions);
            return o;
        }

        public Builder<T> WithAnnotateFunction(Func<AnnotateFunctionBuilder, AnnotateFunction> build)
        {
            Functions.Add(build(new AnnotateFunctionBuilder()));
            return this;
        }

        public Builder<T> WithAppendFunction(Func<AppendFunctionBuilder, AppendFunction> build)
        {
            Functions.Add(build(new AppendFunctionBuilder()));
            return this;
        }

        public Builder<T> WithBlurFunction(Func<BlurFunctionBuilder, BlurFunction> build)
        {
            Functions.Add(build(new BlurFunctionBuilder()));
            return this;
        }

        public Builder<T> WithCompositeFunction(Func<CompositeFunctionBuilder, CompositeFunction> build)
        {
            Functions.Add(build(new CompositeFunctionBuilder()));
            return this;
        }

        public Builder<T> WithContrastFunction(Func<ContrastFunctionBuilder, ContrastFunction> build)
        {
            Functions.Add(build(new ContrastFunctionBuilder()));
            return this;
        }

        public Builder<T> WithContrastStretchChannelFunction(Func<ContrastStretchChannelFunctionBuilder, ContrastStretchChannelFunction> build)
        {
            Functions.Add(build(new ContrastStretchChannelFunctionBuilder()));
            return this;
        }

        public Builder<T> WithCropFunction(Func<CropFunctionBuilder, CropFunction> build)
        {
            Functions.Add(build(new CropFunctionBuilder()));
            return this;
        }

        public Builder<T> WithDeskewFunction(Func<DeskewFunctionBuilder, DeskewFunction> build)
        {
            Functions.Add(build(new DeskewFunctionBuilder()));
            return this;
        }

        public Builder<T> WithEqualizeFunction(Func<EqualizeFunctionBuilder, EqualizeFunction> build)
        {
            Functions.Add(build(new EqualizeFunctionBuilder()));
            return this;
        }

        public Builder<T> WithGammaChannelFunction(Func<GammaChannelFunctionBuilder, GammaChannelFunction> build)
        {
            Functions.Add(build(new GammaChannelFunctionBuilder()));
            return this;
        }

        public Builder<T> WithMedianFilterFunction(Func<MedianFilterFunctionBuilder, MedianFilterFunction> build)
        {
            Functions.Add(build(new MedianFilterFunctionBuilder()));
            return this;
        }

        public Builder<T> WithModulateFunction(Func<ModulateFunctionBuilder, ModulateFunction> build)
        {
            Functions.Add(build(new ModulateFunctionBuilder()));
            return this;
        }

        public Builder<T> WithNoOpFunction(Func<NoOpFunctionBuilder, NoOpFunction> build)
        {
            Functions.Add(build(new NoOpFunctionBuilder()));
            return this;
        }

        public Builder<T> WithPadResizeToFitFunction(Func<PadResizeToFitFunctionBuilder, PadResizeToFitFunction> build)
        {
            Functions.Add(build(new PadResizeToFitFunctionBuilder()));
            return this;
        }

        public Builder<T> WithPhotographFunction(Func<PhotographFunctionBuilder, PhotographFunction> build)
        {
            Functions.Add(build(new PhotographFunctionBuilder()));
            return this;
        }

        public Builder<T> WithQuantizeFunction(Func<QuantizeFunctionBuilder, QuantizeFunction> build)
        {
            Functions.Add(build(new QuantizeFunctionBuilder()));
            return this;
        }

        public Builder<T> WithResizeFunction(Func<ResizeFunctionBuilder, ResizeFunction> build)
        {
            Functions.Add(build(new ResizeFunctionBuilder()));
            return this;
        }

        public Builder<T> WithResizeToFillFunction(Func<ResizeToFillFunctionBuilder, ResizeToFillFunction> build)
        {
            Functions.Add(build(new ResizeToFillFunctionBuilder()));
            return this;
        }

        public Builder<T> WithResizeToFitFunction(Func<ResizeToFitFunctionBuilder, ResizeToFitFunction> build)
        {
            Functions.Add(build(new ResizeToFitFunctionBuilder()));
            return this;
        }

        public Builder<T> WithRotateFunction(Func<RotateFunctionBuilder, RotateFunction> build)
        {
            Functions.Add(build(new RotateFunctionBuilder()));
            return this;
        }
        
        public Builder<T> WithScaleFunction(Func<ScaleFunctionBuilder, ScaleFunction> build)
        {
            Functions.Add(build(new ScaleFunctionBuilder()));
            return this;
        }
    
        public Builder<T> WithSepiaToneFunction(Func<SepiaToneFunctionBuilder, SepiaToneFunction> build)
        {
            Functions.Add(build(new SepiaToneFunctionBuilder()));
            return this;
        }
 
        public Builder<T> WithSharpenFunction(Func<SharpenFunctionBuilder, SharpenFunction> build)
        {
            Functions.Add(build(new SharpenFunctionBuilder()));
            return this;
        }
    }
}