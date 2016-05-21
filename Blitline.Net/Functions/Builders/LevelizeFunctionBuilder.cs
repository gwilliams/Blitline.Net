using System;
using Blitline.Net.Functions.Builders;

namespace Blitline.Net
{
	public class LevelizeFunctionBuilder : FunctionBuilder<LevelizeFunction>
	{
		public LevelizeFunctionBuilder WithChannel (string channel)
		{
			BuildImp.Channel = channel;
			return this;
		}

		public LevelizeFunctionBuilder WithBlackPoint (decimal blackPoint)
		{
			BuildImp.BlackPoint = blackPoint;
			return this;
		}

		public LevelizeFunctionBuilder WithWhitePoint (decimal whitePoint)
		{
			BuildImp.WhitePoint = whitePoint;
			return this;
		}

		public LevelizeFunctionBuilder WithGamma (decimal gamma)
		{
			BuildImp.Gamma = gamma;
			return this;
		}
	}
}

