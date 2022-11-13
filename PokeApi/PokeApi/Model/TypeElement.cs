using Newtonsoft.Json;

namespace PokeApi.Models
{
    public class TypeElementBase
    {
        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("type")]
        public Species Type { get; set; }
    }
}