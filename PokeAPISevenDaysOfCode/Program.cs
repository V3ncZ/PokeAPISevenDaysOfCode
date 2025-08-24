using PokeAPISevenDaysOfCode.Services;

var client = new HttpClient();

var pokeClient = new PokeApiClient(client);

// Espera o método asincrono para trazer os pokemons
var page = await pokeClient.GetPokemonAsync(50, 0);

foreach (var pokemon in page.Results)
{
    Console.WriteLine(pokemon.Name);
}