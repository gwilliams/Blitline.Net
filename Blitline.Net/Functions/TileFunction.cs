using System;
using Blitline.Net.Functions;
using System.Dynamic;
using System.Linq;
namespace Blitline.Net
{
	public class TileFunction : BlitlineFunction
	{
		public TileFunction ()
		{
			Scale = 1.0m;
		}

		public override string Name {
			get {
				throw new NotImplementedException ();
			}
		}

		public override dynamic Params {
			get {
				return new {
					src = Source,
					scale = Scale,
					width = Width,
					height = Height
				};
			}
		}

		public string Source { get; set; }
		public decimal Scale { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}
}

