using System.Text.RegularExpressions;
using System;
using Blitline.Net.Functions;

namespace Blitline.Net.Functions
{
	public class ImaggaSmartCropFunction : BlitlineFunction
	{
		public override string Name 
		{
			get { return "imagga_smart_crop"; }
		}

		public override dynamic Params {
			get 
			{
				return new 
				{
					resolution = Resolution,
					no_scaling = NoScaling
				};
			}
		}

		/// <summary>
		/// The height and width of the desired cropped image. (Height and width are separated by a lower case 'x')
		/// </summary>
		public string Resolution { get; set; }

		/// <summary>
		/// Optional setting to not autoscale image, but to crop the raw original to the target area. Defaults to false
		/// </summary>
		public bool NoScaling { get; set; }

		public override void Validate ()
		{
			var regex = new Regex ("\\d*x\\d*$");
			if (!regex.IsMatch (Resolution))
				throw new ArgumentException ("Resolution should be height and width separated by lowecase 'x'");
		}
	}

}
