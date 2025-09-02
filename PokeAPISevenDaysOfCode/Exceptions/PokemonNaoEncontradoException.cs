using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPISevenDaysOfCode.Exceptions
{
    public class PokemonNaoEncontradoException : Exception
    {
        public PokemonNaoEncontradoException() : base("\nNAO FOI POSSIVEL LOCALIZAR ESTE POKEMON...") 
        { 
        }

        public PokemonNaoEncontradoException(string msg) : base(msg) 
        { 
        }
    }
}
