using System;
using System.Net;

namespace Blitline.Net.Functions.Builders
{
	public class RectangleFunctionBuilder : FunctionBuilder<RectangleFunction>
	{
		public RectangleFunctionBuilder WithCoordinates(int startX, int startY, int endX, int endY)
		{
			BuildImp.StartX = startX;
			BuildImp.StartY = startY;
			BuildImp.EndX = endX;
			BuildImp.EndX = endY;

			return this;
		}

		public RectangleFunctionBuilder WithStrokeColor(string color)
		{
			BuildImp.Color = color;
			return this;
		}

		public RectangleFunctionBuilder WithStrokeWidth(int width)
		{
			BuildImp.StrokeWidth = width;
			return this;
		}

		public RectangleFunctionBuilder WithStrokeOpacity(decimal opacity)
		{
			BuildImp.StrokeOpacity = opacity;
			return this;
		}

		public RectangleFunctionBuilder WithFillColor(string color)
		{
			BuildImp.FillColor = color;
			return this;
		}

		public RectangleFunctionBuilder WithFillOpacity(decimal opacity)
		{
			BuildImp.FillOpacity = opacity;
			return this;
		}

		public RectangleFunctionBuilder WithRoundedCorners(int height, int width)
		{
			BuildImp.CornerHeight = height;
			BuildImp.CornerWidth = width;
			return this;
		}
	}
}
