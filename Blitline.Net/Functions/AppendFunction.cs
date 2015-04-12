namespace Blitline.Net.Functions
{
    /// <summary>
    /// Appends images together either vertically or horizontally
    /// </summary>
    public class AppendFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "append"; }
        }

        public override object Params {
			get {
				return new
				{
					vertical = Vertical,
					other_images = OtherImages
				};
			}
		}

        /// <summary>
        /// Whether images are appended vertically(true) or horizontally(false)
        /// </summary>
        public bool Vertical { get; set; }

		/// <summary>
		/// Comma separated list of urls to other images
		/// </summary>
		public string OtherImages {get;set;}
    }
}
