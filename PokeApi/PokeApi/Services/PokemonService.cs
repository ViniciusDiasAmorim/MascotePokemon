using Newtonsoft.Json;
using PokeApi.Model;
using PokeApi.Models;

namespace PokeApi.Services
{
    public class PokemonService
    {
        public async Task<Search> SearchPokemon(Uri url)
        {
            if (url == null)
            {
                url = new Uri("https://pokeapi.co/api/v2/pokemon/");
            }

            using HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var searchPokemon = JsonConvert.DeserializeObject<Search>(content);

                return searchPokemon;
            }

            return null;
        }

        public Dictionary<int, Species> ListaPokemon(List<Species> species)
        {
            Dictionary<int, Species> pokemonsEncontrados = new Dictionary<int, Species>();

            int id = 1;

            foreach (var item in species)
            {
                pokemonsEncontrados.Add(id, item);
                id++;
            }

            return pokemonsEncontrados;
        }

        public async Task<Pokemon> GetPokemon(Uri url)
        {
            using HttpClient client = new HttpClient();

            var responseDadosDoPokemon = await client.GetAsync(url);

            if (responseDadosDoPokemon.IsSuccessStatusCode)
            {
                var contentDadosDoPokemon = await responseDadosDoPokemon.Content.ReadAsStringAsync();
               
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(contentDadosDoPokemon);

                return pokemon;
            }

            return null;
        }
    }
}

