using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public enum Hash
    {
        [JsonProperty("md5")]
        Md5,
        [JsonProperty("crc32")]
        Crc32,
        [JsonProperty("sha256")]
        Sha256,
		[JsonProperty("phash_dct")]
		PhashDct,
		[JsonProperty("phash_mh")]
		PhashMh
    }
}