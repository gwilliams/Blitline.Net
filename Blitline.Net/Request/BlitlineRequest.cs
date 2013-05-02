using System;
using Blitline.Net.Functions;
using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public class PreProcess
    {
        
    }

    public class MoveOriginal
    {
        [JsonProperty("s3_destination")]
        public S3Destination S3Destination { get; set; }
    }

    public class BlitlineRequest : Function
    {
        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }
        [JsonProperty("hash")]
        public Hash? Hash { get; set; }
        [JsonProperty("suppress_auto_orient")]
        public bool SuppressAutoOrient { get; set; }
        [JsonProperty("src")]
        public string SourceImage { get; set; }
        [JsonProperty("postback_url")]
        public string PostbackUrl { get; set; }
        [JsonProperty("wait_for_s3")]
        public bool WaitForS3 { get; set; }
        [JsonProperty("content_type_json")]
        public bool ContentTypeJson { get; set; }
        [JsonProperty("extended_metadata")]
        public bool ExtendedMetaData { get; set; }
        [JsonProperty("src_type")]
        public dynamic SourceType { get; set; }

        [JsonProperty("pre_process")]
        public PreProcess PreProcess { get; set; }

        /// <summary>
        /// Blitline returns an image url such as http://s3.amazonaws.com/gdoubleu-test-photos/annotate-default.png
        /// This generally throws an error when accessing the image, with a PermanentRedirect error stating
        /// that the endpoint is incorrect and should be gdoubleu-test-photos.s3.amazonaws.com resulting in an image url of
        /// http://gdoubleu-test-photos.s3.amazonaws.com/annotate-default.png (this is http://bucketname/s3key.xxx)
        /// Enabling this will automatically convert all response urls to the above format
        /// </summary>
        public bool FixS3ImageUrl { get; set; }
        
        public void AddFunction(BlitlineFunction function)
        {
            Functions.Add(function);
        }

        public BlitlineRequest()
        {
            
        }

        public BlitlineRequest(string applicationId, string sourceUrl)
        {
            ApplicationId = applicationId;
            SourceImage = sourceUrl;
        }

        public void Validate()
        {
            if(string.IsNullOrEmpty(ApplicationId)) throw new ArgumentNullException("ApplicationId is required", "ApplicationId");
            if(string.IsNullOrEmpty(SourceImage)) throw new ArgumentNullException("SourceImage is required", "SourceImage");
            if (Functions.Count == 0) throw new ArgumentException("1 or more function required", "Functions");
        }
    }
}