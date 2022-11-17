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

        public int Menu(string nome)
        {
            pokemonView.MenuView(nome);

            int opcao;

            if (!int.TryParse(Console.ReadLine(), out opcao)) return 0;

            return opcao;
        }

        public async Task<int> ExibePokemons()
        {
            bool buscaMascote = true;
            Search search = Task.Run(() => pokemonService.SearchPokemon(null)).Result;

            while (buscaMascote)
            {
                if (search == null) return 4;

                var pokemonsEncontrados = Task.Run(() => pokemonService.GetAllPokemon(search.Results)).Result;

                pokemonView.MostraPokemonsView(pokemonsEncontrados, search);

                int opcao;

                if (!int.TryParse(Console.ReadLine(), out opcao)) return 4;

                switch (opcao)
                {
                    case 0: return 0;
                    case 1: search = Task.Run(() => pokemonService.SearchPokemon(search.Next)).Result; break;
                    case 2: search = Task.Run(() => pokemonService.SearchPokemon(search.Previous)).Result; break;
                    case 3: return 3;
                }
            }
            return 4;
        }
    }
}
