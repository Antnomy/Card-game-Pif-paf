﻿using System.Collections.Generic;
using System.Text;
using Pif_paf;

namespace mesa
{
    class Mao
    {
        private List<Carta> Cartas = new List<Carta>();
        private List<Trinca> Trincas = new List<Trinca>();
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

        public void MoverCarta(int origem, int destino)
        {

            if (!ValidarPosicao(destino))
            {
                throw new PifpafExeption("Digite uma posiçaõ existente!");
            }
            else
            {
                Cartas.Insert(destino, Descartar(origem));
            }
        }
        public bool VerifPar(Carta a, Carta b)
        {
            return a.Letra == b.Letra && a.Nipe != b.Nipe;
        }
        public bool VerifSeq(Carta a, Carta b)
        {
            return a.Ordem < b.Ordem && a.Nipe == b.Nipe;
        }
        public int VerifTrincas()
        {
            //Carta[] vet = new Carta[3];
            List<Carta> aux = new List<Carta>();
            int qntTrincas = 0;

            for (int i = 0; i < Cartas.Count - 1; i++)
            {
                if (VerifPar(Cartas[i], Cartas[i + 1]))
                {
                    aux.Add(Cartas[i + 1]);
                }
                else
                {
                    aux.Clear();
                }
                if (aux.Count == 2)
                {
                    aux.Add(Cartas[i]);
                    qntTrincas++;
                    aux.Clear();
                }

            }
            return qntTrincas;
        }
        public int VerifSequencias()
        {
            List<Carta> aux = new List<Carta>();
            int qntSequencias = 0;
            for (int i = 0; i < Cartas.Count - 1; i++)
            {
                if(VerifSeq(Cartas[i], Cartas[i + 1]))
                {
                    aux.Add(Cartas[i + 1]);
                }
                else
                {
                    aux.Clear();
                }
                if (aux.Count == 2)
                {
                    aux.Add(Cartas[i]);
                    qntSequencias++;
                    aux.Clear();
                }
            }
            return 1;
        }
        public void VerifTrincas2()
        {
            //Carta[] vet = new Carta[3];
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
