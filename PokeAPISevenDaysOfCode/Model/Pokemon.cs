namespace PokeAPISevenDaysOfCode.Model
{
    public class Pokemon
    {

        public string Name { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }

        public List<AbilitiesList> Abilities { get; set; }

        public string Url { get; set; }

        private int _humor = 10;

        public int Humor 
        { 
            get => _humor;
            set
            {
                if (value < 0)
                    _humor = 0;
                else if (value > 10)
                    _humor = 10;
                else
                    _humor = value;
            }
        }

        public string HumorDescricao => _humor > 5 ? "FELIZ" : "TRISTE";

        private int _alimentacao = 10;

        public int Alimentacao {
            get => _alimentacao;
            set
            {
                if (value < 0)
                    _alimentacao = 0;
                else if (value > 10)
                    _alimentacao = 10;
                else
                    _alimentacao = value;
            } 
        }

        public string AlimentacaoDescricao => _alimentacao > 5 ? "ALIMENTADO" : "FAMINTO";

        public Pokemon() { }

        public Pokemon(string name, int height, int weight, List<AbilitiesList> abilities)
        {
            Name = name;
            Height = height;
            Weight = weight;
            Abilities = abilities;
        }

        public void Brincar()
        {
            Humor++;
            Alimentacao--;
        }

        public void Alimentar()
        {
            Alimentacao++;
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
