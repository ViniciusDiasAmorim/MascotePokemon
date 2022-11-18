using PokeApi.Controller;

Console.WriteLine("Qual o seu Nome?");
string nome = Console.ReadLine();
bool rodaPrograma = true;

PokemonController pokemonController = new PokemonController();

while (rodaPrograma)
{
    int opcaoDoUsuario = pokemonController.Menu(nome);

    switch (opcaoDoUsuario)
    {
        case 0:
            Console.WriteLine("Valor fora do esperado");
            break;

        case 1:
             var resultado = Task.Run(() => pokemonController.ExibePokemons()).Result;
            break;

        case 2:
            pokemonController.ExibePokemonsCapturados();
            Console.WriteLine("Pressione qualquer tecla.");
            Console.ReadLine();
            Console.Clear();

            break;

        case 3: rodaPrograma = false; break;
    }
}
