using System;
using System.Collections.Generic;
using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;
using Blitline.Net.Request;

namespace Blitline.Net.Builders
{
    public abstract class Builder<T> : BuilderBase<T> where T : Function
    {
        protected List<BlitlineFunction> Functions { get; set; }

        protected Builder()
        {
            Functions = new List<BlitlineFunction>();
        }
        
        public override T Build()
        {
            return BuildImp;
        }

        private Builder<T> AddFunction<TBuilder, TFunction>(Func<TBuilder, TFunction> build)
            where TFunction : BlitlineFunction, new() 
            where TBuilder : FunctionBuilder<TFunction>,  new()
        {
            BuildImp.Functions.Add(build(new TBuilder()));
            return this;
        }

        public Builder<T> Annotate(Func<AnnotateFunctionBuilder, AnnotateFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Append(Func<AppendFunctionBuilder, AppendFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Blur(Func<BlurFunctionBuilder, BlurFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Composite(Func<CompositeFunctionBuilder, CompositeFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Contrast(Func<ContrastFunctionBuilder, ContrastFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> ContrastStretchChannel(Func<ContrastStretchChannelFunctionBuilder, ContrastStretchChannelFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Crop(Func<CropFunctionBuilder, CropFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Deskew(Func<DeskewFunctionBuilder, DeskewFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Equalize(Func<EqualizeFunctionBuilder, EqualizeFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> GammaChannel(Func<GammaChannelFunctionBuilder, GammaChannelFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> MedianFilter(Func<MedianFilterFunctionBuilder, MedianFilterFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Modulate(Func<ModulateFunctionBuilder, ModulateFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> NoOp(Func<NoOpFunctionBuilder, NoOpFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> PadResizeToFit(Func<PadResizeToFitFunctionBuilder, PadResizeToFitFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Photograph(Func<PhotographFunctionBuilder, PhotographFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Quantize(Func<QuantizeFunctionBuilder, QuantizeFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Resize(Func<ResizeFunctionBuilder, ResizeFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> ResizeToFill(Func<ResizeToFillFunctionBuilder, ResizeToFillFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> ResizeToFit(Func<ResizeToFitFunctionBuilder, ResizeToFitFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Rotate(Func<RotateFunctionBuilder, RotateFunction> build)
        {
            return AddFunction(build);
        }
        
        public Builder<T> Scale(Func<ScaleFunctionBuilder, ScaleFunction> build)
        {
            return AddFunction(build);
        }
    
        public Builder<T> SepiaTone(Func<SepiaToneFunctionBuilder, SepiaToneFunction> build)
        {
            return AddFunction(build);
        }
 
        public Builder<T> Sharpen(Func<SharpenFunctionBuilder, SharpenFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Sketch(Func<SketchFunctionBuilder, SketchFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Trim(Func<TrimFunctionBuilder, TrimFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> UnsharpMask(Func<UnsharpMaskFunctionBuilder, UnsharpMaskFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Vignette(Func<VignetteFunctionBuilder, VignetteFunction> build)
        {
            return AddFunction(build);
        }

        public Builder<T> Watermark(Func<WatermarkFunctionBuilder, WatermarkFunction> build)
        {
            return AddFunction(build);
        }
    }
}