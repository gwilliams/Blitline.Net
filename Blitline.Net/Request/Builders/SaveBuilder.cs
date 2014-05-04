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

        public SaveBuilder WithExtension(Extension extension)
        {
            _save.Extension = extension;
            return this;
        }

        public SaveBuilder WithQuality(int quality)
        {
            _save.Quality = quality;
            return this;
        }

        public SaveBuilder ToS3(Action<S3DestinationBuilder> build)
        {
	        var s3DestinationBuilder = new S3DestinationBuilder();
	        build(s3DestinationBuilder);
			_save.S3Destination = s3DestinationBuilder.Build();
            return this;
        }

        public SaveBuilder ToAzure(Action<AzureDestinationBuilder> build)
        {
            var azureDestinationBuilder = new AzureDestinationBuilder();
            build(azureDestinationBuilder);
            _save.AzureDestination = azureDestinationBuilder.Build();
            return this;
        }

        public SaveBuilder ToFtp(Action<FtpDestinationBuilder> build)
        {
            var ftpDestinationBuilder = new FtpDestinationBuilder();
            build(ftpDestinationBuilder);
            _save.FtpDestination = ftpDestinationBuilder.Build();
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

        protected override Save BuildImp
        {
            get { return _save; }
        }

        internal override Save Build()
        {
	        BuildImp.Validate();
            return BuildImp;
        }
    }
}