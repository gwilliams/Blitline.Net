using System.Collections.Generic;
using System.Collections.ObjectModel;
using RestSharp;

namespace Blitline.Net
{
    public class BlitlineRequest
    {
        public string application_id { get; set; }
        public string src { get; set; }
        public string postback_url { get; set; }
        public ICollection<BlitlineFunction> functions { get; set; }
        
        public BlitlineRequest(string applicationId, string sourceImage)
        {
            application_id = applicationId;
            src = sourceImage;
            functions = new Collection<BlitlineFunction>();
        }

        public void AddFunction(BlitlineFunction function)
        {
            functions.Add(function);
        }
    }

    public abstract class BlitlineFunction
    {
        public abstract string name { get; }
        public abstract object @params { get; set; }
        public Save save { get; set; }
        public ICollection<BlitlineFunction> functions { get; set; }

        public void AddFunction(BlitlineFunction function)
        {
            functions.Add(function);
        }
    }

    public class Save
    {
        public string image_identifier { get; set; }
        public int quality { get; set; }
        public S3Destination s3_destination { get; set; }

        public Save()
        {
            quality = 75;
        }
    }

    public class S3Destination
    {
        public string bucket { get; set; }
        public string key { get; set; }
    }

    public class ResizeToFitFunction : BlitlineFunction
    {
        public override string name
        {
            get { return "resize_to_fit"; }
        }

        public override object @params { get; set; }

        public ResizeToFitFunction(int width, int height)
        {
            @params = new
                         {
                             width, height
                         };
        }
    }

    public class CropFunction : BlitlineFunction
    {
        public override string name
        {
            get { return "crop"; }
        }

        public override object @params { get; set; }

        public CropFunction(int x, int y, int width, int height)
        {
            @params = new
                          {
                              x,
                              y,
                              width,
                              height
                          };
        }
    }



    public class BlitlineApi
    {
        readonly IRestClient _client;
        const string RootUrl = "http://api.blitline.com/job";

        public BlitlineApi(IRestClient client)
        {
            _client = client;
        }

        public IRestResponse ProcessImages(BlitlineRequest blitlineRequest)
        {
            _client.BaseUrl = RootUrl;

            var request = new RestRequest(Method.POST) {RequestFormat = DataFormat.Json};
            var payload = new
                              {
                                  json = blitlineRequest
                              };
            
            request.AddBody(payload);

            return _client.Post(request);
        }
    }
}
