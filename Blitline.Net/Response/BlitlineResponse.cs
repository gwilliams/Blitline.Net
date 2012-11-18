using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Blitline.Net.Response
{
    public class BlitlineResponse
    {
        public Results Results { get; set; }

        public bool Failed { get { return !string.IsNullOrEmpty(Results.Error); } }

        public void FixS3Urls(Dictionary<string, string> imageKeyBucketList)
        {
            const string newUri = "{0}://{1}.s3.amazonaws.com/{2}";

            foreach (var image in Results.Images)
            {
                var uri = new Uri(image.S3Url);
                var imageName = uri.Segments[uri.Segments.Length - 1];
                var bucketName = imageKeyBucketList[imageName.Remove(imageName.LastIndexOf('.'))];
                image.S3Url = string.Format(newUri, uri.Scheme, bucketName, imageName);
            }
        }
    }
}