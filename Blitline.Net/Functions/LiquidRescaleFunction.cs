using System;
using Blitline.Net.Functions;
namespace Blitline.Net
{
	public class LiquidRescaleFunction : BlitlineFunction
	{
		public LiquidRescaleFunction ()
		{
			DeltaX = 0;
			Rigidity = 0;
		}

		public override string Name {
			get {
				return "liquid_rescale";
			}
		}

		public override dynamic Params {
			get {
				return new {
					width = Width,
					height = Height,
					delta_x = DeltaX,
					rigidity = Rigidity
				};
			}
		}

		public int Width { get; set; }
		public int Height { get; set; }
		public int DeltaX { get; set; }
		public int Rigidity { get; set; }
	}
}

