using System;
using System.Collections.Generic;
using System.Net.Http;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;
using Newtonsoft.Json;

namespace Blitline.Net
{
    public class BlitlineApi : IBlitlineApi
    {
        const string RootUrl = "http://api.blitline.com/job";
        
        public BlitlineResponse ProcessImages(BlitlineRequest blitlineRequest)
        {
            var payload = JsonConvert.SerializeObject(blitlineRequest);
            
            using (var client = new HttpClient())
            {
                var result = client.PostAsync(RootUrl, new FormUrlEncodedContent(new Dictionary<string, string>{{"json", payload}}));
                var o = result.Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<BlitlineResponse>(o);
            }
        }
    }

    public static class BuildA
    {
        public static RequestBuilder Request()
        {
            return new RequestBuilder();
        }
    }
    
    public abstract class Builder<T>
    {
        public abstract T BuildImp();

        public Builder<T> WithCropFunction(Func<CropFunctionBuilder, CropFunction> build)
        {
            build(new CropFunctionBuilder());
            return this;
        }

        public T Build()
        {
            var o = BuildImp();
            return o;
        }
    }

    public class RequestBuilder : Builder<BlitlineRequest>
    {
        private readonly BlitlineRequest _request;

        public RequestBuilder()
        {
            _request = new BlitlineRequest();    
        }

        public RequestBuilder WithApplicationId(string applicationId)
        {
            _request.ApplicationId = applicationId;
            return this;
        }

        public RequestBuilder WithSourceImageUri(Uri sourceImageUri)
        {
            _request.SourceImage = sourceImageUri.AbsoluteUri;
            return this;
        }

        public override BlitlineRequest BuildImp()
        {
            return _request;
        }
    }

    public class CropFunctionBuilder : Builder<CropFunction>
    {
        private CropFunction _function;

        public CropFunctionBuilder()
        {
            _function = new CropFunction(0,0,0,0);
        }

        public CropFunctionBuilder WithDimensions(int x, int y, int width, int height)
        {
            _function = new CropFunction(x, y, width, height);
            return this;
        }

        public override CropFunction BuildImp()
        {
            return _function;
        }
    }
}
