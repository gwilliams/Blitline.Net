using Blitline.Net.Functions;
using System;

namespace Blitline.Net.Functions
{

	public class PixelateFunction : BlitlineFunction
	{
		public override string Name 
		{
			get { return "pixelate"; }
		}

		public override dynamic Params 
		{
			get 
			{
				return new 
				{
					x = X,
					y = Y,
					width = Width,
					height = Height,
					amount = Amount
				};
			}
		}

		/// <summary>
		/// X position of starting area on image (default 0)
		/// </summary>
		public int X { get; set; }

		/// <summary>
		/// Y position of starting area on image (default 0)
		/// </summary>
		public int Y { get; set; }

		/// <summary>
		/// Width of area to pixelate (defaults to width of original image)
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Height of area to pixelate (defaults to height of original image)
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// 1-100 value representing the amount to pixelate
		/// </summary>
		public int Amount { get; set; }

		public override void Validate ()
		{
			if (Amount != 0 && (Amount < 1 || Amount > 100))
				throw new ArgumentException ("Amount should be between 1 and 100");
		}

	}
}
