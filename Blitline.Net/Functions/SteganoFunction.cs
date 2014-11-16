using Blitline.Net.Functions;
using System;

namespace Blitline.Net.Functions
{

	public class SteganoFunction : BlitlineFunction
	{
		public override string Name 
		{
			get { return "stegano"; }
		}

		public override dynamic Params 
		{
			get 
			{
				return new {watermark_url = WatermarkUrl, offset = Offset};
			}
		}

		/// <summary>
		/// Url of watermark to embed in image (must be grayscale)
		/// </summary>
		public Uri WatermarkUrl { get; set; }

		/// <summary>
		/// Pixel offset from beginning of image to embed hidden watermark (defaults to 0.0)
		/// </summary>
		public decimal Offset { get; set; }

		public SteganoFunction ()
		{
			Offset = 0.0m;
		}

		public override void Validate ()
		{
			if (WatermarkUrl == null || !WatermarkUrl.IsAbsoluteUri)
				throw new ArgumentException ("WatermarkUrl is required and has to be absolute url");
		}

	}
}
