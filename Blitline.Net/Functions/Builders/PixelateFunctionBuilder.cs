using Blitline.Net.Functions.Builders;

namespace Blitline.Net.Functions.Builders
{
	public class PixelateFunctionBuilder : FunctionBuilder<PixelateFunction>
	{
		public PixelateFunctionBuilder WithX(int x)
		{
			BuildImp.X = x;
			return this;
		}

		public PixelateFunctionBuilder WithY(int y)
		{
			BuildImp.Y = y;
			return this;
		}

		public PixelateFunctionBuilder WithWidth(int width)
		{
			BuildImp.Width = width;
			return this;
		}

		public PixelateFunctionBuilder WithHeight(int height)
		{
			BuildImp.Height = height;
			return this;
		}

		public PixelateFunctionBuilder WithAmount(int amount)
		{
			BuildImp.Amount = amount;
			return this;
		}
	}
}
