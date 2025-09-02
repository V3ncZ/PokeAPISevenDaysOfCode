using PokeAPISevenDaysOfCode.Exceptions;
using PokeAPISevenDaysOfCode.Model;
using PokeAPISevenDaysOfCode.Services;

namespace PokeAPISevenDaysOfCode.Menu
{
    public class Opcoes
    {

        public string NomeJogador { get; set; }

        public string EspecieEscolhida { get; set; }

        public Pokemon Pokemon { get; set; }

        // Lista para guardar os pokemons adotados
        public List<Pokemon> ListaDePokemons { get; set; } = new List<Pokemon>();

        public async Task MenuOpcoes()
        {

            MensagemDeBoasVindas();

            bool sair = false;
            while (!sair)
            {

                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine("------------------- MENU ----------------");
                Console.WriteLine("-----------------------------------------");

                Console.WriteLine("1 - ADOTAR MASCOTE VIRTUAL");
                Console.WriteLine("2 - VER SEUS MASCOTES");
                Console.WriteLine("3 - INTERAGIR COM SEU MASCOTE");
                Console.WriteLine("4 - SAIR");

                Console.WriteLine($"\n{NomeJogador} ESCOLHA UMA OPCAO....");
                var keyInfo = Console.ReadKey(true);
                int opcao = keyInfo.KeyChar - '0';

                switch (opcao)
                {
                    case 1:
                        await AdotarUmMascote();
                        break;
                    case 2:
                        VerSeusMascotes();
                        break;
                    case 3:
                        InteragirComMascote();
                        break;
                    case 4:
                        Console.WriteLine("NOS VEMOS LOGO! ATE MAIS!");
                        sair = true;
                        break;
                    default:
                        break;
                }
            }

            
        }

        private void InteragirComMascote()
        {

            Console.Clear();

            Console.WriteLine("QUAL POKEMON VOCE DESEJA INTERAGIR?");
            foreach (var (pokemon, i) in ListaDePokemons.Select((pokemon, i) => (pokemon, i)))
            {
                Console.WriteLine($"{i} - {pokemon.Name.ToUpper()}");
            }
            var pokemonEscolhido = Console.ReadLine();
            
            // Pega o pokemon com base no indice da lista
            Pokemon pokemonInteragir = ListaDePokemons[int.Parse(pokemonEscolhido!)];


            bool voltar = false;
            while(!voltar)
            {
                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine($"{NomeJogador} VOCE DESEJA....");
                Console.WriteLine($"1 - SABER COMO {pokemonInteragir.Name.ToUpper()} ESTA");
                Console.WriteLine($"2 - ALIMENTAR {pokemonInteragir.Name.ToUpper()}");
                Console.WriteLine($"3 - BRINCAR COM {pokemonInteragir.Name.ToUpper()}");
                Console.WriteLine("4 - VOLTAR");
                var keyInfo = Console.ReadKey(true);
                int opcao = keyInfo.KeyChar - '0';


                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\n-----------------------------------------");
                        Pokemon.StatusDoPokemon();
                        break;  
                    case 2:
                        Console.WriteLine("\n-----------------------------------------");
                        Pokemon.Alimentar();
                        Console.WriteLine($"{pokemonInteragir.Name.ToUpper()} ALIMENTADO!");
                        break;
                    case 3:
                        Console.WriteLine("\n-----------------------------------------");
                        Pokemon.Brincar();
                        Console.WriteLine($"{pokemonInteragir.Name.ToUpper()} ESTA MAIS FELIZ!");
                        break;
                    case 4:
                        voltar = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("OPCAO INVALIDA VOLTANDO PARA O MENU DE OPCOES...");
                        voltar = true;
                        break;


                }
            }

        }

        private void VerSeusMascotes()
        {
            Console.WriteLine("\n-----------------------------------------");
            Console.WriteLine("SEUS MASCOTES POKEMON!");

            foreach (var (pokemon, i) in ListaDePokemons.Select((pokemon, i) => (pokemon, i = 1)))
            {
                Console.WriteLine($"{i} - {pokemon.Name.ToUpper()}");
            }
            Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA VOLTAR AO MENU...");
        }

        private async Task AdotarUmMascote()
        {
            Console.Clear();

            Console.WriteLine("");

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("------------ ADOTAR UM MASCOTE ----------");
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("");

            var client = new HttpClient();
            var pokeClient = new PokeApiClient(client);

            var page = await pokeClient.GetPokemonAsync(40, 0);

            // Pega 5 pokemon aleatoriamente do resultado da pagina
            var randomPokemon = page.Results.OrderBy(x => Guid.NewGuid()).Take(5).ToList();

            foreach (var pokemon in randomPokemon) 
            {
                Console.WriteLine(pokemon.Name.ToUpper());
            }

            bool pokemonValido = false;
            while (!pokemonValido)
            {
                try
                {
                    Console.WriteLine($"\n{NomeJogador} ESCOLHA UM POKEMON DA LISTA OU ALGUM OUTRO QUE VOCE DESEJAR: ");

                    EspecieEscolhida = Console.ReadLine()!.ToUpper()!;

                    var pokemonDetails = await pokeClient.GetSpecificPokemon(EspecieEscolhida);

                    Pokemon = new Pokemon(pokemonDetails.Name, pokemonDetails.Height, pokemonDetails.Weight, pokemonDetails.Abilities);

                    pokemonValido = true;

                }
                catch (PokemonNaoEncontradoException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("TENTE NOVAMENTE");
                }
            }
            

            bool voltar = false;
            while (!voltar)
            {

                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine($"1 - SABER MAIS SOBRE O {Pokemon.Name.ToUpper()}");
                Console.WriteLine($"2 - ADOTAR O {Pokemon.Name.ToUpper()}");
                Console.WriteLine("3 - VOLTAR");
                Console.WriteLine($"\n{NomeJogador} ESCOLHA UMA OPCAO...");
                var keyInfo = Console.ReadKey();
                int opcao = keyInfo.KeyChar - '0';

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\n-----------------------------------------");
                        Console.WriteLine($"NOME: {Pokemon.Name.ToUpper()}");
                        Console.WriteLine($"ALTURA: {Pokemon.Height}");
                        Console.WriteLine($"PESO: {Pokemon.Weight}");
                        Console.WriteLine("HABILIDADES:");

                        foreach (var ability in Pokemon.Abilities)
                        {
                            Console.WriteLine($"{ability.Ability.Name}");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"\n{Pokemon.Name.ToUpper()} FOI ESCOLHIDO COMO SEU NOVO MASCOTE, O OVO ESTA CHOCANDO!");
                        Console.WriteLine(@"                                                                          
                                                                          
                                                                          
                                ████████                                  
                              ██        ██                                
                            ██▒▒▒▒        ██                              
                          ██▒▒▒▒▒▒      ▒▒▒▒██                            
                          ██▒▒▒▒▒▒      ▒▒▒▒██                            
                        ██  ▒▒▒▒        ▒▒▒▒▒▒██                          
                        ██                ▒▒▒▒██                          
                      ██▒▒      ▒▒▒▒▒▒          ██                        
                      ██      ▒▒▒▒▒▒▒▒▒▒        ██                        
                      ██      ▒▒▒▒▒▒▒▒▒▒    ▒▒▒▒██                        
                      ██▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒██                        
                        ██▒▒▒▒  ▒▒▒▒▒▒    ▒▒▒▒██                          
                        ██▒▒▒▒            ▒▒▒▒██                          
                          ██▒▒              ██                            
                            ████        ████                              
                                ████████                                  
                                                                          
                                                                          
                                                                          
");
                        Thread.Sleep(5000);
                        Console.WriteLine($"O OVO CHOCOU!\n{Pokemon.Name.ToUpper()} AGORA É SEU NOVO MASCOTE!");
                        ListaDePokemons.Add(Pokemon);
                        Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA VOLTAR....");
                        Console.ReadKey();
                        Console.Clear();
                        voltar = true;
                        break;
                    case 3:
                        voltar = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public void MensagemDeBoasVindas()
        {
            Console.WriteLine(@" _                                    _       _     _ 
| |                                  | |     | |   (_)
| |_ __ _ _ __ ___   __ _  __ _  ___ | |_ ___| |__  _ 
| __/ _` | '_ ` _ \ / _` |/ _` |/ _ \| __/ __| '_ \| |
| || (_| | | | | | | (_| | (_| | (_) | || (__| | | | |
 \__\__,_|_| |_| |_|\__,_|\__, |\___/ \__\___|_| |_|_|
                           __/ |                      
                          |___/                  ");

            if (string.IsNullOrEmpty(NomeJogador))
            {
                Console.WriteLine("DIGITE O SEU NOME: ");

                NomeJogador = Console.ReadLine().ToUpper();
            }
            
        }

    }
}
