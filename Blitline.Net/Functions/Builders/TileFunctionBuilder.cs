using System;
using Blitline.Net.Functions.Builders;

namespace Blitline.Net
{
	public class TileFunctionBuilder : FunctionBuilder<TileFunction>
	{
		public TileFunction WithSource (string source)
		{
			BuildImp.Source = source;
			return BuildImp;
		}

		public TileFunction WithScale (decimal scale)
		{
			BuildImp.Scale = scale;
			return BuildImp;
		}

		public TileFunction WithDimensions (int height, int width)
		{
			BuildImp.Height = height;
			BuildImp.Width = width;
			return BuildImp;
		}
	}
}

