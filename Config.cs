using Newtonsoft.Json;

namespace SelfBotBase
{
    public class Config
    {
        [JsonProperty("Token")]
        public string Token { get; set; }
    }
}
