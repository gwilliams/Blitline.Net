namespace Blitline.Net.Functions
{
	/// <summary>
	/// Applies a digital filter that improves the quality of a noisy image. Each pixel is replaced by the median in a set of neighboring pixels as defined by radius.
	/// </summary>
	public class MedianFilterFunction : BlitlineFunction
	{
		public override string Name
		{
			get { return "median_filter"; }
		}

		public override object Params { get { return new { radius = Radius }; } }

		/// <summary>
		/// Radius of blur (defaults to 1.0)
		/// </summary>
		public decimal Radius { get; set; }

		public MedianFilterFunction()
		{
			Radius = 1.0m;
		}
	}
}
