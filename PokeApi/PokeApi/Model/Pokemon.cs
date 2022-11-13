using Newtonsoft.Json;

namespace PokeApi.Models
{
    public partial class Pokemon
    {
        [JsonProperty("abilities")]
        public List<Ability> Abilities { get; set; }

        [JsonProperty("base_experience")]
        public long BaseExperience { get; set; }

        [JsonProperty("forms")]
        public List<Species> Forms { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("held_items")]
        public List<object> HeldItems { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("past_types")]
        public List<object> PastTypes { get; set; }

        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("types")]
        public List<TypeElement> Types { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }
    }
    public partial class TypeElement : TypeElementBase
    {
    }
}
