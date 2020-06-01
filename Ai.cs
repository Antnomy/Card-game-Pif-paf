using System;
using System.Collections.Generic;
using mesa;
using Enuns;

namespace Pif_paf
{
    class Ai
    {
        public Baralho Baralho;
        public Pilha Cemiterio;
        public Mao Mao;
        public Ai(Baralho baralho, Pilha cemiterio, Mao mao)
        {
            Baralho = baralho;
            Cemiterio = cemiterio;
            Mao = mao;
        }
        public void AutoMontar()
        {
            Mao.RemoveGrupos();
            ArrjarSeqtIn();
            Mao.VerifSequencias();
            ArranjarTrincas();
            Mao.VerifTrincas();
            Mao.VerifPares();
        }
        public void Comprar()
        {
            if (CemiterioFazJogo())
            {
                Mao.AdcCarta(Cemiterio.RemoveTop());
            }
            else
            {
                Mao.AdcCarta(Baralho.RemoveTop());
            }
        }
        public int SelecDescarte()
        {
            int indice = Mao.GetListaCartas().FindIndex(carta => carta.Grupo == Grupo.Nenhum);

            if (indice != -1)
            {
                return indice;
            }
            else
            {
                indice = Mao.GetListaCartas().FindIndex(carta => carta.Grupo == Grupo.Pares);
                return indice;
            }
        }

        public void SetMao(Mao mao)
        {
            Mao = mao;
        }

        private bool CemiterioFazJogo()
        {
            if (Cemiterio.QntCartas() > 0)
            {
                if (Mao.GetListaCartas().Find(carta => carta.Grupo == Grupo.Nenhum && (Mao.VerifPar(carta, Cemiterio.Top()) || Mao.VerifSeq(carta, Cemiterio.Top()) || Mao.VerifSeq(Cemiterio.Top(), carta))) != null)
                {

                    return true;
                }
                //Se completa uma trinca ou sequencia.
                if (Mao.GetListaCartas().Find(carta => carta.Grupo == Grupo.Pares && (Mao.VerifPar(carta, Cemiterio.Top()) || Mao.VerifSeq(carta, Cemiterio.Top()) || Mao.VerifSeq(Cemiterio.Top(), carta))) != null)
                {
                    if (Mao.GetListaCartas().Exists(carta => Mao.VerifIguais(carta, Cemiterio.Top())))
                    {

                        return false;
                    }
                    return true;
                }

                //Se é 2 acima ou abaixo de uma sequencia.

                if (Mao.GetListaCartas().Find(carta => carta.Livre() && (Mao.VerifSeq2p(carta, Cemiterio.Top()) || Mao.VerifSeq2p(Cemiterio.Top(), carta))) != null)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void ArranjarTrincas()
        {
            for (int i = 0; i < Mao.GetListaCartas().Count - 1; i++)
            {
                for (int j = i + 1; j < Mao.GetListaCartas().Count; j++)
                {
                    if (Mao.VerifPar(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]) && !Mao.VerifPar(Mao.GetListaCartas()[i], Mao.GetListaCartas()[i + 1]) && Mao.GetListaCartas()[i].Livre() && Mao.GetListaCartas()[j].Livre())
                    {
                        Mao.MoverCarta(j, i);
                        break;
                    }
                }
            }
        }
        public bool Livre(Carta carta)
        {
            if (carta.Grupo == Grupo.Nenhum || carta.Grupo == Grupo.Pares)
            {
                return true;
            }
            return false;
        }
        public void ArrjarSeqtIn()
        {
            insertion_sort();

            int tam = Mao.GetListaCartas().Count;
            for (int i = 0; i < tam - 1; i++)
            {
                for (int j = i + 1; j < tam; j++)
                {
                    if (Mao.VerifSeq(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]) && !Mao.VerifSeq(Mao.GetListaCartas()[i], Mao.GetListaCartas()[i + 1]))
                    {
                        Mao.MoverCarta(j, i + 1);
                        break;
                    }
                }
            }
            //Verifica alternativo: As depois do Rei.
            Mao.VerifSequencias();
            for (int i = 0; i < Mao.GetListaCartas().Count; i++)
            {
                if (Mao.GetListaCartas()[i].Letra == "K")
                {
                    int indice = Mao.GetListaCartas().FindIndex(item => item.Letra == "A" && item.Nipe == Mao.GetListaCartas()[i].Nipe);

                    if (indice != -1 && Mao.GetListaCartas()[i].Livre() && Mao.GetListaCartas()[indice].Livre() && i - indice > 1)
                    {
                        Mao.MoverCarta(indice, i);
                    }
                }
            }
        }

        public void insertion_sort()
        {
            int i, j;
            Carta atual;
            for (i = 1; i < Mao.GetListaCartas().Count; i++)
            {
                atual = Mao.GetListaCartas()[i];
                j = i - 1;

                while (j >= 0 && Mao.VerifMenor(atual, Mao.GetListaCartas()[j]))
                {
                    Mao.GetListaCartas()[j + 1] = Mao.GetListaCartas()[j];
                    j--;
                }
                Mao.GetListaCartas()[j + 1] = atual;
            }
        }
    }
}
