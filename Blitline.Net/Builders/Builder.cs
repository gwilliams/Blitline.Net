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
            var o = BuildImp;
            o.Functions.AddRange(Functions);
            return o;
        }

        public Builder<T> Annotate(Func<AnnotateFunctionBuilder, AnnotateFunction> build)
        {
            Functions.Add(build(new AnnotateFunctionBuilder()));
            return this;
        }

        public Builder<T> Append(Func<AppendFunctionBuilder, AppendFunction> build)
        {
            Functions.Add(build(new AppendFunctionBuilder()));
            return this;
        }

        public Builder<T> Blur(Func<BlurFunctionBuilder, BlurFunction> build)
        {
            Functions.Add(build(new BlurFunctionBuilder()));
            return this;
        }

        public Builder<T> Composite(Func<CompositeFunctionBuilder, CompositeFunction> build)
        {
            Functions.Add(build(new CompositeFunctionBuilder()));
            return this;
        }

        public Builder<T> Contrast(Func<ContrastFunctionBuilder, ContrastFunction> build)
        {
            Functions.Add(build(new ContrastFunctionBuilder()));
            return this;
        }

        public Builder<T> ContrastStretchChannel(Func<ContrastStretchChannelFunctionBuilder, ContrastStretchChannelFunction> build)
        {
            Functions.Add(build(new ContrastStretchChannelFunctionBuilder()));
            return this;
        }

        public Builder<T> Crop(Func<CropFunctionBuilder, CropFunction> build)
        {
            Functions.Add(build(new CropFunctionBuilder()));
            return this;
        }

        public Builder<T> Deskew(Func<DeskewFunctionBuilder, DeskewFunction> build)
        {
            Functions.Add(build(new DeskewFunctionBuilder()));
            return this;
        }

        public Builder<T> Equalize(Func<EqualizeFunctionBuilder, EqualizeFunction> build)
        {
            Functions.Add(build(new EqualizeFunctionBuilder()));
            return this;
        }

        public Builder<T> GammaChannel(Func<GammaChannelFunctionBuilder, GammaChannelFunction> build)
        {
            Functions.Add(build(new GammaChannelFunctionBuilder()));
            return this;
        }

        public Builder<T> MedianFilter(Func<MedianFilterFunctionBuilder, MedianFilterFunction> build)
        {
            Functions.Add(build(new MedianFilterFunctionBuilder()));
            return this;
        }

        public Builder<T> Modulate(Func<ModulateFunctionBuilder, ModulateFunction> build)
        {
            Functions.Add(build(new ModulateFunctionBuilder()));
            return this;
        }

        public Builder<T> NoOp(Func<NoOpFunctionBuilder, NoOpFunction> build)
        {
            Functions.Add(build(new NoOpFunctionBuilder()));
            return this;
        }

        public Builder<T> PadResizeToFit(Func<PadResizeToFitFunctionBuilder, PadResizeToFitFunction> build)
        {
            Functions.Add(build(new PadResizeToFitFunctionBuilder()));
            return this;
        }

        public Builder<T> Photograph(Func<PhotographFunctionBuilder, PhotographFunction> build)
        {
            Functions.Add(build(new PhotographFunctionBuilder()));
            return this;
        }

        public Builder<T> Quantize(Func<QuantizeFunctionBuilder, QuantizeFunction> build)
        {
            Functions.Add(build(new QuantizeFunctionBuilder()));
            return this;
        }

        public Builder<T> Resize(Func<ResizeFunctionBuilder, ResizeFunction> build)
        {
            Functions.Add(build(new ResizeFunctionBuilder()));
            return this;
        }

        public Builder<T> ResizeToFill(Func<ResizeToFillFunctionBuilder, ResizeToFillFunction> build)
        {
            Functions.Add(build(new ResizeToFillFunctionBuilder()));
            return this;
        }

        public Builder<T> ResizeToFit(Func<ResizeToFitFunctionBuilder, ResizeToFitFunction> build)
        {
            Functions.Add(build(new ResizeToFitFunctionBuilder()));
            return this;
        }

        public Builder<T> Rotate(Func<RotateFunctionBuilder, RotateFunction> build)
        {
            Functions.Add(build(new RotateFunctionBuilder()));
            return this;
        }
        
        public Builder<T> Scale(Func<ScaleFunctionBuilder, ScaleFunction> build)
        {
            Functions.Add(build(new ScaleFunctionBuilder()));
            return this;
        }
    
        public Builder<T> SepiaTone(Func<SepiaToneFunctionBuilder, SepiaToneFunction> build)
        {
            Functions.Add(build(new SepiaToneFunctionBuilder()));
            return this;
        }
 
        public Builder<T> Sharpen(Func<SharpenFunctionBuilder, SharpenFunction> build)
        {
            Functions.Add(build(new SharpenFunctionBuilder()));
            return this;
        }

        public Builder<T> Sketch(Func<SketchFunctionBuilder, SketchFunction> build)
        {
            Functions.Add(build(new SketchFunctionBuilder()));
            return this;
        }

        public Builder<T> Trim(Func<TrimFunctionBuilder, TrimFunction> build)
        {
            Functions.Add(build(new TrimFunctionBuilder()));
            return this;
        }

        public Builder<T> UnsharpMask(Func<UnsharpMaskFunctionBuilder, UnsharpMaskFunction> build)
        {
            Functions.Add(build(new UnsharpMaskFunctionBuilder()));
            return this;
        }

        public Builder<T> Vignette(Func<VignetteFunctionBuilder, VignetteFunction> build)
        {
            Functions.Add(build(new VignetteFunctionBuilder()));
            return this;
        }

        public Builder<T> Watermark(Func<WatermarkFunctionBuilder, WatermarkFunction> build)
        {
            Functions.Add(build(new WatermarkFunctionBuilder()));
            return this;
        }
    }
}