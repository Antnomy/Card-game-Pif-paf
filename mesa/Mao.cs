using System;
using System.Collections.Generic;
using System.Text;
using Pif_paf;
using Enuns;

namespace mesa
{
    class Mao : Pilha
    {
        public int Trincas { get; private set; }
        public int Sequencias { get; private set; }
        public int selec { get; set; }
        public Carta Selecao { get; set; }
        public bool Visibilidade { get; private set; }

        public Mao()
        {

        }
        public Mao(Baralho baralho, int maoInicial)
        {
            for (int i = 0; i < maoInicial; i++)
            {
                Cartas.Add(baralho.RemoveTop());
            }
            selec = -1;
            Selecao = null;
            Visibilidade = true;
            Trincas = 0;
            Sequencias = 0;
        }

        public List<Carta> GetListaCartas()
        {
            return Cartas;
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
                throw new PifpafExeption("  Digite uma posiçaõ existente!! ENTER para continuar: ");
            }
            else
            {
                Cartas[posicao].Grupo = Grupo.Nenhum;
                return RemoveCarta(Cartas[posicao]);
            }
        }



        public void Descartar(int posicao, Pilha pilha)
        {
            if (!ValidarPosicao(posicao))
            {
                throw new PifpafExeption("Digite uma posiçaõ existente!! ENTER para continuar: ");
            }
            else
            {

                pilha.AdcCarta(RemoveCarta(Cartas[posicao]));
            }
        }

        public void Marcar(int indice)
        {
            if (!ValidarPosicao(indice))
            {
                throw new PifpafExeption("Digite uma posiçaõ existente! ENTER para continuar:");
            }
            else
            {
                //Selecao = Cartas[indice];
                selec = indice;
            }
        }
        public void DesMarcar()
        {
            //Selecao = null;
            selec = -1;
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
                throw new PifpafExeption("   Digite uma Posiçaõ existente! ENTER para continuar:");
            }
            else
            {
                Cartas.Insert(destino, RemoveCarta(Cartas[origem]));

            }
        }
        public void MoverSelecao(int direcao, int origem)
        {
            int destino;
            
                destino = origem + direcao;
                if (destino > QntCartas() - 1)
                {
                    destino = 0;
                }
                
                if (destino == 0)
                {
                    destino = QntCartas() - 1;
                }
                MoverCarta(origem, destino);
                Marcar(destino);
            
        }
        public bool VerifPar(Carta a, Carta b)
        {
            return a.Letra == b.Letra && a.Nipe != b.Nipe;
        }

        public bool VerifSeq(Carta a, Carta b)
        {
            if (a.Letra == "K" && b.Letra == "A" && a.Nipe == b.Nipe)
            {
                return true;
            }
            else
            {
                return a.Ordem == b.Ordem - 1 && a.Nipe == b.Nipe;
            }

        }
        public bool VerifSeq2p(Carta a, Carta b)
        {
            if (a.Letra == "K" && b.Letra == "A" && a.Nipe == b.Nipe)
            {
                return true;
            }
            else
            {
                return a.Ordem == b.Ordem - 2 && a.Nipe == b.Nipe;
            }

        }
      
        public bool VerifMenor(Carta a, Carta b)
        {
            return a.Ordem < b.Ordem;
        }
        public bool VerifIguais(Carta a, Carta b)
        {
            return a.Ordem == b.Ordem && a.Nipe == b.Nipe;
        }

        
        public void VerifTrincas()
        {
            Trincas = 0;
            for (int i = 0; i < Cartas.Count - 2; i++)
            {
                if (VerifPar(Cartas[i], Cartas[i + 1]) && Cartas[i].Livre() && Cartas[i + 1].Livre())
                {

                    if (VerifPar(Cartas[i + 1], Cartas[i + 2]) && Cartas[i + 2].Livre() && Cartas[i + 2].Nipe != Cartas[i].Nipe)
                    {
                        Cartas[i].Grupo = Grupo.Trincas;
                        Cartas[i + 1].Grupo = Grupo.Trincas;
                        Cartas[i + 2].Grupo = Grupo.Trincas;
                        Trincas++;
                        i += 2;
                    }
                }
            }
        }
        
        public void VerifSequencias()
        {

            Sequencias = 0;

            for (int i = 0; i < Cartas.Count - 2; i++)
            {
                if (VerifSeq(Cartas[i], Cartas[i + 1]))
                {
                    if (VerifSeq(Cartas[i + 1], Cartas[i + 2]))
                    {
                        Cartas[i].Grupo = Grupo.Sequencias;
                        Cartas[i + 1].Grupo = Grupo.Sequencias;
                        Cartas[i + 2].Grupo = Grupo.Sequencias;
                        Sequencias++;
                        i += 2;

                    }
                }
            }
        }
        public void VerifPares()
        {
            for (int i = 0; i < Cartas.Count - 1; i++)
            {
                if (Cartas[i].Livre() && Cartas[i + 1].Livre() && (VerifPar(Cartas[i], Cartas[i + 1]) || VerifSeq(Cartas[i], Cartas[i + 1])))
                {
                    Cartas[i].Grupo = Grupo.Pares;
                    Cartas[i + 1].Grupo = Grupo.Pares;                 
                }
            }
        }
        public int TotalArranjos()
        {
            return Trincas + Sequencias;
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
