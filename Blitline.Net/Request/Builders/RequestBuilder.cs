using System;
using System.Collections.Generic;
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

        public RequestBuilder FixS3ImageUrl()
        {
            _request.FixS3ImageUrl = true;
            return this;
        }

        public RequestBuilder WaitForS3()
        {
            _request.WaitForS3 = true;
            return this;
        }

        public RequestBuilder ContentTypeAsJson()
        {
            _request.ContentTypeJson = true;
            return this;
        }

        public RequestBuilder WithPostbackUri(Uri posbackUri)
        {
            _request.PostbackUrl = posbackUri.AbsoluteUri;
            return this;
        }

        public RequestBuilder WithExtendedMetaData()
        {
            _request.ExtendedMetaData = true;
            return this;
        }

        public RequestBuilder SuppressAutoOrientation()
        {
            _request.SuppressAutoOrient = true;
            return this;
        }

        public RequestBuilder WithHash(Hash hash)
        {
            _request.Hash = hash;
            return this;
        }

        public RequestBuilder SourceIsScreenshot()
        {
            _request.SourceType = "screen_shot_url";
            return this;
        }

        public RequestBuilder SourceIsMultipageDocument()
        {
            _request.SourceType = "multi_page";
            return this;
        }

        public RequestBuilder SourceIsMultipageDocument(IList<int> pages)
        {
            _request.SourceType = new MultiPageSourceType {Pages = pages};
            return this;
        }
        
        protected override BlitlineRequest BuildImp()
        {
            return _request;
        }

        public override BlitlineRequest Build()
        {
            var o = base.Build();
            o.Validate();
            return o;
        }
    }
}