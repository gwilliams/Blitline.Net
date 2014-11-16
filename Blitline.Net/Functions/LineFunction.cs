using System.Text.RegularExpressions;
using System;
using Blitline.Net.Functions;

namespace Blitline.Net.Functions
{
	/// <summary>
	/// Draws a linear line between two points
	/// </summary>
	public class LineFunction : BlitlineFunction
	{
		public override string Name 
		{
			get { return "line"; }
		}

		public override dynamic Params 
		{
			get 
			{
				return new 
				{
					x = StartX,
					y = StartY,
					x1 = EndX,
					y1 = EndY,
					width = Width,
					color = Color,
					opacity = Opacity,
					line_cap = LineCap
				};
			}
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
		/// Width of line (default 1)
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Color of line (default "#ffffff")
		/// </summary>
		public string Color { get; set; }

		/// <summary>
		/// Opacity of line (default 1.0)
		/// </summary>
		public decimal Opacity { get; set; }

		/// <summary>
		/// How the line ends. Only relevant for widths > 1. Two possible options are "butt"(default) and "round"(rounds ends).
		/// </summary>
		public LineCap LineCap { get; set; }

		public LineFunction ()
		{
			Width = 1;
			Color = "#FFFFFF";
			Opacity = 1.0m;
			LineCap = LineCap.Butt;
		}

	}
}
