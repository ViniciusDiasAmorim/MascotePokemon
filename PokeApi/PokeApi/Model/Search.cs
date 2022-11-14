using Newtonsoft.Json;
using PokeApi.Models;

namespace PokeApi.Model
{
    public class Search
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public Uri Previous { get; set; }

        [JsonProperty("results")]
        public List<Species> Results { get; set; }
    }

}

