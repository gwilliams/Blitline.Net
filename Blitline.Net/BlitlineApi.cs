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
                             width = width,
                             height = height
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
                              x = x,
                              y = y,
                              width = width,
                              height = height
                          };
        }
    }



    public class BlitlineApi
    {
        readonly IRestClient _client;
        readonly string _applicationId;
        readonly string _rootUrl;

        public BlitlineApi(IRestClient client, string applicationId)
        {
            _client = client;
            _applicationId = applicationId;
            _rootUrl = "http://api.blitline.com/job";
        }

        public IRestResponse ProcessImages(BlitlineRequest blitlineRequest)
        {
            _client.BaseUrl = _rootUrl;

            var request = new RestRequest(Method.POST) {RequestFormat = DataFormat.Json};
            var payload = new
                              {
                                  json = blitlineRequest
                              };
            
            request.AddBody(payload);

            return _client.Post(request);
        }

        public IRestResponse ResizeImage(string imageUrl, int width, int height, string imageIdentifier)
        {
            _client.BaseUrl = _rootUrl;
            var payload = new
            
                {
                    json = new {
                    application_id = _applicationId,
                    version = 2,
                    src = imageUrl,
                    functions = new[]
                                    {
                                        new
                                            {
                                                name = "resize_to_fit",
                                                @params = new {width = 240, height = 140},
                                                save = new
                                                           {
                                                               image_identifier = imageIdentifier,
                                                               s3_destination = new
                                                                                    {
                                                                                        bucket ="elevate-test-photos",
                                                                                        key ="herp-derp.jpg"
                                                                                    }
                                                           }
                                            }
                                    }
                    }

            };

            var restRequest = new RestRequest(Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(payload);
            return _client.Post(restRequest);
        }
    }
}
