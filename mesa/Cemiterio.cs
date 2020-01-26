using System;
using Pif_paf;

namespace mesa
{
    class Cemiterio : Pilha
    {
        public override Carta RemoveTop()
        {

            Carta aux = Cartas[0];
            Cartas.Remove(Cartas[0]);
            return aux;
        }

    }
    
}
