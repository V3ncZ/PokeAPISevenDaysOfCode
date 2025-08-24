using PokeAPISevenDaysOfCode.Model;

public class PokemonListResponse
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public List<Pokemon> Results { get; set; } = new();
}
