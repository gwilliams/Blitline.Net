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
        protected abstract T BuildImp();

        public Builder<T> WithCropFunction(Func<CropFunctionBuilder, CropFunction> build)
        {
            build(new CropFunctionBuilder());
            return this;
        }

        public Builder<T> WithResizeFunction(Func<ResizeFunctionBuilder, ResizeFunction> build)
        {
            build(new ResizeFunctionBuilder());
            return this;
        }

        public T Build()
        {
            var o = BuildImp();
            return o;
        }
    }

    public abstract class FunctionBuilder<T> : Builder<T>
    {
        public FunctionBuilder<T> SaveAs(Func<SaveBuilder, Save> build)
        {
            return this;
        }
    }

    public class SaveBuilder : Builder<Save>
    {
        private readonly Save _save;

        public SaveBuilder()
        {
            _save = new Save();
        }

        public SaveBuilder WithExtension(string extension)
        {
            _save.Extension = extension;
            return this;
        }

        public SaveBuilder WithImageIdentifier(string imageIdentifier)
        {
            _save.ImageIdentifier = imageIdentifier;
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
    }

    public class S3DestinationBuilder : Builder<S3Destination>
    {
        private readonly S3Destination _destination;

        public S3DestinationBuilder()
        {
            _destination = new S3Destination();
        }

        public S3DestinationBuilder WithBucketName(string bucketName)
        {
            _destination.Bucket = bucketName;
            return this;
        }

        public S3DestinationBuilder WithKey(string key)
        {
            _destination.Key = key;
            return this;
        }

        protected override S3Destination BuildImp()
        {
            return _destination;
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

        protected override BlitlineRequest BuildImp()
        {
            return _request;
        }
    }

    public class CropFunctionBuilder : FunctionBuilder<CropFunction>
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

        protected override CropFunction BuildImp()
        {
            return _function;
        }
    }

    public class ResizeFunctionBuilder : FunctionBuilder<ResizeFunction>
    {
        private readonly ResizeFunction _function;

        public ResizeFunctionBuilder()
        {
            _function = new ResizeFunction(0, 0);
        }

        public ResizeFunctionBuilder WithDimensions()
        {
            return this;
        }

        protected override ResizeFunction BuildImp()
        {
            return _function;
        }
    }
}
