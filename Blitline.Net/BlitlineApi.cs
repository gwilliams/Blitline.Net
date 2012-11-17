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

    public abstract class UberBuilder<T>
    {
        protected abstract T BuildImp();

        public abstract T Build();
    }

    public abstract class Builder<T> : UberBuilder<T> where T : Function
    {
        protected List<BlitlineFunction> Functions { get; set; }

        protected Builder()
        {
            Functions = new List<BlitlineFunction>();
        }
        
        public override T Build()
        {
            var o = BuildImp();
            o.Functions.AddRange(Functions);
            return o;
        }

        public Builder<T> WithCropFunction(Func<CropFunctionBuilder, CropFunction> build)
        {
            Functions.Add(build(new CropFunctionBuilder()));
            return this;
        }

    }

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

    public class SaveBuilder : UberBuilder<Save>
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

        protected override Save BuildImp()
        {
            return _save;
        }

        public override Save Build()
        {
            return BuildImp();
        }
    }

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

    public abstract class FunctionBuilder<T> : Builder<T>
        where T : Function
    {
        protected BlitlineFunction Function;

        public FunctionBuilder<T> SaveAs(Func<SaveBuilder, Save> build)
        {
            Function.Save = build(new SaveBuilder());
            return this;
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
    }
}
