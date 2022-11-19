using PokeApi.Models;
using PokeApi.Services;

namespace PokeApi.Model
{
    public class PokemonCapturado : Pokemon
    {
        public int Saude { get; set; }
        public int Humor { get; set; }
        public int Fome { get; set; }
        public DateTime DataDeCaptura { get; set; }

        Random random = new Random();

        public PokemonCapturado()
        {
            Saude = random.Next(5, 100);
            Humor = random.Next(5, 100);
            Fome = random.Next(5, 100);
            DataDeCaptura = DateTime.Now;
        }

        public void AlimentarMascote()
        {
            Console.Clear();
            int modificador = random.Next(1, 10);
            
            if(Saude + modificador < 100)
            {
                Console.WriteLine($"Ganho na Saude = {Saude} ++ {Saude + modificador}");
            }
            else
            {
                Console.WriteLine($"Ganho na Saude = {Saude} ++ {Saude + modificador}");
                Console.WriteLine($"A saude do {Name} eh 100");
            }
          
            if(Fome - modificador > 0)
            {
                Console.WriteLine($"Diminuiçao na Fome =  {Fome} -- {Fome - modificador}");
            }
            else
            {
                Console.WriteLine($"Diminuiçao na Fome =  {Fome} -- {Fome - modificador}");
                Console.WriteLine($"A fome do {Name} eh 0");
            }

            Saude += modificador;
            Fome -= modificador;

            if (Saude > 100) Saude = 100;
                   
            if (Fome < 0) Fome = 0;
            

            Console.WriteLine("Pressione qualquer tecla para voltar.");
            Console.ReadLine();
        }
        public void BrincarMascote()
        {
            Console.Clear();

            int modificador = random.Next(1, 10);

            if(Humor + modificador < 100)
            {
                Console.WriteLine($"Ganho de Humor = {Humor} ++ {Humor + modificador}");
            }
            else
            {
                Console.WriteLine($"Ganho de Humor = {Humor} ++ {Humor + modificador}");
                Console.WriteLine($"O humor do {Name} eh 100");
            }
            
            if(Fome < 100)
            {
                Console.WriteLine($"Ganho de Fome =  {Fome}  ++  {Fome + modificador}");
            }
            else
            {
                Console.WriteLine($"Ganho de Fome = {Fome} ++ {Fome + modificador}");
                Console.WriteLine($"A Fome {Fome} eh 100");
            }

            Humor += modificador;
            Fome += modificador;

            if(Humor > 100) Humor = 100;
            if(Fome > 100) Fome = 100;

            Console.WriteLine("Pressione qualquer tecla para voltar.");
            Console.ReadLine();
        }

        public void Batalhar()
        {
            Console.Clear();

            int idPokemonRandomico = random.Next(1, 1154);

            Uri urlPokemonEncontrado = new Uri($"https://pokeapi.co/api/v2/pokemon/{idPokemonRandomico}");

            PokemonService pokemonService = new PokemonService();

            Pokemon pokemonEncontrado = Task.Run(() => pokemonService.GetPokemon(urlPokemonEncontrado)).Result;

            int danosSofridos = random.Next(5, 50);

            Console.WriteLine($"Voce encontrou um {pokemonEncontrado.Name} !!!!");

            if (Saude - danosSofridos <= 0)
            {
                Console.WriteLine($"Oh nao o {Name} foi derrotado");
                Console.WriteLine("Pressione qualquer tecla para voltar.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Isso ai o {Name} vence a luta contra o {pokemonEncontrado.Name}");
            }

            int modificadorHumor = random.Next(5, 50);
            int modificadorFome = random.Next(3, 15);

            Console.WriteLine($"Danos na Saude = {Saude} -- {Saude - danosSofridos}");
            Console.WriteLine($"Perca no Humor = {Humor} -- {Humor - modificadorHumor}");
            Console.WriteLine($"Aumento da Fome =  {Fome} ++ {Fome + modificadorFome}");

            Saude -= danosSofridos;
            Humor -= modificadorHumor;
            Fome += modificadorFome;

            if (Saude < 0) Saude = 0;
            
            if(Humor < 0) Humor = 0;

            if (Fome > 100) Fome = 100;

            Console.WriteLine("Pressione qualquer tecla para voltar.");
            Console.ReadLine();
        }
    }
}
