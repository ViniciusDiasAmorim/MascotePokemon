using PokeApi.Models;

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
            Saude = random.Next(5,100);
            Humor = random.Next(5,100);
            Fome = random.Next(5,100);
            DataDeCaptura = DateTime.Now;
        }

        public void AlimentarMascote()
        {
        }

        public void BrincarMascote()
        {
           
        }

        public void SaudeMascote()
        {
        }
    }
}
