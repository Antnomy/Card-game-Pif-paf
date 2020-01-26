using System;
using System.Collections.Generic;
using System.Text;
using Pif_paf;

namespace mesa
{
    class Mao 
    {
        public List<Carta> Cartas { get; protected set; } = new List<Carta>();
        public Mao(Baralho baralho, int maoInicial)
        {
            for (int i = 1; i < maoInicial; i++)
            {
                Cartas.Add(baralho.RemoveTop());
            }          
        }
        public void CompraCarta(Pilha cartas)
        {
            if (cartas.QntCartas() == 0)
            {
                throw new PifpafExeption("Não há mais cartas para sacar!");
            }
            Cartas.Add(cartas.RemoveTop());
        }
        public Carta Descartar(int posicao)
        {
            Carta aux = Cartas[posicao];
            Cartas.Remove(Cartas[posicao]);
            return aux;
        }
        
        public override string ToString()
        {
            StringBuilder txt = new StringBuilder();
            foreach (Carta cart in Cartas)
            {
                txt.Append(cart.ToString() + "|");
            }
            txt.AppendLine("");
            txt.AppendLine("");
            return txt.ToString();
        }
    }
}
