using System;
using Blitline.Net;
using Machine.Specifications;
using RestSharp;

namespace Specs
{
    [Subject("Testing Blitline")]
    public class SuperSpec
    {
        static BlitlineApi _blitline;
        static RestClient _client;

        Establish context = () =>
                                {
                                    _client = new RestClient();
                                    _blitline = new BlitlineApi(_client, "a5KqkemeX2RttyYdkOrdug");
                                    var req = new BlitlineRequest("a5KqkemeX2RttyYdkOrdug", "https://s3-eu-west-1.amazonaws.com/elevate-test-photos/gw%40gdoubleu.co.uk-new.png");
                                    //var resizeToFitFunction = new ResizeToFitFunction(240, 140)
                                    //               {
                                    //                   save = new Save
                                    //                              {
                                    //                                  image_identifier = "test_image",
                                    //                                  s3_destination = new S3Destination
                                    //                                                      {
                                    //                                                          bucket = "elevate-test-photos",
                                    //                                                          key = "another-herp-derp.png"
                                    //                                                      }
                                    //                              }
                                    //               };

                                    var cropFunction = new CropFunction(155, 250, 240, 140)
                                                           {
                                                               save = new Save
                                                                          {
                                                                              image_identifier = "test_image",
                                                                              s3_destination = new S3Destination
                                                                                                   {
                                                                                                       bucket =
                                                                                                           "elevate-test-photos",
                                                                                                       key =
                                                                                                           "cropped.png"
                                                                                                   }
                                                                          }
                                                           };
                                    req.AddFunction(cropFunction);
                                    var result = _blitline.ProcessImages(req);

                                    Console.Read();
                                };

        Because of = () => { };

        It it_should_do_something = () => { };
    }
}
