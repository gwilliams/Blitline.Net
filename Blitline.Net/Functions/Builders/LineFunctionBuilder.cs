using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;

namespace Blitline.Net.Functions.Builders
{
	public class LineFunctionBuilder : FunctionBuilder<LineFunction>
	{
		public LineFunctionBuilder WithCoordinates(int startX, int startY, int endX, int endY)
		{
			BuildImp.StartX = startX;
			BuildImp.StartY = startY;
			BuildImp.EndX = endX;
			BuildImp.EndY = endX;

			return this;
		}

		public LineFunctionBuilder WithWidth(int width)
		{
			BuildImp.Width = width;
			return this;
		}

		public LineFunctionBuilder WithColor(string color)
		{
			BuildImp.Color = color;
			return this;
		}

		public LineFunctionBuilder WithOpacity(decimal opacity)
		{
			BuildImp.Opacity = opacity;
			return this;
		}

		public LineFunctionBuilder WithLineCap(LineCap lineCap)
		{
			BuildImp.LineCap = lineCap;
			return this;
		}
	}
}
