using System;
using Blitline.Net.Functions.Builders;

namespace Blitline.Net
{
	public class LiquidRescaleFunctionBuilder : FunctionBuilder<LiquidRescaleFunction>
	{
		public LiquidRescaleFunction WithDimensions (int height, int width)
		{
			BuildImp.Width = width;
			BuildImp.Height = height;
			return BuildImp;
		}

		public LiquidRescaleFunction WithDeltaX (int deltaX)
		{
			BuildImp.DeltaX = deltaX;
			return BuildImp;
		}

		public LiquidRescaleFunction WithRigidity (int rigidity)
		{
			BuildImp.Rigidity = rigidity;
			return BuildImp;
		}
	}
}

