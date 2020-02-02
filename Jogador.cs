using System;
using System.Collections.Generic;
using mesa;

namespace Pif_paf
{
    class Jogador
    {
        public int Numero { get; private set; }
        public Mao Mao { get; set; }

        public Jogador(int numero, Mao mao)
        {
            Numero = numero;
            Mao = mao;
        }
    }
}
