using System;

namespace Blitline.Net.Functions.Builders
{
	public class ResampleFunctionBuilder : FunctionBuilder<ResampleFunction>
	{
		public ResampleFunctionBuilder WithDensity(decimal density)
		{
			BuildImp.Density = density;
			return this;
		}
	}
    
}
