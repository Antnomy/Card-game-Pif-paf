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
        private Random r;

        public Ai(Baralho baralho, Pilha cemiterio, Mao mao)
        {
            Baralho = baralho;
            Cemiterio = cemiterio;
            Mao = mao;
            r = new Random();
        }

        public void AutoPlay()
        {


            if (SeCemiterioArmaJogo())
            {
                Mao.AdcCarta(Cemiterio.RemoveTop());
            }
            else
            {
                Mao.AdcCarta(Baralho.RemoveTop());
            }

            Mao.RemoveGrupos();

            
            Mao.VerifSequencias();

            ArranjarTrincas();
            Mao.VerifTrincas();


        }
        public void SelecDescarte()
        {
            int indice = Mao.GetListaCartas().FindIndex(carta => carta.Grupo == Grupo.Nenhum);

            if (indice != -1)
            {
                Cemiterio.AdcCarta(Mao.RemovCarta(indice));
            }
            else
            {
                indice = Mao.GetListaCartas().FindIndex(carta => carta.Grupo == Grupo.Pares);
                if (indice != -1)
                {
                    Cemiterio.AdcCarta(Mao.RemovCarta(indice));
                }
            }
        }

        public void SetMao(Mao mao)
        {
            Mao = mao;
        }


        public bool SeCemiterioArmaJogo()
        {
            if (Cemiterio.QntCartas() > 0)
            {
                if (Mao.GetListaCartas().Find(carta => Mao.VerifPar(carta, Cemiterio.Top()) || Mao.VerifSeq(carta, Cemiterio.Top()) || Mao.VerifProx(carta, Cemiterio.Top())) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                    if (Mao.VerifPar(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]) && Mao.GetListaCartas()[i].Livre() && Mao.GetListaCartas()[j].Livre())
                    {
                        Mao.MoverCarta(j, i);
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
          
        }
        public void As()
        {
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
