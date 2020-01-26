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
            for (int i = 0; i < maoInicial; i++)
            {
                Cartas.Add(baralho.RemoveTop());
            }          
        }
        public void CompraCarta(Pilha cartas)
        {
            Cartas.Add(cartas.RemoveTop());
        }
        public Carta Descartar(int posicao)
        {
            Carta aux = Cartas[posicao - 1];
            Cartas.Remove(Cartas[posicao - 1]);
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
            string str;
            foreach (Carta cart in Cartas)
            {
                str = cart.ToString();
                txt.Append(str);

                if(str.Length < 9)
                {
                    txt.Append(' ', 9 - str.Length);                 
                }
                txt.Append("|");
            }
            return txt.ToString();
        }
    }
}
