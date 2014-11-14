using System;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Deletes color profile information
    /// </summary>
    public class DeleteProfileFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "delete_profile"; }
        }

        public override dynamic Params
        {
            get { return new {name = ProfileName}; }
        }

        /// <summary>
        /// Name of the profile to remove (or * to remove wildcard)
        /// </summary>
        public string ProfileName { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(ProfileName)) throw new ArgumentException("Text cannot be empty");
        }
    }
}