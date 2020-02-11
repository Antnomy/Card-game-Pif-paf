using System;
using System.Collections.Generic;
using mesa;

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
           
            Mao.AdcCarta(Baralho.RemoveTop());
            //Mao.GetListaCartas().Insert(SelecRandonIndiceMao(), Mao.Descartar(SelecRandonIndiceMao()));
            //Cemiterio.AdcCarta(Mao.Descartar(SelecRandonIndiceMao()));
            Cemiterio.AdcCarta(Mao.Descartar(Mao.GetListaCartas().Count - 1));
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
        public bool LerParCemiterio()
        {         
            Carta carta = Mao.GetListaCartas().Find(carta => carta.Letra == Cemiterio.Top().Letra && carta.Nipe != Cemiterio.Top().Nipe);
            if (carta != null)
            {
                return true;
            }
            return false;
        }
        public void Arranjar()
        {
            List<Carta> aux = new List<Carta>();

            for (int i = 0; i < Mao.GetListaCartas().Count; i++)
            {
                for (int j = 1; j < Mao.GetListaCartas().Count; j++)
                {
                    if (Mao.VerifPar(Mao.GetListaCartas()[i], Mao.GetListaCartas()[j]))
                    {
                        Mao.MoverCarta(j, i + 1);
                    }
                    
                }
                 
            }
            foreach (Carta item in aux)
            {
                System.Console.WriteLine(item);
            }
            System.Console.ReadLine();
            aux.Clear();
        }

    }
}
