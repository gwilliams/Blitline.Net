using System;
using Blitline.Net.Functions;

namespace Blitline.Net
{
	public class LevelizeFunction : BlitlineFunction
	{
		public LevelizeFunction ()
		{
			BlackPoint = 0.0m;
			WhitePoint = 65535.0m;
			Channel = "AllChannels";
		}

		public override string Name {
			get {
				return "levelize";
			}
		}

		public override dynamic Params {
			get {
				return new {
					channel = Channel,
					black_point = BlackPoint,
					white_point = WhitePoint,
					gamma = Gamma
				};
			}
		}

		public string Channel { get; set; }
		public decimal BlackPoint { get; set; }
		public decimal WhitePoint { get; set; }
		public decimal Gamma { get; set; }
	}
}

