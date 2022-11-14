using Newtonsoft.Json;
using PokeApi.Model;
using PokeApi.Models;
using PokeApi.Services;

Console.WriteLine("Bem vindo ao PokeAdotaApi !!");

Console.WriteLine("Qual o seu Nome ?");

string nome = Console.ReadLine();

Console.Clear();

bool rodaPrograma = true;

while (rodaPrograma)
{
    Console.WriteLine("--------------------Menu--------------------");
    Console.WriteLine($"{nome} oque gostaria de Fazer?");
    Console.WriteLine("1 - Ver os Pokemons.");
    Console.WriteLine("2 - Ver os Pokemons que voce capturou.");
    Console.WriteLine("3 - Sair.");

    string opt = Console.ReadLine();

    PokemonService pokemonService = new PokemonService();

    switch (opt)
    {
        case "1":
            bool buscaMascote = true;
            Console.Clear();
            var search = await pokemonService.SearchPokemonAsync(null);
            while (buscaMascote)
            {
                if (search != null)
                {
                    var pokemonsEncontrados = await pokemonService.GetAllPokemon(search.Results);

                    foreach (var item in pokemonsEncontrados)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value.Name}");
                    }

                    Console.WriteLine("Encontrou algum Pokemon que voce deseja?");

                    if (search.Next != null)
                    {
                        Console.WriteLine("1 - Caso deseje avançar para a proxima pagina.");
                    }

                    if (search.Previous != null)
                    {
                        Console.WriteLine("2 - Caso deseje voltar para a pagina anterior.");
                    }

                    Console.WriteLine("3 - Para escolher um Pokemon desta lista");

                    string optBusca = Console.ReadLine();
                    Console.Clear();

                    switch (optBusca)
                    {
                        case "1": search = await pokemonService.SearchPokemonAsync(search.Next); break;
                        case "2": search = await pokemonService.SearchPokemonAsync(search.Previous); break;
                        case "3": buscaMascote = false; var pokemonEscolhido = EscolhePokemon(pokemonsEncontrados, pokemonService); break;
                        default:
                            Console.WriteLine("Acho que voce digitou um valor nao esperado. Voce sera redirecionado para o menu.");
                            buscaMascote = false;
                            break;
                    }
                }
            }
            break;

        case "3": rodaPrograma = false; break;
    }
}

static async Task<Species> EscolhePokemon(Dictionary<int, Species> pokemonsEncontrados, PokemonService pokemonService)
{
    Pokemon pokemonInfo = new Pokemon();

    foreach (var item in pokemonsEncontrados)
    {
        Console.WriteLine($"{item.Key} - {item.Value.Name}");
    }

    Console.WriteLine("Digite o numero do pokemon que voce deseja");

    int pokemonEscolhido = int.Parse(Console.ReadLine());

    if (pokemonsEncontrados.TryGetValue(pokemonEscolhido, out var pokemon)) ;
    {
        Console.WriteLine(pokemon.Name);
    }

    Console.WriteLine("Oque deseja?");
    Console.WriteLine($"1 - Saber mais sobre o {pokemon.Name}");
    Console.WriteLine($"2 - Adotar o {pokemon.Name}");
    string opt = Console.ReadLine();
    switch (opt)
    {
        case "1": pokemonInfo = await pokemonService.GetPokemon(pokemon.Url); break;
    }
    Console.Clear();
    Console.WriteLine($"Nome: {pokemonInfo.Name}");
    Console.WriteLine($"Altura: {pokemonInfo.Height}");
    Console.WriteLine($"Peso: {pokemonInfo.Weight}");
    Console.WriteLine($"Habilidades:");
    foreach (var p in pokemonInfo.Abilities)
    {
        Console.WriteLine(p.AbilityAbility.Name);
    }
    Console.ReadLine();
    return pokemon;
}