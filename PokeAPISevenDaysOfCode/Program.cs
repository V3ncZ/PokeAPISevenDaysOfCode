using System.Security.Cryptography.X509Certificates;
using PokeAPISevenDaysOfCode.Services;

// Remove the local Main method and use top-level statements for the entry point
var client = new HttpClient();

var pokeClient = new PokeApiClient(client);

// Await the asynchronous method to get the result
var page = await pokeClient.GetPokemonAsync(50, 0);

foreach (var pokemon in page.Results)
{
    Console.WriteLine(pokemon.Name);
}