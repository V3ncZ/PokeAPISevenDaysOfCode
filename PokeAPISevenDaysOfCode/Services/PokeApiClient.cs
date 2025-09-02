using System.Text.Json;
using PokeAPISevenDaysOfCode.Exceptions;
using PokeAPISevenDaysOfCode.Model;

namespace PokeAPISevenDaysOfCode.Services
{
    public class PokeApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://pokeapi.co/api/v2/";

        public PokeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonListResponse> GetPokemonAsync(int limit = 200, int offset = 0)
        {
            // 1.Monta a URL com paginação
            var url = $"{_baseUrl}pokemon?limit={limit}&offset={offset}";

            // 2. Faz a requisição
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // 3. Lê o JSON como string
            var jsonString = await response.Content.ReadAsStringAsync();

            // 4. Desserializa para o modelo
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<PokemonListResponse>(jsonString, options);

            return result!;
        }

        public async Task<Pokemon> GetSpecificPokemon(string name)
        {
            var url = $"{_baseUrl}/pokemon/{name}";

            var response = await _httpClient.GetAsync(url);

            // Verifica se a resposta foi um NotFound e lanca a excecao
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new PokemonNaoEncontradoException();
            }

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<Pokemon>(jsonString, options);

            return result;
        }
    }
}
