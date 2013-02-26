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

		internal override T Build()
		{
			return BuildImp;
		}

		private void AddFunction<TBuilder, TFunction>(Action<TBuilder> build)
			where TFunction : BlitlineFunction, new()
			where TBuilder : FunctionBuilder<TFunction>, new()
		{
			var builder = new TBuilder();
			build(builder);
			TFunction function = builder.Build();
			BuildImp.Functions.Add(function);
		}

		public Builder<T> Annotate(Action<AnnotateFunctionBuilder> build)
		{
			AddFunction<AnnotateFunctionBuilder, AnnotateFunction>(build);
			return this;
		}

		public Builder<T> Append(Action<AppendFunctionBuilder> build)
		{
			AddFunction<AppendFunctionBuilder, AppendFunction>(build);
			return this;
		}

		public Builder<T> Blur(Action<BlurFunctionBuilder> build)
		{
			AddFunction<BlurFunctionBuilder, BlurFunction>(build);
			return this;
		}

	    public Builder<T> Composite(Action<CompositeFunctionBuilder> build)
		{
			AddFunction<CompositeFunctionBuilder, CompositeFunction>(build);
			return this;
		}

		public Builder<T> Contrast(Action<ContrastFunctionBuilder> build)
		{
			AddFunction<ContrastFunctionBuilder, ContrastFunction>(build);
			return this;
		}

		public Builder<T> ContrastStretchChannel(Action<ContrastStretchChannelFunctionBuilder> build)
		{
			AddFunction<ContrastStretchChannelFunctionBuilder, ContrastStretchChannelFunction>(build);
			return this;
		}

		public Builder<T> Crop(Action<CropFunctionBuilder> build)
		{
			AddFunction<CropFunctionBuilder, CropFunction>(build);
			return this;
		}

		public Builder<T> Deskew(Action<DeskewFunctionBuilder> build)
		{
			AddFunction<DeskewFunctionBuilder, DeskewFunction>(build);
			return this;
		}

		public Builder<T> Equalize(Action<EqualizeFunctionBuilder> build)
		{
			AddFunction<EqualizeFunctionBuilder, EqualizeFunction>(build);
			return this;
		}

	    public Builder<T> GammaChannel(Action<GammaChannelFunctionBuilder> build)
		{
			AddFunction<GammaChannelFunctionBuilder, GammaChannelFunction>(build);
			return this;
		}

		public Builder<T> MedianFilter(Action<MedianFilterFunctionBuilder> build)
		{
			AddFunction<MedianFilterFunctionBuilder, MedianFilterFunction>(build);
			return this;
		}

	    public Builder<T> Modulate(Action<ModulateFunctionBuilder> build)
		{
			AddFunction<ModulateFunctionBuilder, ModulateFunction>(build);
			return this;
		}

	    public Builder<T> NoOp(Action<NoOpFunctionBuilder> build)
		{
			AddFunction<NoOpFunctionBuilder, NoOpFunction>(build);
			return this;
		}

	    public Builder<T> PadResizeToFit(Action<PadResizeToFitFunctionBuilder> build)
		{
			AddFunction<PadResizeToFitFunctionBuilder, PadResizeToFitFunction>(build);
			return this;
		}

		public Builder<T> Photograph(Action<PhotographFunctionBuilder> build)
		{
			AddFunction<PhotographFunctionBuilder, PhotographFunction>(build);
			return this;
		}

		public Builder<T> Quantize(Action<QuantizeFunctionBuilder> build)
		{
			AddFunction<QuantizeFunctionBuilder, QuantizeFunction>(build);
			return this;
		}

		public Builder<T> Resize(Action<ResizeFunctionBuilder> build)
		{
			AddFunction<ResizeFunctionBuilder, ResizeFunction>(build);
			return this;
		}

		public Builder<T> ResizeToFill(Action<ResizeToFillFunctionBuilder> build)
		{
			AddFunction<ResizeToFillFunctionBuilder, ResizeToFillFunction>(build);
			return this;
		}

		public Builder<T> ResizeToFit(Action<ResizeToFitFunctionBuilder> build)
		{
			AddFunction<ResizeToFitFunctionBuilder, ResizeToFitFunction>(build);
			return this;
		}

		public Builder<T> Rotate(Action<RotateFunctionBuilder> build)
		{
			AddFunction<RotateFunctionBuilder, RotateFunction>(build);
			return this;
		}

		public Builder<T> Scale(Action<ScaleFunctionBuilder> build)
		{
			AddFunction<ScaleFunctionBuilder, ScaleFunction>(build);
			return this;
		}

		public Builder<T> SepiaTone(Action<SepiaToneFunctionBuilder> build)
		{
			AddFunction<SepiaToneFunctionBuilder, SepiaToneFunction>(build);
			return this;
		}

		public Builder<T> Sharpen(Action<SharpenFunctionBuilder> build)
		{
			AddFunction<SharpenFunctionBuilder, SharpenFunction>(build);
			return this;
		}

	    public Builder<T> Sketch(Action<SketchFunctionBuilder> build)
		{
			AddFunction<SketchFunctionBuilder, SketchFunction>(build);
			return this;
		}

	    public Builder<T> Trim(Action<TrimFunctionBuilder> build)
		{
			AddFunction<TrimFunctionBuilder, TrimFunction>(build);
			return this;
		}

	    public Builder<T> UnsharpMask(Action<UnsharpMaskFunctionBuilder> build)
		{
			AddFunction<UnsharpMaskFunctionBuilder, UnsharpMaskFunction>(build);
			return this;
		}

	    public Builder<T> Vignette(Action<VignetteFunctionBuilder> build)
		{
			AddFunction<VignetteFunctionBuilder, VignetteFunction>(build);
			return this;
		}

	    public Builder<T> Watermark(Action<WatermarkFunctionBuilder> build)
		{
			AddFunction<WatermarkFunctionBuilder, WatermarkFunction>(build);
			return this;
		}
	}
}