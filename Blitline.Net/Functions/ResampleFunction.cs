using System;
using System.Dynamic;
using Blitline.Net.Functions;

namespace Blitline.Net.Functions
{
	/// <summary>
	/// Resample the image to a new resolution
	/// </summary>
	public class ResampleFunction : BlitlineFunction
	{
		public override string Name 
		{
			get { return "resample"; }
		}

		public override dynamic Params 
		{
			get { return new { density = Density }; } 
		}

		/// <summary>
		/// The density of the outputted image. (defaults to 72.0)
		/// </summary>
		public decimal Density { get; set; }

		public ResampleFunction ()
		{
			Density = 72.0m;
		}
	}
}
