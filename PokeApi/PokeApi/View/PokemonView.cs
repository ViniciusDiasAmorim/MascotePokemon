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
            Console.Clear();
            Console.WriteLine("--------------------Menu--------------------");
            Console.WriteLine($"{nome} oque gostaria de Fazer?");
            Console.WriteLine("1 - Ver os Pokemons.");
            Console.WriteLine("2 - Interagir com os Pokemons que voce capturou.");
            Console.WriteLine("3 - Sair.");
        }

        public void MostraPokemonsView(Dictionary<int, Species> pokemonsEncontrados, Search search)
        {
            Console.Clear();
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
            Console.WriteLine("3 - Para escolher um Pokemon desta lista.");
            Console.WriteLine();
            Console.WriteLine("0 - Para voltar ao menu principal.");
        }

        public Species EscolhePokemonView(Dictionary<int, Species> pokemonsEncontrados)
        {
            Console.Clear();

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
            Console.WriteLine($"2 - Capturar o {pokemon.Name}");
            Console.WriteLine();
            Console.WriteLine("3 - Para voltar aos Pokemons.");
            Console.WriteLine();
            Console.WriteLine("0 - Para voltar ao menu principal.");

            return pokemon;
        }
        public void InformacaoDoPokemonView(Pokemon pokemon)
        {
            Console.Clear();
            Console.WriteLine($"--------------------{pokemon.Name}--------------------");
            Console.WriteLine($"Nome: {pokemon.Name}");
            Console.WriteLine($"Altura: {pokemon.Height}");
            Console.WriteLine($"Peso: {pokemon.Weight}");
            Console.WriteLine($"Habilidades:");
            foreach (var p in pokemon.Abilities)
            {
                if (pokemon.Abilities[0] == p)
                    Console.Write($"{p.AbilityAbility.Name} |");

                else
                    Console.Write($" {p.AbilityAbility.Name} |");
            }
            Console.WriteLine();
            Console.WriteLine("Tipos do Pokemon: ");
            foreach (var p in pokemon.Types)
            {
                Console.WriteLine($"{p.Type.Name}");
            }
            Console.WriteLine();
            Console.WriteLine($"Deseja Adotar o {pokemon.Name}");
            Console.WriteLine();
            Console.WriteLine("1 -  Sim");
            Console.WriteLine();
            Console.WriteLine("2 - Ver outros pokemons");
        }

        public void AdocaoDoPokemonView(PokemonCapturado pokemon)
        {
            Console.Clear();
            Console.WriteLine($"--------------------Parabens Voce Adotou o {pokemon.Name}--------------------");
            Console.WriteLine($"Nome: {pokemon.Name}");
            Console.WriteLine($"Altura: {pokemon.Height}");
            Console.WriteLine($"Peso: {pokemon.Weight}");
            Console.WriteLine($"Habilidades:");
            foreach (var p in pokemon.Abilities)
            {
                if (pokemon.Abilities[0] == p)
                    Console.Write($"{p.AbilityAbility.Name} |");

                else
                    Console.Write($" {p.AbilityAbility.Name} |");
            }
            Console.WriteLine();
            Console.WriteLine("Tipos do Pokemon: ");
            foreach (var p in pokemon.Types)
            {
                Console.WriteLine($"{p.Type.Name}");
            }
            Console.WriteLine();
            Console.WriteLine($"Saude:{pokemon.Saude}");
            Console.WriteLine();
            Console.WriteLine($"Humor:{pokemon.Humor}");
            Console.WriteLine();
            Console.WriteLine($"Fome: {pokemon.Fome}");
            Console.WriteLine();
            Console.WriteLine("Digite qualquer tecla para voltar ao menu");
            Console.ReadLine();
        }
        public void MostraPokemonsCapturadosView(List<PokemonCapturado> pokemonCapturados)
        {
            Console.Clear();
            Console.WriteLine("--------------------Seus Pokemons--------------------");

            int i = 0;
            foreach (var p in pokemonCapturados)
            {
                i++;
                Console.WriteLine($"{i} - {p.Name}");
            }

            Console.WriteLine("Digite o numero do pokemon com o qual deseja interagir.");
        }
        public void InteracaoComPetView(PokemonCapturado pokemon)
        {
            Console.Clear();
            Console.WriteLine($"--------------------{pokemon.Name}--------------------");
            Console.WriteLine($"Nome: {pokemon.Name}");
            Console.WriteLine($"Altura: {pokemon.Height}");
            Console.WriteLine($"Peso: {pokemon.Weight}");
            Console.WriteLine($"Data de Captura: {pokemon.DataDeCaptura}");
            Console.WriteLine($"Habilidades:");
            foreach (var p in pokemon.Abilities)
            {
                if (pokemon.Abilities[0] == p)
                    Console.Write($"{p.AbilityAbility.Name} |");

                else
                    Console.Write($" {p.AbilityAbility.Name} |");
            }
            Console.WriteLine();
            Console.WriteLine("Tipos do Pokemon: ");
            foreach (var p in pokemon.Types)
            {
                Console.WriteLine($"{p.Type.Name}");
            }
            Console.WriteLine();
            Console.WriteLine($"Saude:{pokemon.Saude}");
            Console.WriteLine();
            Console.WriteLine($"Humor:{pokemon.Humor}");
            Console.WriteLine();
            Console.WriteLine($"Fome: {pokemon.Fome}");
            Console.WriteLine();
            Console.WriteLine($"Como deseja interagir com o {pokemon.Name}");
            Console.WriteLine($"1 - Alimentar o {pokemon.Name}");
            Console.WriteLine($"2 - Brincar com o {pokemon.Name}");
            Console.WriteLine($"3 - Batalhar");
            Console.WriteLine($"0 - Para sair.");
        }
    }
}
