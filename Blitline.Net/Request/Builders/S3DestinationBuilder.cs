using Blitline.Net.Builders;

namespace Blitline.Net.Request.Builders
{
    public class S3DestinationBuilder : UberBuilder<S3Destination>
    {
        readonly S3Destination _s3Destination;

        public S3DestinationBuilder()
        {
            _s3Destination = new S3Destination();
        }

        public S3DestinationBuilder WithBucketName(string bucketName)
        {
            _s3Destination.Bucket = bucketName;
            return this;
        }

        public S3DestinationBuilder WithKey(string key)
        {
            _s3Destination.Key = key;
            return this;
        }

        protected override S3Destination BuildImp()
        {
            return _s3Destination;
        }

        public override S3Destination Build()
        {
            return BuildImp();
        }
    }
}