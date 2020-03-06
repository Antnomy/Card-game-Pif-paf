using System.Collections.Generic;
using System.Text;
using Pif_paf;
using Enuns;

namespace mesa
{
    class Mao
    {
        private List<Carta> Cartas = new List<Carta>();
        private int Trincas;
        private int Sequencias;
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
            Trincas = 0;
            Sequencias = 0;
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
            if (posicao < Cartas.Count && posicao >= 0)
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
                Carta aux = Cartas[posicao];
                Cartas.Remove(Cartas[posicao]);
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
                Selecao = Cartas[indice];
            }
        }
        public void DesMarcar()
        {
            Selecao = null;
        }
        public void RemoveGrupos(int indice)
        {
            //Remove o grupo da carta no indice informado
            Cartas[indice].Grupo = Grupo.Nenhum;
        }
        public void RemoveGrupos()
        {
            Cartas.ForEach(carta => carta.Grupo = Grupo.Nenhum);
        }

        public void MoverCarta(int origem, int destino)
        {

            if (!ValidarPosicao(destino))
            {
                throw new PifpafExeption("Digite uma posiçaõ existente!");
            }
            else
            {
                Cartas.Insert(destino, Descartar(origem));
                /*DesMarcar();
                RemoveGrupos();
                VerifTrincas();
                VerifSequencias();*/
            }
           
        }
        public bool VerifPar(Carta a, Carta b)
        {
            return a.Letra == b.Letra && a.Nipe != b.Nipe;
        }

        public bool VerifMenor(Carta a, Carta b)
        {
            return a.Ordem < b.Ordem; 
        }
        public bool VerifSeq(Carta a, Carta b)
        {
            return a.Ordem == b.Ordem - 1 && a.Nipe == b.Nipe;         
        }
        public bool VerifProx(Carta a, Carta b)
        {
            return a.Ordem == b.Ordem + 1 && a.Nipe == b.Nipe;
        }
        public bool VerifIguiais(Carta a, Carta b)
        {
            return a.Ordem == b.Ordem && a.Nipe == b.Nipe;
        }
        public int VerifTrincas()
        {
            Trincas = 0;           
            List<Carta> aux = new List<Carta>();
           
            for (int i = 0; i < Cartas.Count - 1; i++)
            {
                if (VerifPar(Cartas[i], Cartas[i + 1]) && (Cartas[i].Grupo == Grupo.Nenhum || Cartas[i].Grupo == Grupo.Pares))
                {
                    aux.Add(Cartas[i + 1]);
                    Cartas[i].Grupo = Grupo.Pares;
                    Cartas[i + 1].Grupo = Grupo.Pares;
                }
                else
                {
                    aux.Clear();
                }
                if (aux.Count == 2)
                {
                    aux.Insert(0, Cartas[i - 1]);
                    aux.ForEach(carta => carta.Grupo = Grupo.Trincas);
                    Trincas++;
                    aux.Clear();
                }

            }
            return Trincas;
        }
        public int VerifSequencias()
        {
            List<Carta> aux = new List<Carta>();
            Sequencias = 0;

            for (int i = 0; i < Cartas.Count - 1; i++)
            {               
                if (VerifSeq(Cartas[i], Cartas[i + 1]) && (Cartas[i].Grupo == Grupo.Nenhum || Cartas[i].Grupo == Grupo.Pares))
                {
                    aux.Add(Cartas[i + 1]);
                    Cartas[i].Grupo = Grupo.Pares;
                    Cartas[i + 1].Grupo = Grupo.Pares;

                }
                else
                {
                    aux.Clear();
                }
                if (aux.Count == 2)
                {                  
                    Sequencias++;
                    aux.Insert(0, Cartas[i-1]);
                    aux.ForEach(carta => carta.Grupo = Grupo.Sequencias);             
                    aux.Clear();
                }
            }
            return Sequencias;
        }
        public int TotalArranjos()
        {
            return Trincas + Sequencias;
        }
        public void VerifTrincas2()
        {
            List<Carta> aux = new List<Carta>();

            for (int i = 0; i < Cartas.Count; i++)
            {
                for (int j = 1; j < Cartas.Count; j++)
                {
                    if (VerifPar(Cartas[i], Cartas[j]))
                    {
                        aux.Add(Cartas[j]);
                    }
                    if (aux.Count == 2)
                    {
                        aux.Add(Cartas[i]);
                        System.Console.WriteLine("Trinca");
                        foreach (Carta item in aux)
                        {
                            System.Console.WriteLine(item);
                        }
                        System.Console.ReadLine();
                    }
                }
                aux.Clear();
            }
        }
        public bool BuscaSeq(Carta carta)
        {
            foreach (Carta item in Cartas)
            {
                if(VerifPar(carta, item))
                {
                    return true;
                }              
            }
            return false;
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

                if (str.Length < 9)
                {
                    txt.Append(' ', 9 - str.Length);
                }
                txt.Append("|");
            }
            return txt.ToString();
        }
    }
}
