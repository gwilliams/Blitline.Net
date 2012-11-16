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

    public abstract class BaseBuilder<T>
    {
        protected abstract T BuildImp();

        protected abstract void Validate();

        public T Build()
        {
            var o = BuildImp();
            Validate();
            return o;
        }
    }

    public abstract class Builder<T> : BaseBuilder<T>
    {
        protected BlitlineRequest Request = new BlitlineRequest();

        public Builder<T> WithCropFunction(Func<CropFunctionBuilder, CropFunction> build)
        {
            Request.Functions.Add(build(new CropFunctionBuilder()));
            return this;
        }

        public Builder<T> WithResizeFunction(Func<ResizeFunctionBuilder, ResizeFunction> build)
        {
            Request.Functions.Add(build(new ResizeFunctionBuilder()));
            return this;
        }
    }

    public abstract class FunctionBuilder<T> : Builder<T>
    {
        protected BlitlineFunction Function;

        public FunctionBuilder<T> SaveAs(Func<SaveBuilder, Save> build)
        {
            return this;
        }

        protected override void Validate()
        {
            //throw new NotImplementedException();
        }
    }

    public class SaveBuilder : BaseBuilder<Save>
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

        protected override void Validate()
        {
            if(string.IsNullOrEmpty(_save.ImageIdentifier)) throw new ArgumentNullException("ImageIdentifier", "ImageIdentifier is required");
        }
    }

    public class S3DestinationBuilder : BaseBuilder<S3Destination>
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

        protected override void Validate()
        {
            if(string.IsNullOrEmpty(_destination.Bucket)) throw new ArgumentNullException("Bucket", "Bucket name is required");
            if (string.IsNullOrEmpty(_destination.Key)) throw new ArgumentNullException("Key", "Key is required");
        }
    }

    public class RequestBuilder : Builder<BlitlineRequest>
    {
        public RequestBuilder()
        {
            Request = new BlitlineRequest();    
        }

        public RequestBuilder WithApplicationId(string applicationId)
        {
            Request.ApplicationId = applicationId;
            return this;
        }

        public RequestBuilder WithSourceImageUri(Uri sourceImageUri)
        {
            Request.SourceImage = sourceImageUri.AbsoluteUri;
            return this;
        }

        public RequestBuilder WaitForS3(bool waitForS3)
        {
            Request.WaitForS3 = waitForS3;
            return this;
        }

        public RequestBuilder WithPostbackUri(Uri postbackUri)
        {
            Request.PostbackUrl = postbackUri.AbsoluteUri;
            return this;
        }

        public RequestBuilder SuppressAutoOrient(bool suppressAutoOrient)
        {
            Request.SuppressAutoOrient = suppressAutoOrient;
            return this;
        }

        public RequestBuilder WithHash(Hash hash)
        {
            Request.Hash = hash;
            return this;
        }

        protected override BlitlineRequest BuildImp()
        {
            return Request;
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Request.ApplicationId)) throw new ArgumentNullException("ApplicationId", "ApplicationId is required");
            if (string.IsNullOrEmpty(Request.SourceImage)) throw new ArgumentNullException("SourceImage", "SourceImage is required");
            if (Request.Functions.Count == 0) throw new ArgumentException("Functions", "Functions are required");
        }
    }

    public class CropFunctionBuilder : FunctionBuilder<CropFunction>
    {
        public CropFunctionBuilder()
        {
            Function = new CropFunction(0, 0, 0, 0);
        }

        public CropFunctionBuilder WithDimensions(int x, int y, int width, int height)
        {
            Function = new CropFunction(x, y, width, height);
            return this;
        }

        protected override CropFunction BuildImp()
        {
            return (CropFunction)Function;
        }

        protected override void Validate()
        {
            //throw new NotImplementedException();
        }
    }

    public class ResizeFunctionBuilder : FunctionBuilder<ResizeFunction>
    {
        public ResizeFunctionBuilder()
        {
            Function = new ResizeFunction(0, 0);
        }

        public ResizeFunctionBuilder WithDimensions(int width, int height)
        {
            Function = new ResizeFunction(width, height);
            return this;
        }

        protected override ResizeFunction BuildImp()
        {
            return (ResizeFunction)Function;
        }

        protected override void Validate()
        {
            //throw new NotImplementedException();
        }
    }
}
