namespace PokeAPISevenDaysOfCode.Model
{
    public class Pokemon
    {

        public string Name { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }

        public List<AbilitiesList> Abilities { get; set; }

        public string Url { get; set; }

    }
}
