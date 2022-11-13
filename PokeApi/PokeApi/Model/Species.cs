using Newtonsoft.Json;

namespace PokeApi.Models
{
    public class SpeciesBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}