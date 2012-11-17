using System;
using Blitline.Net.Builders;

namespace Blitline.Net.Request.Builders
{
    public class RequestBuilder : Builder<BlitlineRequest>
    {
        readonly BlitlineRequest _request;

        public RequestBuilder()
        {
            _request = new BlitlineRequest();    
        }

        public RequestBuilder WithApplicationId(string id)
        {
            _request.ApplicationId = id;
            return this;
        }

        public RequestBuilder WithSourceImageUri(Uri uri)
        {
            _request.SourceImage = uri.AbsoluteUri;
            return this;
        }

        protected override BlitlineRequest BuildImp()
        {
            return _request;
        }
    }
}