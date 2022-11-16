using PokeApi.Models;
using PokeApi.Services;
using PokeApi.View;

Console.WriteLine("Bem vindo ao PokeAdotaApi !!");
Console.WriteLine("Qual o seu Nome ?");
string nome = Console.ReadLine();

Console.Clear();

bool rodaPrograma = true;

while (rodaPrograma)
{
    PokemonService pokemonService = new PokemonService();

    PokemonView pokemonView = new PokemonView();

    pokemonView.MenuView(nome);

    string opt = Console.ReadLine();

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

                    pokemonView.MostraPokemonsView(pokemonsEncontrados, search);

                    string optBusca = Console.ReadLine();
                    Console.Clear();

                    switch (optBusca)
                    {
                        case "1": search = await pokemonService.SearchPokemonAsync(search.Next); break;

                        case "2": search = await pokemonService.SearchPokemonAsync(search.Previous); break;

                        case "3": buscaMascote = false;

                            Pokemon pokemonInfo = new Pokemon();

                            Species pokemon = pokemonView.EscolhePokemonView(pokemonsEncontrados);

                            string optPokemon = Console.ReadLine();

                            switch (optPokemon)
                            {
                                case "1": pokemonInfo = await pokemonService.GetPokemon(pokemon.Url); break;
                            }

                            pokemonView.InformacaoDoPokemon(pokemonInfo);

                            Console.ReadLine();
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Acho que voce digitou um valor nao esperado. Voce sera redirecionado para o menu.");
                            buscaMascote = false;
                            break;
                    }
                }
            }
            break;

        case "3": rodaPrograma = false; Console.WriteLine("Obrigado por utilizar o programa."); break;
    }
}