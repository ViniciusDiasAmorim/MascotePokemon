using Newtonsoft.Json;
using PokeApi;

HttpClient client = new HttpClient();

string url = "https://pokeapi.co/api/v2/pokemon/";

var response = await client.GetAsync(url);

var content = await response.Content.ReadAsStringAsync();

dynamic responseContent = JsonConvert.DeserializeObject(content);

List<Pokemon> pokemons = new List<Pokemon>();

foreach(var item in responseContent.results)
{
    Pokemon result = new Pokemon()
    {
        Name = item.name,
        Url = item.url
    };

    pokemons.Add(result);
}

foreach(var item in pokemons)
{
    Console.WriteLine(item.Name);
}