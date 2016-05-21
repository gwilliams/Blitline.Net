using System;
using Blitline.Net.Functions.Builders;

namespace Blitline.Net
{
	public class LevelFunctionBuilder : FunctionBuilder<LevelFunction>
	{
		public LevelFunctionBuilder WithChannel (string channel)
		{
			BuildImp.Channel = channel;
			return this;
		}

		public LevelFunctionBuilder WithBlackPoint (decimal blackPoint)
		{
			BuildImp.BlackPoint = blackPoint;
			return this;
		}

		public LevelFunctionBuilder WithWhitePoint (decimal whitePoint)
		{
			BuildImp.WhitePoint = whitePoint;
			return this;
		}

		public LevelFunctionBuilder WithGamma (decimal gamma)
		{
			BuildImp.Gamma = gamma;
			return this;
		}
	}
}

