using Blitline.Net.Functions.Builders;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Blitline.Net.Functions.Builders
{
    public class AppendFunctionBuilder : FunctionBuilder<AppendFunction>
    {
        public AppendFunctionBuilder AppendVeritically(bool vertical)
        {
            BuildImp.Vertical = vertical;
            return this;
        }

		public AppendFunctionBuilder WithOtherImages(params Uri[] uris) 
		{
			return WithOtherImages (uris.ToList ());
		}

		public AppendFunctionBuilder WithOtherImages(IEnumerable<Uri> uris) 
		{
			BuildImp.OtherImages = string.Join (",", uris);
			return this;
		}

    }
}
