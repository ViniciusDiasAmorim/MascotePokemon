using PokeApi.Model;
using PokeApi.Models;
using PokeApi.Services;
using PokeApi.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Controller
{
    public class PokemonController
    {
        PokemonService pokemonService = new PokemonService();
        PokemonView pokemonView = new PokemonView();
        List<PokemonCapturado> listaCapturados;
        public int Menu(string nome)
        {
            pokemonView.MenuView(nome);

            int opcao;

            if (!int.TryParse(Console.ReadLine(), out opcao)) return 0;

            return opcao;
        }

        public bool ExibePokemons()
        {
            bool buscaMascote = true;
            Search search = Task.Run(() => pokemonService.SearchPokemon(null)).Result;

            while (buscaMascote)
            {
                if (search == null)
                {
                    Console.WriteLine("Ocorreu um problema na busca dos Pokemons.");
                    return false;
                }

                var pokemonsEncontrados = Task.Run(() => pokemonService.ListaPokemon(search.Results)).Result;

                pokemonView.MostraPokemonsView(pokemonsEncontrados, search);

                int opcao;

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Acho que voce digitou um valor fora do esperado.");
                    return false;
                }

                switch (opcao)
                {
                    case 0: return false;
                    case 1: search = Task.Run(() => pokemonService.SearchPokemon(search.Next)).Result; break;
                    case 2: search = Task.Run(() => pokemonService.SearchPokemon(search.Previous)).Result; break;
                    case 3:
                        Species pokemon = pokemonView.EscolhePokemonView(pokemonsEncontrados);

                        int optPokemon;

                        if (!int.TryParse(Console.ReadLine(), out optPokemon))
                        {
                            Console.WriteLine("Acho que voce digitou um valor fora do esperado.");
                            return false;
                        }

                        if (optPokemon == 1)
                        {
                            Pokemon pokemonEscolhido = Task.Run(() => pokemonService.GetPokemon(pokemon.Url)).Result;

                            pokemonView.InformacaoDoPokemonView(pokemonEscolhido);

                            int AdotaOuVolta;

                            if (!int.TryParse(Console.ReadLine(), out AdotaOuVolta))
                            {
                                Console.WriteLine("Acho que voce digitou um valor fora do esperado.");
                                return false;
                            }

                            if (AdotaOuVolta == 1)
                            {
                                var pokemonCapturado = Adota(pokemonService, pokemonView, pokemon);
                                listaCapturados.Add(pokemonCapturado);
                                return true;
                            }
                        }

                        if (optPokemon == 2)
                        {
                            var pokemonCapturado = Adota(pokemonService, pokemonView, pokemon);
                            listaCapturados.Add(pokemonCapturado);
                            return true;
                        }

                        if (optPokemon == 0) return false;
                        break;
                }
            }
            return false;
        }

        public void ExibePokemonsCapturados()
        {
            
        }

        static PokemonCapturado Adota(PokemonService pokemonService, PokemonView pokemonView, Species pokemon)
        {

            Pokemon pokemonInfo = Task.Run(() => pokemonService.GetPokemon(pokemon.Url)).Result;

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

            pokemonView.AdocaoDoPokemonView(pokemonCapturado);

            return pokemonCapturado;

        }
    }
}
