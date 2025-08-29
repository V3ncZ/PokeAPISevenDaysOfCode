using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PokeAPISevenDaysOfCode.Model;
using PokeAPISevenDaysOfCode.Services;

namespace PokeAPISevenDaysOfCode.Menu
{
    public class Opcoes
    {

        public string NomeJogador { get; set; }

        public string EspecieEscolhida { get; set; }

        public Pokemon Pokemon { get; set; }

        public List<Pokemon> ListaDePokemons { get; set; }

        public async Task MenuOpcoes()
        {

            Console.Clear();

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

            bool voltar = false;
            while (!voltar)
            {

                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine($"{NomeJogador} VOCE DESEJA....");
                Console.WriteLine($"1 - SABER COMO {EspecieEscolhida} ESTA");
                Console.WriteLine($"2 - ALIMENTAR {EspecieEscolhida}");
                Console.WriteLine($"3 - BRINCAR COM {EspecieEscolhida}");
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
                        Console.WriteLine($"{Pokemon.Name.ToUpper()} ALIMENTADO!");
                        break;
                    case 3:
                        Console.WriteLine("\n-----------------------------------------");
                        Pokemon.Brincar();
                        Console.WriteLine($"{Pokemon.Name.ToUpper()} ESTA MAIS FELIZ!");
                        break;
                    case 4:
                        voltar = true;
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
            throw new NotImplementedException();
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

            var page = await pokeClient.GetPokemonAsync(3, 0);

            foreach (var pokemon in page.Results) 
            {
                Console.WriteLine(pokemon.Name.ToUpper());
            }

            Console.WriteLine($"\n{NomeJogador} ESCOLHA UMA ESPECIE: ");
            EspecieEscolhida = Console.ReadLine().ToUpper()!;

            var pokemonDetails = await pokeClient.GetSpecificPokemon(EspecieEscolhida);

            Pokemon = new Pokemon(pokemonDetails.Name, pokemonDetails.Height, pokemonDetails.Weight, pokemonDetails.Abilities);

            ListaDePokemons.Add(Pokemon);

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
                        Console.WriteLine("\nPRESSIONE QUALQUER TECLA PARA VOLTAR....");
                        Console.ReadKey();
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
