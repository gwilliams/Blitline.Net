using System;
using Blitline.Net.Functions;
using Blitline.Net.ParamOptions;
namespace Blitline.Net
{
	public class PadFunction : BlitlineFunction
	{
		public PadFunction ()
		{
			Gravity = Gravity.CenterGrativty;
			Colour = "#FFFFFF";
		}

		public override string Name {
			get {
				return "pad";
			}
		}

		public override dynamic Params {
			get {
				return new {
					size = Size,
					gravity = Gravity,
					color = Colour
				};
			}
		}

		public int Size { get; set; }
		public Gravity Gravity { get; set; }
		public string Colour { get; set; }

		public override void Validate ()
		{
			if (Size == 0) throw new ArgumentException ("Size is required", "Size");
		}
	}
}

