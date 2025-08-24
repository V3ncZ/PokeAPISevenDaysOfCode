using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPISevenDaysOfCode.Model
{
    public class PokemonAbility
    {
        public AbilityDetails Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }
}
