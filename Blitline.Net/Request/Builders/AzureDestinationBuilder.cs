using Blitline.Net.Builders;

namespace Blitline.Net.Request.Builders
{
    public class AzureDestinationBuilder : BuilderBase<AzureDestination>
    {
        private readonly AzureDestination _azureDestination;

        public AzureDestinationBuilder()
        {
            _azureDestination = new AzureDestination();
        }

        public AzureDestinationBuilder WithAccountName(string accountName)
        {
            _azureDestination.AccountName = accountName;
            return this;
        }

        public AzureDestinationBuilder WithSharedAccessSignature(string sharedAccessSignature)
        {
            _azureDestination.SharedAccessSignature = sharedAccessSignature;
            return this;
        }

        protected override AzureDestination BuildImp
        {
            get { return _azureDestination; }
        }

        internal override AzureDestination Build()
        {
            AzureDestination o = BuildImp;
            o.Validate();
            return o;
        }
    }
}