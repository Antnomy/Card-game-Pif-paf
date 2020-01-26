using System;
using System.Collections.Generic;
using System.Text;
using Pif_paf;

namespace mesa
{
    class Mao 
    {
        private List<Carta> Cartas  = new List<Carta>();
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
        public void MoverCarta(int origem, int destino)
        {
            Cartas.Insert(destino, Descartar(origem));
        }
        public int QntCartas()
        {
            return Cartas.Count;
        }
        public override string ToString()
        {
            StringBuilder txt = new StringBuilder("|");
            foreach (Carta cart in Cartas)
            {
                txt.Append(cart.ToString());
                if(txt.Length < 10)
                {
                    txt.Append(' ', 10 - txt.Length);                 
                }
                txt.Append(" |");
            }
            return txt.ToString();
        }
    }
}
