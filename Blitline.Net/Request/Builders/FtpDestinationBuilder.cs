using Blitline.Net.Builders;

namespace Blitline.Net.Request.Builders
{
    public class FtpDestinationBuilder : BuilderBase<FtpDestination>
    {
        private readonly FtpDestination _ftpDestination;

        public FtpDestinationBuilder()
        {
            _ftpDestination = new FtpDestination();
        }

        public FtpDestinationBuilder WithServer(string server)
        {
            _ftpDestination.Server = server;
            return this;
        }

        public FtpDestinationBuilder WithDirectory(string directory)
        {
            _ftpDestination.Directory = directory;
            return this;
        }

        public FtpDestinationBuilder WithFileName(string fileName)
        {
            _ftpDestination.FileName = fileName;
            return this;
        }

        public FtpDestinationBuilder WithUser(string user)
        {
            _ftpDestination.User = user;
            return this;
        }

        public FtpDestinationBuilder WithPassword(string password)
        {
            _ftpDestination.Password = password;
            return this;
        }

        protected override FtpDestination BuildImp
        {
            get { return _ftpDestination; }
        }

        internal override FtpDestination Build()
        {
            FtpDestination o = BuildImp;
            o.Validate();
            return o;
        }
    }
}