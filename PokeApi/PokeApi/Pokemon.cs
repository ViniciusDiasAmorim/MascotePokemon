using Newtonsoft.Json;

namespace PokeApi
{
    public partial class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
