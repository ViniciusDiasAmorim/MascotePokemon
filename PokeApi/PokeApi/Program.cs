using Newtonsoft.Json;
using PokeApi.Model;
using PokeApi.Models;

Console.WriteLine("Bem Vindo");

Console.WriteLine("Deseja ver os Pokemons? 1 - Sim - 2 - Sair.");

string inicio = Console.ReadLine();

Console.WriteLine("------------------------------------------------");

while (inicio != "2")
{
    HttpClient client = new HttpClient();

    string url = "https://pokeapi.co/api/v2/pokemon/";

    var response = await client.GetAsync(url);

    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();

        var search = JsonConvert.DeserializeObject<Search>(content);

        Dictionary<int, Species> pokemonsEncontrados = new Dictionary<int, Species>();

        int id = 1;

        foreach (var item in search.Results)
        {
            pokemonsEncontrados.Add(id, item);
            id++;
        }

        foreach (var item in pokemonsEncontrados)
        {
            Console.WriteLine($"{item.Key} - {item.Value.Name}");
            Console.WriteLine("------------------------------------------------");
        }

        Console.WriteLine("Escolha seu pokemon digitando o numero ao qual ele corresponde");

        int pokeId = int.Parse(Console.ReadLine());

        if (pokemonsEncontrados.TryGetValue(pokeId, out var poke))
        {
            var responseDadosDoPokemon = await client.GetAsync(poke.Url);

            if (responseDadosDoPokemon.IsSuccessStatusCode)
            {
                var contentDadosDoPokemon = await responseDadosDoPokemon.Content.ReadAsStringAsync();
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(contentDadosDoPokemon);

                Console.WriteLine($"Nome: {pokemon.Name}");
                Console.WriteLine($"Altura: {pokemon.Height}");
                Console.WriteLine($"Peso: {pokemon.Weight}");
                Console.WriteLine($"Habilidade:");
                foreach (var p in pokemon.Abilities)
                {
                    Console.WriteLine(p.AbilityAbility.Name);
                }
            }
        }
    }
    Console.WriteLine("Deseja ver mais Pokemons? 1 - Sim - 2 - Sair.");

    inicio = Console.ReadLine();
}
Console.WriteLine("Obrigado por utilizar o Programa.");