using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PokeAPISevenDaysOfCode.Services;

namespace PokeAPISevenDaysOfCode.Menu
{
    public class Opcoes
    {
        public async Task MenuOpcoes()
        {
            Console.WriteLine(@" _                                    _       _     _ 
| |                                  | |     | |   (_)
| |_ __ _ _ __ ___   __ _  __ _  ___ | |_ ___| |__  _ 
| __/ _` | '_ ` _ \ / _` |/ _` |/ _ \| __/ __| '_ \| |
| || (_| | | | | | | (_| | (_| | (_) | || (__| | | | |
 \__\__,_|_| |_| |_|\__,_|\__, |\___/ \__\___|_| |_|_|
                           __/ |                      
                          |___/                  ");

            MensagemDeBoasVindas();

            Console.WriteLine("");

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("------------------- MENU ----------------");
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("");

            Console.WriteLine("1 - ADOTAR MASCOTE VIRTUAL");
            Console.WriteLine("2 - VER SEUS MASCOTES");
            Console.WriteLine("3 - SAIR");

            Console.WriteLine("ESCOLHA UMA OPCAO: ");
            var keyInfo = Console.ReadKey();
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
                    break;
                default:
                    break;
            }
        }

        private void VerSeusMascotes()
        {
            throw new NotImplementedException();
        }

        private async Task AdotarUmMascote()
        {
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

            Console.WriteLine("\nESCOLHA UMA ESPECIE: ");
            string especieEscolhida = Console.ReadLine()!;

            bool voltar = false;

            while (!voltar)
            {

                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine($"1 - SABER MAIS SOBRE O {especieEscolhida}");
                Console.WriteLine($"2 - ADOTAR O {especieEscolhida}");
                Console.WriteLine("3 - VOLTAR");
                Console.WriteLine("\nESCOLHA UMA OPCAO:");
                var keyInfo = Console.ReadKey();
                int opcao = keyInfo.KeyChar - '0';

                switch (opcao)
                {
                    case 1:
                        var pokemonDetails = await pokeClient.GetSpecificPokemon(especieEscolhida);

                        Console.WriteLine("\n-----------------------------------------");
                        Console.WriteLine($"NOME: {pokemonDetails.Name}");
                        Console.WriteLine($"ALTURA: {pokemonDetails.Height}");
                        Console.WriteLine($"PESO: {pokemonDetails.Weight}");
                        Console.WriteLine("HABILIDADES:");

                        foreach (var ability in pokemonDetails.Abilities)
                        {
                            Console.WriteLine($"{ability.Ability.Name}");
                        }
                        break;
                    case 2:
                        Console.WriteLine($"\n{especieEscolhida} FOI ESCOLHIDO COMO SEU NOVO MASCOTE, O OVO ESTA CHOCANDO!");
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
            Console.WriteLine("DIGITE O SEU NOME: ");
            string nome = Console.ReadLine()!;

            Console.WriteLine($"\nBEM VINDO {nome}");
        }
    }
}
