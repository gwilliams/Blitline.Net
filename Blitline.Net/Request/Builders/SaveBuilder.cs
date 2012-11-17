using System;
using Blitline.Net.Builders;

namespace Blitline.Net.Request.Builders
{
    public class SaveBuilder : UberBuilder<Save>
    {
        readonly Save _save;

        public SaveBuilder()
        {
            _save = new Save();
        }

        public SaveBuilder WithImageIdentifier(string identifier)
        {
            _save.ImageIdentifier = identifier;
            return this;
        }

        public SaveBuilder WithExtension(string extension)
        {
            _save.Extension = extension;
            return this;
        }

        public SaveBuilder WithQuality(int quality)
        {
            _save.Quality = quality;
            return this;
        }

        public SaveBuilder WithS3Destination(Func<S3DestinationBuilder, S3Destination> build)
        {
            _save.S3Destination = build(new S3DestinationBuilder());
            return this;
        }

        protected override Save BuildImp()
        {
            return _save;
        }

        public override Save Build()
        {
            return BuildImp();
        }
    }
}