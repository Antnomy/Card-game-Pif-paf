using System.Collections.Generic;
using System.Text;
using Pif_paf;

namespace mesa
{
    class Mao 
    {
        private List<Carta> Cartas  = new List<Carta>();
        public Carta Selecao { get; set; }
        public bool Visibilidade { get; private set; }
        public Mao(Baralho baralho, int maoInicial)
        {
            for (int i = 0; i < maoInicial; i++)
            {
                Cartas.Add(baralho.RemoveTop());
            }
            Selecao = null;
            Visibilidade = true;
        }

        public List<Carta> GetListaCartas()
        {
            return Cartas;
        }

        public void AdcCarta(Carta carta)
        {
            Cartas.Add(carta);
        }
        public void RemovCarta(Carta carta)
        {
            Cartas.Remove(carta);
        }

        public void CompraCarta(Pilha cartas)
        {
            Cartas.Add(cartas.RemoveTop());
        }

        public bool ValidarPosicao(int posicao)
        {
            if(posicao <= Cartas.Count && posicao >= 1)
            {
                return true;
            }
            return false;
        }
        public Carta Descartar(int posicao)
        {
            if (!ValidarPosicao(posicao))
            {
                throw new PifpafExeption("Digite uma posiçaõ existente!");
            }
            else
            {
                Carta aux = Cartas[posicao - 1];
                Cartas.Remove(Cartas[posicao - 1]);
                return aux;
            }
            
        }

        public void Marcar(int indice)
        {
            if (!ValidarPosicao(indice))
            {
                throw new PifpafExeption("Digite uma posiçaõ existente!");
            }
            else
            {
                Selecao = Cartas[indice - 1];
            }
            
        }
        public void DesMarcar()
        {
            Selecao = null;
        }

        public void MoverCarta(int origem, int destino)
        {
            Cartas.Insert(destino - 1, Descartar(origem));
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
