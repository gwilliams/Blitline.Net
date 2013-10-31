using System;
using Newtonsoft.Json;

namespace Blitline.Net.Request
{
    public class FtpDestination
    {
        [JsonProperty("server")]
        public string Server { get; set; }
        [JsonProperty("directory")]
        public string Directory { get; set; }
        [JsonProperty("filename")]
        public string FileName { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Server)) throw new ArgumentNullException("Server", "Server is required");
            if (string.IsNullOrEmpty(FileName)) throw new ArgumentNullException("FileName", "FileName is required");
            if (string.IsNullOrEmpty(User)) throw new ArgumentNullException("User", "User is required");
            if (string.IsNullOrEmpty(Password)) throw new ArgumentNullException("Password", "Password is required");

            if (string.IsNullOrEmpty(Directory))
            {
                Directory = "/";
            }
        }
    }
}