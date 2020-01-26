using System;
using System.Collections.Generic;
using System.Text;

namespace mesa
{
    class Mao : Pilha
    {
        public Baralho Baralho { get; private set; }
        public Mao(Baralho baralho)
        {
            for (int i = 1; i < 5; i++)
            {
                Cartas.Add(baralho.RemoveTop());
            }          
        }
        public void CompraCarta()
        {
            Cartas.Add(Baralho.RemoveTop());
        }
        public void Descartar(int posicao)
        {
            Cartas.Remove(Cartas[posicao]);
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
