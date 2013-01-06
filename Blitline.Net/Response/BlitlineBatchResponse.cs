using System;
using System.Collections.Generic;
using System.Linq;

namespace Blitline.Net.Response
{
    public class BlitlineBatchResponse : BlitlineResponse
    {
        public new IEnumerable<Results> Results { get; set; }

        public override bool Failed
        {
            get { return Results.Any(r => !string.IsNullOrEmpty(r.Error)); }
        }

        public override void FixS3Urls(Dictionary<string, string> imageKeyBucketList)
        {
            foreach (var image in Results.SelectMany(r => r.Images))
            {
                var uri = new Uri(image.S3Url);
                var imageName = uri.Segments[uri.Segments.Length - 1];

                if (imageKeyBucketList.ContainsKey(imageName))
                {
                    var bucketName = imageKeyBucketList[imageName];
                    image.S3Url = string.Format(NewAmazonUri, uri.Scheme, bucketName, imageName);
                }
            }
        }
    }
}