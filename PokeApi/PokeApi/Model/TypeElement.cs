using Newtonsoft.Json;

namespace PokeApi.Models
{
    public class TypeElement
    {
        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("type")]
        public Species Type { get; set; }
    }
}