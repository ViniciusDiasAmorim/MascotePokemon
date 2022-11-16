using PokeApi.Model;
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
            var search = await pokemonService.SearchPokemon(null);
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
                        case "1": search = await pokemonService.SearchPokemon(search.Next); break;

                        case "2": search = await pokemonService.SearchPokemon(search.Previous); break;

                        case "3": buscaMascote = false;

                            Species pokemon = pokemonView.EscolhePokemonView(pokemonsEncontrados);

                            string optPokemon = Console.ReadLine();

                            //Mostra as caracteristicas do pokemon
                            if(optPokemon == "1")
                            {
                                Pokemon pokemonInfo = new Pokemon();
                                pokemonInfo = await pokemonService.GetPokemon(pokemon.Url);
                                pokemonView.InformacaoDoPokemon(pokemonInfo);
                                string optAdotarOuProcurar = Console.ReadLine();
                                Console.Clear();
                            }
                            //Adota o pokemon
                            else if(optPokemon == "2")
                            {
                                Pokemon pokemonInfo = new Pokemon();
                                pokemonInfo = await pokemonService.GetPokemon(pokemon.Url);
                                PokemonCapturado pokemonCapturado = new PokemonCapturado()
                                {
                                    Abilities = pokemonInfo.Abilities,
                                    Height = pokemonInfo.Height,
                                    Id = pokemonInfo.Id,
                                    Name = pokemonInfo.Name,
                                    Species = pokemonInfo.Species,
                                    Types = pokemonInfo.Types,
                                    Weight = pokemonInfo.Weight,
                                };

                                pokemonView.AdocaoDoPokemon(pokemonCapturado);
                            }
                            else
                            {
                                Console.WriteLine("Ops acho que voce digitou um valor fora do esperado.");
                            }
                            
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