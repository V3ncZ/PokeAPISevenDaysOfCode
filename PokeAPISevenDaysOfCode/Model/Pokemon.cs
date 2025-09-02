namespace PokeAPISevenDaysOfCode.Model
{
    public  class Pokemon : Mascote
    {

        public string Name { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }

        public List<AbilitiesList> Abilities { get; set; }

        public string Url { get; set; }

        

        public Pokemon() { }

        public Pokemon(string name, int height, int weight, List<AbilitiesList> abilities)
        {
            Name = name;
            Height = height;
            Weight = weight;
            Abilities = abilities;
        }

        
        public void StatusDoPokemon()
        {
            Console.WriteLine($"NOME DO POKEMON: {Name.ToUpper()}");
            Console.WriteLine($"ALTURA: {Height}");
            Console.WriteLine($"PESO: {Weight}");
            Console.WriteLine($"{Name.ToUpper()} ESTA {AlimentacaoDescricao.ToUpper()}");
            Console.WriteLine($"{Name.ToUpper()} ESTA {HumorDescricao.ToUpper()}");
            Console.WriteLine("HABILIDADES: ");
            foreach (var ability in Abilities)
            {
                Console.WriteLine($"{ability.Ability.Name}");
            }
        }

    }
}
