using Blitline.Net.Functions;
using Blitline.Net.Functions.Builders;

namespace Blitline.Net.Functions.Builders
{
	public class ImaggaSmartCropFunctionBuilder : FunctionBuilder<ImaggaSmartCropFunction>
	{
		public ImaggaSmartCropFunctionBuilder WithResolution(string resolution) 
		{
			BuildImp.Resolution = resolution;
			return this;
		}

		public ImaggaSmartCropFunctionBuilder WithNoScaling()
		{
			BuildImp.NoScaling = true;
			return this;
		}
	}

}
