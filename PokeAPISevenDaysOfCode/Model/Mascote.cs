using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPISevenDaysOfCode.Model
{
    public class Mascote
    {
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

        public int Alimentacao
        {
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

        public void Brincar()
        {
            _alimentacao--;
            _humor++;
        }

        public void Alimentar()
        {
            _alimentacao++;
        }
    }
}
