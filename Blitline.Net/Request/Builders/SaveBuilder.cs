using System;
using Blitline.Net.Builders;
using Blitline.Net.ParamOptions;

namespace Blitline.Net.Request.Builders
{
    public class SaveBuilder : BuilderBase<Save>
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

        public SaveBuilder WithInterlaceType(InterlaceType interlaceType)
        {
            _save.Interlace = interlaceType.ToString();
            return this;
        }

        public SaveBuilder QuantizePng()
        {
            _save.PngQuantize = true;
            return this;
        }

        protected override Save BuildImp()
        {
            return _save;
        }

        public override Save Build()
        {
            var o = BuildImp();
            o.Validate();
            return o;
        }
    }
}