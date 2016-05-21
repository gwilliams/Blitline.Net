using System;
using Blitline.Net.Functions.Builders;
using Blitline.Net.ParamOptions;

namespace Blitline.Net
{
	public class PadFunctionBuilder : FunctionBuilder<PadFunction>
	{
		public PadFunction WithSize (int size)
		{
			BuildImp.Size = size;
			return BuildImp;
		}

		public PadFunction WithGravity (Gravity gravity)
		{
			BuildImp.Gravity = gravity;
			return BuildImp;
		}

		public PadFunction WithColour (string colour)
		{
			BuildImp.Colour = colour;
			return BuildImp;
		}
	}
}

