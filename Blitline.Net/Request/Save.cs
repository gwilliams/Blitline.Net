namespace Blitline.Net.Request
{
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
}