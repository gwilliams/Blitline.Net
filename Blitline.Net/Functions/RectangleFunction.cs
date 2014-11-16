using System;
using System.Dynamic;
using Blitline.Net.Functions;

namespace Blitline.Net.Functions
{
	public class RectangleFunction : BlitlineFunction
	{
		public override string Name 
		{
			get { return "rectangle"; }
		}

		public override dynamic Params 
		{
			get { return new {}; }
		}

		/// <summary>
		/// Starting X coordinate
		/// </summary>
		public int StartX { get; set; }

		/// <summary>
		/// Starting Y coordinate
		/// </summary>
		public int StartY { get; set; }

		/// <summary>
		/// Ending X coordinate
		/// </summary>
		public int EndX { get; set; }

		/// <summary>
		/// Ending Y coordinate
		/// </summary>
		public int EndY { get; set; }

		/// <summary>
		/// Color of stroke (default "#ffffff")
		/// </summary>
		public string Color { get; set; }

		/// <summary>
		/// Width of rectangle perimeter(stroke) line (default 0, no stroke)
		/// </summary>
		public int StrokeWidth { get; set; }

		/// <summary>
		/// Opacity of stroke (default 1.0)
		/// </summary>
		public decimal StrokeOpacity { get; set; }

		/// <summary>
		/// Color to fill the rectangle with (defaults to 'color' value)
		/// </summary>
		public string FillColor { get; set; }

		/// <summary>
		/// Opacity of fill (defaults to 1.0)
		/// </summary>
		public decimal FillOpacity { get; set; }

		/// <summary>
		/// corner height. If present, will cause rounded corners, and REQUIRES 'cw' attribute as well
		/// </summary>
		public int CornerHeight { get; set; }

		/// <summary>
		/// corner width. If present, will cause rounded corners, and REQUIRES 'ch' attribute as well
		/// </summary>
		public int CornerWidth { get; set; }

		public RectangleFunction ()
		{
			Color = "#FFFFFF";
			StrokeOpacity = 1.0m;
			FillColor = Color;
			FillOpacity = 1.0m;
		}

		public override void Validate ()
		{
			if (CornerHeight > 0 && CornerWidth <= 0)
				throw new ArgumentException ("CornerHeight requires CornerWidth");

			if (CornerWidth > 0 && CornerHeight <= 0)
				throw new ArgumentException ("CornerWidth requires CornerHeight");
		}
	}
	
}
