using PokeApi.Model;
using PokeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.View
{
    public class PokemonView
    {
        public void MenuView(string nome)
        {
            Console.WriteLine("--------------------Menu--------------------");
            Console.WriteLine($"{nome} oque gostaria de Fazer?");
            Console.WriteLine("1 - Ver os Pokemons.");
            Console.WriteLine("2 - Ver os Pokemons que voce capturou.");
            Console.WriteLine("3 - Sair.");
        }

        public void MostraPokemonsView(Dictionary<int, Species> pokemonsEncontrados, Search search)
        {
            Console.WriteLine("--------------------Pokemons Encontrados--------------------");

            foreach (var item in pokemonsEncontrados)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Name}");
            }
            Console.WriteLine();
            Console.WriteLine("Encontrou algum Pokemon que voce deseja?");
            Console.WriteLine();
            if (search.Next != null)
            {
                Console.WriteLine("1 - Caso deseje avançar para a proxima pagina.");
            }
            Console.WriteLine();
            if (search.Previous != null)
            {
                Console.WriteLine("2 - Caso deseje voltar para a pagina anterior.");
            }
            Console.WriteLine();
            Console.WriteLine("3 - Para escolher um Pokemon desta lista");
        }

        public Species EscolhePokemonView(Dictionary<int, Species> pokemonsEncontrados)
        {
            foreach (var item in pokemonsEncontrados)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Name}");
            }
            Console.WriteLine();
            Console.WriteLine("Digite o numero do pokemon que voce deseja");

            int pokemonEscolhido = int.Parse(Console.ReadLine());

            if (pokemonsEncontrados.TryGetValue(pokemonEscolhido, out var pokemon))
            {
                Console.WriteLine(pokemon.Name);
            }

            Console.Clear();
            Console.WriteLine("Oque deseja?");
            Console.WriteLine();
            Console.WriteLine($"1 - Saber mais sobre o {pokemon.Name}");
            Console.WriteLine();
            Console.WriteLine($"2 - Adotar o {pokemon.Name}");
            Console.WriteLine();
            
            return pokemon;
        }
        public void InformacaoDoPokemon(Pokemon pokemon)
        {
            Console.Clear();
            Console.WriteLine($"Nome: {pokemon.Name}");
            Console.WriteLine($"Altura: {pokemon.Height}");
            Console.WriteLine($"Peso: {pokemon.Weight}");
            Console.WriteLine($"Habilidades:");
            foreach (var p in pokemon.Abilities)
            {
                Console.WriteLine(p.AbilityAbility.Name);
            }
        }
    }
}
