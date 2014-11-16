using System;

namespace Blitline.Net.Functions.Builders
{
	public class SteganoFunctionBuilder : FunctionBuilder<SteganoFunction>
	{
		public SteganoFunctionBuilder WithWatermarkUrl(Uri watermarkUrl)
		{
			BuildImp.WatermarkUrl = watermarkUrl;
			return this;
		}

		public SteganoFunctionBuilder WithOffset(decimal offset)
		{
			BuildImp.Offset = offset;
			return this;
		}
	}
    
}
