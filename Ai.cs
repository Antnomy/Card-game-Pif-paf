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

            ArrjarSeq();
            Mao.VerifSequencias();

            ArranjarTrincas();
            Mao.VerifTrincas();

            
        }
        public void SelecDescarte()
        {
            int indice = Mao.GetListaCartas().FindIndex(carta => carta.Grupo == Grupo.Nenhum);
            Console.WriteLine("indice para descartar: " + indice);
            Console.ReadLine();
            if (indice >= 0)
            {
                Cemiterio.AdcCarta(Mao.Descartar(indice));
            }
        }

        public void SetMao(Mao mao)
        {
            Mao = mao;
        }
        public bool Confirmar()
        {
            return Convert.ToBoolean(r.Next(2));
        }
        public int SelecRandonIndiceMao()
        {
            return r.Next(Mao.GetListaCartas().Count - 1);
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
        public int DifOrdem(Carta a, Carta b)
        {
            if (a.Nipe == b.Nipe)
            {
                return a.Ordem - b.Ordem;
            }
            else
            {
                return 0;
            }
        }

        public bool VerifSeq2(Carta a, Carta b)
        {
            return a.Ordem == b.Ordem - 2 && a.Nipe == b.Nipe;
        }

        public void ArranjarTrincas()
        {
            List<Carta> aux = new List<Carta>();

            for (int i = 0; i < Mao.GetListaCartas().Count; i++)
            {
                for (int j = 0; j < Mao.GetListaCartas().Count; j++)
                {
                    if (Mao.VerifPar(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]) && Mao.GetListaCartas()[i].Grupo == Grupo.Nenhum && Mao.GetListaCartas()[j].Grupo == Grupo.Nenhum)
                    {
                        Mao.MoverCarta(j, i);
                    }
                }
                Mao.VerifSequencias();
            }

            aux.Clear();
        }
        public int BuscaProx(int posicao)
        {
            return Mao.GetListaCartas().FindIndex(carta => Mao.VerifProx(Mao.GetListaCartas()[posicao], carta));
        }
        public void ArrjarSeq()
        {
            //Prox
            for (int i = 0; i < Mao.GetListaCartas().Count - 1; i++)
            {
                for (int j = 0; j < Mao.GetListaCartas().Count; j++)
                {
                    if (Mao.VerifProx(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]) && !Mao.VerifIguiais(Mao.GetListaCartas()[j], Mao.GetListaCartas()[i + 1]))
                    {
                        Mao.MoverCarta(j, i);

                    }
                }
            }
            //Ant
            for (int i = 0; i < Mao.GetListaCartas().Count; i++)
            {
                for (int j = 1; j < Mao.GetListaCartas().Count; j++)
                {
                    if (Mao.VerifSeq(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]) && !Mao.VerifIguiais(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j - 1]))
                    {
                        Mao.MoverCarta(i, j);

                    }
                }
            }

        }
        public void ArrjarSeqSemIguias()
        {
            //Prox
            for (int i = 0; i < Mao.GetListaCartas().Count - 1; i++)
            {
                for (int j = 0; j < Mao.GetListaCartas().Count; j++)
                {
                    if (Mao.VerifProx(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]) && !Mao.VerifSeq(Mao.GetListaCartas()[i + 1], Mao.GetListaCartas()[i]))
                    {
                        Mao.MoverCarta(j, i);

                    }
                }
            }
            //Ant
            for (int i = 0; i < Mao.GetListaCartas().Count; i++)
            {
                for (int j = 1; j < Mao.GetListaCartas().Count; j++)
                {
                    if (Mao.VerifSeq(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]) && !Mao.VerifSeq(Mao.GetListaCartas()[j - 1], Mao.GetListaCartas()[j]))
                    {
                        Mao.MoverCarta(i, j);

                    }
                }
            }

        }
        public void ArrjarSeqtIn()
        {
            List<Carta> aux = new List<Carta>();
            insertion_sort();
            for (int i = 0; i < Mao.GetListaCartas().Count - 1; i++)
            {

                for (int j = 0; j < Mao.GetListaCartas().Count; j++)
                {

                    if (Mao.VerifSeq(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]))
                    {
                        Mao.MoverCarta(j, i + 1);

                        break;
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

        public static int ComparaSeq(Carta a, Carta b)
        {
            if (a.Ordem > b.Ordem && a.Nipe == b.Nipe)
            {
                Console.WriteLine("sim");
                Console.ReadLine();
                return -1;

            }
            return 1;
        }



    }
}
